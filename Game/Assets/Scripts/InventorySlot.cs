using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Button _inventorySlotBtn;

    [SerializeField]
    private bool _isActive = false;

    [SerializeField]
    Image _iconImage;
    [SerializeField]
    Image _iconFrame;
    [SerializeField]
    GameObject _dropDownPanel;

    public Button InventorySlotBtn => _inventorySlotBtn;

    private void Start()
    {
        _isActive = false;
        _inventorySlotBtn = GetComponent<Button>();
        _inventorySlotBtn.onClick.AddListener(ShowDropDownMenu);
    }

    public void SetItem(Item item)
    {
        SetItemSprite(item);
        SetItemFrame(item);
    }

    public void SetItemSprite(Item item)
    {
        if (item == null)
        {
            _iconImage.color = new Color(1, 1, 1, 0);
            return;
        }
        _iconImage.color = new Color(1, 1, 1, 1);
        _iconImage.sprite = item.ItemInfo.Icon;
    }

    public void SetItemFrame(Item item)
    {
        if (item != null)
        {
            switch (item.ItemInfo.ItemType)
            {
                case EItemType.Armor:
                    {
                        _iconFrame.color = new Color(0, 0, 1, 0.5f);
                        return;
                    }
                case EItemType.Weapon:
                    {
                        _iconFrame.color = new Color(1, 0, 0, 0.5f);
                        return;
                    }
                case EItemType.Consumable:
                    {
                        _iconFrame.color = new Color(0, 1, 0, 0.5f);
                        return;
                    }
                default:
                    {
                        _iconFrame.color = new Color(1, 1, 1, 0.5f);
                        return;
                    }
            }
        }
        _iconFrame.color = new Color(1, 1, 1, 0.5f);
    }

    public void ShowDropDownMenu()
    {
        _isActive = !_isActive;
        _dropDownPanel.SetActive(_isActive);
    }

    public void HideDropDownMenu()
    {
        _isActive = false;
        _dropDownPanel.SetActive(_isActive);
    }
}
