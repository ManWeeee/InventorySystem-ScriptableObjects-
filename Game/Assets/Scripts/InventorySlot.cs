using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    GameObject _inventoryItem;
    [SerializeField]
    Item _item;

    [SerializeField]
    Image _iconImage;
    [SerializeField]
    Image _iconFrame;
    [SerializeField]
    Image _dropDownPanel;

    bool _isActive = false;

    public Item Item { get { return _item; } }

    private void Start()
    {
        SetItemSprite();
        SetItemFrame();
    }

    public void SetItem(GameObject item)
    {
        _inventoryItem = item;
        _item = item != null ? item.GetComponent<Item>() : null;
        SetItemSprite();
        SetItemFrame();
    }

    public void SetItemSprite()
    {
        if (_item == null)
        {
            _iconImage.color = new Color(1, 1, 1, 0);
            return;
        }
        _iconImage.color = new Color(1, 1, 1, 1);
        _iconImage.sprite = _item.ItemInfo.Icon;
    }

    public void SetItemFrame()
    {
        if (_item != null)
        {
            switch (_item.ItemInfo.ItemType)
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
                case EItemType.Food:
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

    public void DropItem()
    {
        if (_inventoryItem)
        {
            _inventoryItem.SetActive(true);
            Instantiate(_inventoryItem, PlayerMouseControll.Instance.transform.position, Quaternion.identity);
            Destroy(_inventoryItem);
            SetItem(null);
            ShowDropDownMenu();
        }
    }

    public void ShowDropDownMenu()
    {
        _isActive = !_isActive;
        _dropDownPanel.gameObject.SetActive(_isActive);
    }
}
