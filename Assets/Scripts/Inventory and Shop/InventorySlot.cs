using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSO itemSO;
    public int quantity;
    public Image itemImage;
    public TMP_Text quantityText;
    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GetComponentInParent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData){
        if(quantity > 0){
            if(eventData.button == PointerEventData.InputButton.Left){
                if(itemSO.currentHealth>0 && StatsManager.Instance.currentHealth>=StatsManager.Instance.maxHealth)
                {
                    return;
                }
                inventoryManager.UseItem(this);
            }
            else if(eventData.button == PointerEventData.InputButton.Right){
                inventoryManager.DropItem(this);
            }
        }
        
    }

    public void UpdateUI()
    {
        if(itemSO != null){
            itemImage.sprite = itemSO.icon;
            itemImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else{
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }
}
