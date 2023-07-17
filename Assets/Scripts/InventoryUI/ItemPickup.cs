using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemToDrop;
    public int amount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInvenotry = other.GetComponentInChildren<Inventory>();

            if (playerInvenotry != null)
            {
                PickUpItem(playerInvenotry);
            }
        }
    }

    public void PickUpItem(Inventory inventory)
    {
        amount = inventory.AddItem(itemToDrop, amount);

        if (amount < 1) Destroy(this.transform.root.gameObject);
    }
}
