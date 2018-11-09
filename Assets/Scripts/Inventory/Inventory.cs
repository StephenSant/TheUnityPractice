using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public static int money;

    public Vector2 scr = Vector2.zero;
    public Vector2 scrollPos = Vector2.zero;

    public string sortType = "All";

    public Transform dropLocation;
    public Transform[] equippedLocation;
    public GameObject curWeapon;
    public Item weaponInfo;
    public GameObject curHelm;
    //0 = Right hand
    //1 = Head
    #endregion
    void Start()
    {

        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }
    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            return (false);
        }
        else
        {
            showInv = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return (true);
        }
    }
    private void OnGUI()
    {
        if (!PauseMenu.paused)
        {
            if (showInv)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
                {
                    scr.x = Screen.width / 16;
                    scr.y = Screen.height / 9;
                }
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");

                if (GUI.Button(new Rect(scr.x * 0.25f, scr.y * .6f, scr.x * 1, scr.y * .5f), "All"))
                {
                    sortType = "All";
                }
                if (GUI.Button(new Rect(scr.x * 0.25f, scr.y * 1.1f, scr.x * 1, scr.y * .5f), "Consumables"))
                {
                    sortType = "Consumables";
                }
                if (GUI.Button(new Rect(scr.x * 0.25f, scr.y * 1.6f, scr.x * 1, scr.y * .5f), "Armour"))
                {
                    sortType = "Armour";
                }
                if (GUI.Button(new Rect(scr.x * 0.25f, scr.y * 2.1f, scr.x * 1, scr.y * .5f), "Craftable"))
                {
                    sortType = "Craftable";
                }
                if (GUI.Button(new Rect(scr.x * 0.25f, scr.y * 2.6f, scr.x * 1, scr.y * .5f), "Weapon"))
                {
                    sortType = "Weapon";
                }
                if (GUI.Button(new Rect(scr.x * 0.25f, scr.y * 3.1f, scr.x * 1, scr.y * .5f), "Misc"))
                {
                    sortType = "Misc";
                }

                DisplayInv(sortType);

                if (weaponInfo != null)
                {
                    GUI.Box(new Rect(12.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), weaponInfo.Icon);
                }
                else
                {
                    GUI.Box(new Rect(12.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), "Currently not holding anything.");
                }

                if (selectedItem != null)
                {
                    GUI.Box(new Rect(5.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
                    switch (selectedItem.Type)
                    {
                        case ItemTypes.Consumables:
                            GUI.Box(new Rect(5.5f * scr.x, 3.6f * scr.y, 5 * scr.x, 1 * scr.y), selectedItem.Description + "\n\nAmount: " + selectedItem.Amount + "\nValue: " + selectedItem.Value + "\nHealth: " + selectedItem.Heal);
                            if (CharacterHandler.curHealth < CharacterHandler.maxHealth)
                            {
                                if (GUI.Button(new Rect(6.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Use"))
                                {
                                    CharacterHandler.curHealth += selectedItem.Heal;
                                    if (selectedItem.Amount > 1)
                                    {
                                        selectedItem.Amount--;
                                    }
                                    else
                                    {
                                        inv.Remove(selectedItem);
                                        selectedItem = null;
                                    }
                                    return;
                                }
                            }

                            else if (selectedItem.Heal < 0)
                            {
                                if (GUI.Button(new Rect(6.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Use"))
                                {
                                    CharacterHandler.curHealth += selectedItem.Heal;
                                    inv.Remove(selectedItem);
                                    selectedItem = null;
                                    return;
                                }
                            }
                            else
                            {
                                GUI.Box(new Rect(6.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Use");
                            }

                            break;
                        case ItemTypes.Armour:
                            GUI.Box(new Rect(5.5f * scr.x, 3.6f * scr.y, 5 * scr.x, 1 * scr.y), selectedItem.Description + "\n\nValue: " + selectedItem.Value + "\nArmour: " + selectedItem.Armour);
                            if (GUI.Button(new Rect(6.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Equip"))
                            {

                            }
                            break;
                        case ItemTypes.Craftable:
                            GUI.Box(new Rect(5.5f * scr.x, 3.6f * scr.y, 5 * scr.x, 1 * scr.y), selectedItem.Description + "\n\nAmount: " + selectedItem.Amount + "\nValue: " + selectedItem.Value);
                            if (GUI.Button(new Rect(6.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Use"))
                            {

                            }
                            break;
                        case ItemTypes.Misc:
                            GUI.Box(new Rect(5.5f * scr.x, 3.6f * scr.y, 5 * scr.x, 1 * scr.y), selectedItem.Description + "\n\nValue: " + selectedItem.Value);
                            if (GUI.Button(new Rect(6.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Use"))
                            {

                            }
                            break;
                        case ItemTypes.Weapon:
                            GUI.Box(new Rect(5.5f * scr.x, 3.6f * scr.y, 5 * scr.x, 1 * scr.y), selectedItem.Description + "\n\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage);

                            if (curWeapon == null || selectedItem.MeshName != curWeapon.name)
                            {
                                if (GUI.Button(new Rect(6.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Equip"))
                                {
                                    weaponInfo = selectedItem;
                                    if (curWeapon != null)
                                    {
                                        Destroy(curWeapon);
                                    }
                                    curWeapon = Instantiate(Resources.Load("Prefabs/Items/" + selectedItem.MeshName) as GameObject, equippedLocation[0]);

                                    curWeapon.GetComponent<ItemHandler>().enabled = false;
                                    curWeapon.name = selectedItem.MeshName;
                                }
                            }
                            break;
                    }
                    if (GUI.Button(new Rect(5.5f * scr.x, 4.6f * scr.y, 1 * scr.x, 0.25f * scr.y), "Discard"))
                    {

                        if (curWeapon != null && selectedItem.MeshName == curWeapon.name)
                        {
                            Destroy(curWeapon);
                            weaponInfo = null;
                        }
                        else if (curHelm != null && selectedItem.MeshName == curHelm.name)
                        {
                            Destroy(curHelm);
                        }

                        GameObject clone = Instantiate(Resources.Load("Prefabs/Items/" + selectedItem.MeshName) as GameObject, dropLocation.position, Quaternion.identity);
                        clone.AddComponent<Rigidbody>().useGravity = true;
                        if (selectedItem.Amount > 1)
                        {
                            selectedItem.Amount--;
                        }
                        else
                        {
                            inv.Remove(selectedItem);
                            selectedItem = null;
                        }
                        return;



                    }
                }
                else
                {
                    GUI.Box(new Rect(5.5f * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), "");
                    GUI.Box(new Rect(5.5f * scr.x, 3.6f * scr.y, 5 * scr.x, 1 * scr.y), "");
                }
            }
        }
    }
    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))//this displays the selected sort type
        {
            ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
            int a = 0;//amout of that type
            int s = 0;//slot postion of UI item
            for (int i = 0; i < inv.Count; i++)//this will make 'a' = the amount of items of that type in the inventory 
            {
                if (inv[i].Type == type)
                {
                    a++;
                }

            }
            if (a <= 17)//if the amount of this type is able to fit on the screen
            {
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory 
                {
                    if (inv[i].Type == type)
                    {
                        if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                        {
                            if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + s * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount))
                            {
                                selectedItem = inv[i];
                                Debug.Log(selectedItem.Name);
                            }
                        }
                        else
                        {
                            if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + s * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                                Debug.Log(selectedItem.Name);
                            }
                        }
                        s++;//move down 1 position
                    }
                }

            }
            else//if the amount of this type is NOT able to fit on the screen
            {
                scrollPos = GUI.BeginScrollView(new Rect(-1.5f * scr.x, 0 * scr.y, 6 * scr.x, 9 * scr.y), scrollPos, new Rect(0, 0, 0, (8.5f * scr.y) + ((a - 17) * (0.5f * scr.y))), false, true);
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory
                {
                    if (inv[i].Type == type)
                    {
                        if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                        {
                            if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + s * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount))
                            {
                                selectedItem = inv[i];
                                Debug.Log(selectedItem.Name);
                            }
                        }
                        else
                        {
                            if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + s * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name))
                            {
                                selectedItem = inv[i];
                                Debug.Log(selectedItem.Name);
                            }
                        }
                        s++;//move down 1 position
                    }
                }
                GUI.EndScrollView();
            }
        }
        else//this displays all items
        {
            #region Non Scroll Inventory
            if (inv.Count <= 17)
            {
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory
                {
                    if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                    {
                        if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + i * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + i * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                }
            }
            #endregion
            #region Scroll Inventory
            else
            {
                //our pos in scrolling view window, current pos, the viewable area, can you see the horizontal bar and can you see the vertical bar 
                scrollPos = GUI.BeginScrollView(new Rect(-1.5f * scr.x, 0 * scr.y, 6 * scr.x, 9 * scr.y), scrollPos, new Rect(0, 0, 0, (8.5f * scr.y) + ((inv.Count - 17) * (0.5f * scr.y))), false, true);
                #region Items in the viewing area
                for (int i = 0; i < inv.Count; i++)//shows the items in the inventory
                {
                    if (inv[i].Type == ItemTypes.Consumables || inv[i].Type == ItemTypes.Craftable)
                    {
                        if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + i * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name + " x" + inv[i].Amount))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(1.5f * scr.x, 0 * scr.y + i * (0.5f * scr.y), 2.85f * scr.x, 0.5f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                }
                #endregion
                //the end of our viewing area
                GUI.EndScrollView();
            }
            #endregion
        }
    }

}


