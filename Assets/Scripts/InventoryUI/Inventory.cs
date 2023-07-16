using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    [SerializeReference] public List<ItemSlotInfo> items = new List<ItemSlotInfo>();

    [Space]
    [Header("Inventory Menu Compoonents")]
    public GameObject inventoryMenu;
    public GameObject itemPanel;
    public GameObject itemPanelGrid;

    private List<ItemPanel> existingPanels = new List<ItemPanel>();

    [Space]
    public int inventorySize = 24;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            items.Add(new ItemSlotInfo(null, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryMenu.activeSelf)
            {
                inventoryMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                inventoryMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;

                RefreshInventory();
            }
        }
    }

    public void RefreshInventory()
    {
        existingPanels = itemPanelGrid.GetComponentsInChildren<ItemPanel>().ToList();

        // Create Panels if needed
        if (existingPanels.Count < inventorySize)
        {
            int amountToCreate = inventorySize - existingPanels.Count;

            for (int i = 0; i < amountToCreate; i++)
            {
                GameObject newPanel = Instantiate(itemPanel, itemPanelGrid.transform);
                existingPanels.Add(newPanel.GetComponent<ItemPanel>());
            }
        }

        int index = 0;
        foreach (ItemSlotInfo i in items)
        {
            // Name our List Elements
            i.name = "" + (index + 1);

            if (i.item != null) i.name += ": " + i.item.GiveName();
            else i.name += ": -";

            // Update our Panels
            ItemPanel panel = existingPanels[index];

            if (panel != null)
            {
                panel.name = i.name + " Panel";

                panel.inventory = this;
                panel.itemSlot = i;

                if (i.item != null)
                {
                    panel.itemImage.gameObject.SetActive(true);
                    panel.itemImage.sprite = i.item.GiveItemImage();
                    panel.stacksText.gameObject.SetActive(true);
                    panel.stacksText.text = "" + i.stacks;
                }
                else
                {
                    panel.itemImage.gameObject.SetActive(false);
                    panel.stacksText.gameObject.SetActive(false);
                }
            }

            index++;
        }
    }
}
