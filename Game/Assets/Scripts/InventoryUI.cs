using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private List<InventorySlot> _inventoryVisual;
    [SerializeField]
    private InventorySlot _lastActiveSlot;
    [SerializeField]
    private InventorySlot _curentlyActiveSlot;
    // Make a function that will open screen and show info about item from inventory
    [SerializeField]
    private GameObject _itemInfoScreen;

    [SerializeField]
    private Inventory _inventory;

    private void Start()
    {
        _inventory.OnInventoryChanged += RefreshInventory;
        _inventoryVisual.AddRange(GetComponentsInChildren<InventorySlot>());
        foreach (InventorySlot slot in _inventoryVisual)
        {
            slot.InventorySlotBtn.onClick.AddListener(GetActiveSlot);
            slot.InventorySlotBtn.onClick.AddListener(DisableLastActiveSlot);
        }
    }

    public void RefreshInventory()
    {
        for (int i = _inventory.Count - 1; i >= 0; i--)
        {
            _inventoryVisual[i].SetItem(_inventory[i]);
        }
    }

    private void DisableLastActiveSlot()
    {
        if (_lastActiveSlot != _curentlyActiveSlot && _lastActiveSlot != null)
            _lastActiveSlot.HideDropDownMenu();
    }

    private void GetActiveSlot()
    {
        _lastActiveSlot = _curentlyActiveSlot;
        _curentlyActiveSlot = EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>();
    }

    public void ShowItemInfoScreen()
    {
        _itemInfoScreen.SetActive(!_itemInfoScreen.activeSelf);
    }
}
