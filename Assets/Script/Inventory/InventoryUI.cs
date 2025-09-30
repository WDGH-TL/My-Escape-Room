using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image slot;
    public TextMeshProUGUI slotText;

    public void SetInfo(ItemTemplate itemData)
    {
        slot.color = itemData.itemColor;
        slotText.text = itemData.itemName;
    }

    public void ClearSlot(int ButtonIndex)
    {
        if (PlayerInventory.Instance.itemInventory[ButtonIndex] != null)
        {
            slot.color = Color.white;
            slotText.text = null;
            PlayerInventory.Instance.itemInventory[ButtonIndex] = null;
        }
    }
}
