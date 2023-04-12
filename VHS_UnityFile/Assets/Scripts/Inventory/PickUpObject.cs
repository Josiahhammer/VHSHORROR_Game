using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public string itemName;
    public int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var inventory = other.GetComponent<InventorySystem<string>>();
            if (inventory != null)
            {
                inventory.AddItem(itemName, amount);
                Destroy(gameObject);
            }
        }
    }
}
