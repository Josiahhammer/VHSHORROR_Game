using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public InventorySystem<string> inventory;
    public TextMeshProUGUI inventoryText;

    private void Update()
    {
        UpdateInventoryDisplay();
    }

    private void UpdateInventoryDisplay()
    {
        if (inventoryText != null && inventory != null)
        {
            inventoryText.text = "";

            foreach (KeyValuePair<string, int> item in inventory.GetItems())
            {
                inventoryText.text += $"{item.Key}: {item.Value}\n";
            }
        }
    }
}
