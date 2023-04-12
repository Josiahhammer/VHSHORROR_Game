using System.Collections.Generic;
using UnityEngine;

public class InventorySystem<T>
{
    private Dictionary<T, int> inventory = new Dictionary<T, int>();

    public void AddItem(T item, int amount = 1)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] += amount;
        }
        else
        {
            inventory[item] = amount;
        }
    }

    public void RemoveItem(T item, int amount = 1)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] -= amount;

            if (inventory[item] <= 0)
            {
                inventory.Remove(item);
            }
        }
    }

    public int GetItemCount(T item)
    {
        return inventory.ContainsKey(item) ? inventory[item] : 0;
    }
}
