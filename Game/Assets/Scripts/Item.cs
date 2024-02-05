using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemInfo _itemInfo;

    public ItemInfo ItemInfo { get { return _itemInfo; } }
}
