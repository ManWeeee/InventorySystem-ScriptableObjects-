using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Assets/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    [SerializeField]
    List<Item> _inventory;

    public Action OnInventoryChanged;

    public int Count {  get { return _inventory.Count; } }

    public Item this[int num]
    {
        get { return _inventory[num]; }
    }

    private void OnDisable()
    {
        _inventory.Clear();
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        if (_inventory.Contains(item))
        {
            _inventory.Remove(item);
            OnInventoryChanged?.Invoke();
        }
    }
}
