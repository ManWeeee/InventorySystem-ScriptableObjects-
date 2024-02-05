using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Inventory/ItemInfo", order = 1)]

public class ItemInfo : ScriptableObject
{
    [SerializeField]
    private int _itemId;
    [SerializeField]
    private string _description;
    [SerializeField]
    private string _name;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private EItemType _itemType;

    public int ItemId { get { return _itemId; } }
    public string Description { get { return _description; } private set { _description = value; } }
    public string Name { get { return _name; } private set { _name = value; } }
    public Sprite Icon { get { return _icon; } private set { _icon = value; } }
    public EItemType ItemType { get { return _itemType; } private set { _itemType = value; } }
}
