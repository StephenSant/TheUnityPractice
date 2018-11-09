using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int ItemID)
    {
        string name = "";
        string description = "";
        int value = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;
        int heal = 0;
        string icon = "";
        string mesh = "";
        ItemTypes types = ItemTypes.Armour;

        switch (ItemID)
        {
            #region Consumables 0-99
            case 0:
                name = "Apple";
                description = "Red, green they're all good.";
                value = 2;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 5;
                icon = "Apple_Icon";
                mesh = "Apple_Mesh";
                types = ItemTypes.Consumables;
                break;
            case 1:
                name = "Health Potion";
                description = "WE AIN'T GOT TIME TO HEAL!";
                value = 10;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 20;
                icon = "HealthPotion_Icon";
                mesh = "HealthPotion_Mesh";
                types = ItemTypes.Consumables;
                break;
            case 2:
                name = "Poison";
                description = "This doesn't look healthy.";
                value = 7;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = -20;
                icon = "Poison_Icon";
                mesh = "Poison_Mesh";
                types = ItemTypes.Consumables;
                break;
            case 3:
                name = "Meat";
                description = "Juicy, delicious red meat, for big strong warriors!";
                value = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 10;
                icon = "Meat_Icon";
                mesh = "Meat_Mesh";
                types = ItemTypes.Consumables;
                break;
            #endregion
            #region Armour 100-199
            case 100:
                name = "Wooden Helmet";
                description = "Wood. It's like a magnet for axes.";
                value = 15;
                damage = 0;
                armour = 5;
                amount = 1;
                heal = 0;
                icon = "WoodHelment_Icon";
                mesh = "WoodHelment_Mesh";
                types = ItemTypes.Armour;
                break;
            case 101:
                name = "Leather Helmet";
                description = "Some animals are covered in this. Didn't really help them.";
                value = 10;
                damage = 0;
                armour = 7;
                amount = 1;
                heal = 0;
                icon = "LeatherHelment_Icon";
                mesh = "LeatherHelment_Mesh";
                types = ItemTypes.Armour;
                break;
            case 102:
                name = "Iron Helmet";
                description = "Protects your special little head.";
                value = 15;
                damage = 0;
                armour = 12;
                amount = 1;
                heal = 0;
                icon = "IronHelment_Icon";
                mesh = "Iron" +
                    "Helment_Mesh";
                types = ItemTypes.Armour;
                break;
            #endregion
            #region Weapons 200-299
            case 200:
                name = "Wooden Sword";
                description = "With a rounded edge for safety.";
                value = 4;
                damage = 4;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "WoodSword_Icon";
                mesh = "WoodSword_Mesh";
                types = ItemTypes.Weapon;
                break;
            case 201:
                name = "Iron Axe";
                description = "For chopping wood... and other things.";
                value = 8;
                damage = 8;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "IronAxe_Icon";
                mesh = "IronAxe_Mesh";
                types = ItemTypes.Weapon;
                break;
            case 202:
                name = "Iron Sword";
                description = "It looks very sharp.";
                value = 10;
                damage = 10;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "IronSword_Icon";
                mesh = "IronSword_Mesh";
                types = ItemTypes.Weapon;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                name = "Stick";
                description = "You know, from a tree.";
                value = 1;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Stick_Icon";
                mesh = "Stick_Mesh";
                types = ItemTypes.Craftable;
                break;
            case 301:
                name = "Iron";
                description = "So much potenial.";
                value = 7;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Iron_Icon";
                mesh = "Iron_Mesh";
                types = ItemTypes.Craftable;
                break;
            case 302:
                name = "Leather";
                description = "Ready to be stitched together.";
                value = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Leather_Icon";
                mesh = "Leather_Mesh";
                types = ItemTypes.Craftable;
                break;
            #endregion
            #region Others 400-499
            case 400:
                name = "A lute";
                description = "For making sick beats!";
                value = 6;
                damage = 1;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Lute_Icon";
                mesh = "Lute_Mesh";
                types = ItemTypes.Misc;
                break;
            case 401:
                name = "Magic Gem";
                description = "Oooo, shiny.";
                value = 20;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Gem_Icon";
                mesh = "Gem_Mesh";
                types = ItemTypes.Misc;
                break;
            case 402:
                name = "Coin";
                description = "$$Dat cash money$$";
                value = 1;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Coins_Icon";
                mesh = "Coins_Mesh";
                types = ItemTypes.Money;
                break;
            case 403:
                name = "Book Titled:'How to read'";
                description = "This seem it would be helpful.";
                value = 1;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Book_Icon";
                mesh = "Book_Mesh";
                types = ItemTypes.Misc;
                break;
            #endregion
            #region Default
            default:
                name = "Apple";
                description = "Red, green they're all good.";
                value = 5;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 5;
                icon = "Apple_Icon";
                mesh = "Apple_Mesh";
                types = ItemTypes.Consumables;
                break;
#endregion

        }

        //Item temp = new Item(ItemID,name,description,value,types,name);
        Item temp = new Item
        {
         Name = name,
         Description = description,
         Id = ItemID,
         Value = value,
         Damage = damage,
         Armour = armour,
         Amount = amount,
         Heal = heal,
         Type = types,
         Icon = Resources.Load("Icons/" + icon) as Texture2D,
         MeshName = mesh
        };
        return temp;
    }
}
