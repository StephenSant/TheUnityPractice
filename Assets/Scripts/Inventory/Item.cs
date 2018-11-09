using UnityEngine;

public class Item
{
    private int _id;
    private int _value;
    private int _damage;
    private int _armour;
    private int _amount;
    private int _heal;
    private string _mesh;
    private string _name;
    private string _description;
    private Texture2D _icon;
    private ItemTypes _types;

    public Item()
    {
        
    } 
    public Item(int id,string name,string description,int value,ItemTypes types, string meshName)
    {
        _id = id;
        _name = name;
        _value = value;
        _description = description;
        _types = types;
        _mesh = meshName;
}

    #region Properties
    public string Name
    {
        get {return _name;}
        set {_name = value;}
    }
    public string Description
    {
        get {return _description; }
        set { _description = value;}
    }
    public int Id 
    {
        get {return _id; }
        set { _id = value;}
    }
    public int Value
    {
        get {return _value; }
        set { _value = value;}
    }
    public int Damage
    {
        get {return _damage; }
        set { _damage = value;}
    }
    public int Armour
    {
        get {return _armour; }
        set { _armour = value;}
    }
    public int Amount
    {
        get {return _amount; }
        set { _amount = value;}
    }
    public int Heal
    {
        get {return _heal; }
        set { _heal = value;}
    }
    public string MeshName
    {
        get {return _mesh; }
        set { _mesh = value;}
    }
    public Texture2D Icon
    {
        get {return _icon; }
        set { _icon = value;}
    }
    public ItemTypes Type
    {
        get {return _types; }
        set { _types = value;}
    }
    #endregion
}
public enum ItemTypes
{
    Consumables,
    Armour,
    Weapon,
    Craftable,
    Money,
    Misc
}