using UnityEngine;

public class UIController : MonoBehaviour
{
    private UIController Instance;
    [SerializeField]
    private GameObject _inventoryUI;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void ShowUI(GameObject uiElement)
    {
        uiElement.SetActive(true);
    }

    public void HideUI(GameObject uiElement)
    {
        uiElement.SetActive(false);
    }
}
