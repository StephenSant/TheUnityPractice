using System.Collections;
using UnityEngine;
[AddComponentMenu("NotSkyrim/NPC/Interact")]
public class Interact : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public GameObject mainCam;

    public float attackDamage = 10;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC Dialogue
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Dialogue dlg = hitInfo.transform.GetComponent<Dialogue>();

                    if (dlg != null)
                    {
                        player.GetComponent<CharacterMovement>().anim.SetBool("Moving", false);
                        player.GetComponent<CharacterMovement>().anim.SetBool("Running", false);
                        dlg.showDlg = true;
                        player.GetComponent<CharacterMovement>().enabled = false;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        Debug.Log("Talking to NPC.");
                    }
                }
                #endregion
                #region Chest
                if (hitInfo.collider.CompareTag("Chest"))
                {
                    Debug.Log("Opening chest.");
                }
                #endregion 
                #region Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Picking up item.");
                    ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                    if (handler != null)
                    {
                        handler.OnCollection();
                    }
                }
                #endregion
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    TakeDamage takeDamage = hitInfo.transform.GetComponent<TakeDamage>();
                    if (takeDamage != null)
                    {
                        takeDamage.damageTake += attackDamage;
                    }
                }
            }
        }
    }
}