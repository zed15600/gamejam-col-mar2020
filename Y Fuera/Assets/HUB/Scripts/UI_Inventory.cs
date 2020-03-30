using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UI_Inventory : MonoBehaviour
{
    
    private Inventory inventory;
    public Transform itemSlot;
    public Transform itemTemplate;

    /// <summary>
    /// Seteo de objeto inventario
    /// </summary>
    /// <param name="inventory">Inventario proporcionado por la clase player</param>
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    /// <summary>
    /// Método por el cual se refresca el HUB de los objetos que se encuentran presentes dentro del inventario del jugador.
    /// </summary>
    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlot)
        {
            if(child == itemTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemTemplateRectTransform = Instantiate(itemTemplate, itemSlot).GetComponent<RectTransform>();
            itemTemplateRectTransform.gameObject.SetActive(true);
            Image image = itemTemplateRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.Sprite;
        }
    }

}
