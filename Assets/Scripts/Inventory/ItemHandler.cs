using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour {

    public int itemId = 0;
    public ItemTypes itemTypes;
    public int amount = 1;
    public void OnCollection()
    {
        if (itemTypes == ItemTypes.Money)
        {
            Inventory.money += amount;
        }
        else if (itemTypes == ItemTypes.Craftable || itemTypes == ItemTypes.Consumables)
        {
            int found = 0;
            int addIndex = 0;
            for (int i = 0; i < Inventory.inv.Count; i++)
            {
                if (itemId == Inventory.inv[i].Id)
                {
                    found = 1;
                    addIndex = i;
                    break;
                }
            }
            if (found == 1)
            {
                Inventory.inv[addIndex].Amount += amount;
            }
            else
            {
                Inventory.inv.Add(ItemData.CreateItem(itemId));
                if (amount > 1)
                {
                    for (int i = 0; i < Inventory.inv.Count; i++)
                    {
                        if (itemId == Inventory.inv[i].Id)
                        {
                            Inventory.inv[i].Amount = amount;
                        }
                    }
                }
            }
        }
        else
        {
            Inventory.inv.Add(ItemData.CreateItem(itemId));
        }
        DragAndDropInventory.AddItem(itemId);
        Destroy(gameObject);
    }
}
