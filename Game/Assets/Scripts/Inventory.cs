using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    InventorySlot[] _inventory;
    private int _inventorySize = 16;

    private void Start()
    {
        _inventory = new InventorySlot[_inventorySize];
        _inventory = GetComponentsInChildren<InventorySlot>();
    }

    public bool AddItem(GameObject item) 
    {
        foreach (InventorySlot inventorySlot in _inventory)
        {
            if (inventorySlot.Item == null)
            {
                inventorySlot.SetItem(item);
                return true;
            }
        }
        return false;
    }
}
