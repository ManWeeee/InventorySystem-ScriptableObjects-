using UnityEngine;

public class PlayerMouseControll : MonoBehaviour
{
    Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
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
                if (item)
                {
                    _player.Inventory.AddItem(item);
                    item.gameObject.SetActive(false);
                }
            }
        }
    }
}

