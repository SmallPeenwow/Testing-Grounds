using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    public Inventory inventory;
    private Mouse mouse;
    public ItemSlotInfo itemSlot;
    public Image itemImage;
    public TextMeshProUGUI stacksText;

    public void PickupItem()
    {
        mouse.itemSlot = itemSlot;
        mouse.SetUI();
    }

    public void FadeOut()
    {
        itemImage.CrossFadeAlpha(0.3f, 0.05f, true);
    }

    public void DropItem()
    {
        itemSlot.item = mouse.itemSlot.item;
        itemSlot.stacks = mouse.itemSlot.stacks;
        inventory.ClearSlot(mouse.itemSlot);
    }

    public void SwapItem(ItemSlotInfo slotA, ItemSlotInfo slotB)
    {

    }

    public void OnClick()
    {
        if (inventory != null)
        {
            mouse = inventory.mouse;

            // Grab item if mouse slot is empty
            if (mouse.itemSlot.item == null)
            {
                if (itemSlot.item != null)
                {
                    PickupItem();
                    FadeOut();
                }
            }
            else
            {
                // Clicked on original slot
                if (itemSlot == mouse.itemSlot)
                {
                    inventory.RefreshInventory();
                }
                else if (itemSlot.item == null) // Clicked on empty slot
                {
                    DropItem();
                    inventory.RefreshInventory();
                }
                // Clicked on occupied slot of different item type
                else if (itemSlot.item.GiveName() != mouse.itemSlot.item.GiveName())
                {

                }
            }
        }
    }
}
