using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    
    private List<Item> itemList; //Lista de items del inventario.
    
    /// <summary>
    /// Constructor que inicializa el inventario
    /// </summary>
    public Inventory(Text log)
    {
        itemList = new List<Item>();
        foreach (var obj in ItemDatabase.Instance.itemDatabase)
        {
            AddItems(obj);
        }       
    }

    /// <summary>
    /// Método por el cúal se agregan los items que puede usar al player a la lista de items.
    /// Y llama al evento de que la lista de items del inventario a cambiado.
    /// </summary>
    /// <param name="item">Item que recibe para posteriormente ser guardado.</param>
    public void AddItems(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Método por el cúal se elimina un objeto del inventario del player.
    /// Y llama al evento de que la lista de items del inventario a cambiado.
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(Item item)
    {
        foreach (var obj in itemList)
        {
            if(obj.Name == item.Name){
                itemList.Remove(obj);
                
                break;
            }       
        } 
        OnItemListChanged?.Invoke(this, EventArgs.Empty);   
    }

    /// <summary>
    /// Método que retorna la lista de items del inventario.
    /// </summary>
    /// <returns>Lista de items</returns>
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
