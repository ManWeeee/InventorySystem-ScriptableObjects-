using Unity.VisualScripting;
using UnityEngine;

public class PlayerMouseControll : MonoBehaviour
{
    public static PlayerMouseControll Instance;
    [SerializeField]
    Inventory _inventory;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
    void Update()
    {
        CollectItem();
    }

    private void CollectItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));

            if (hitCollider != null && hitCollider.TryGetComponent<Item>(out Item item))
            {

                if (_inventory.AddItem(item.gameObject))
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}

