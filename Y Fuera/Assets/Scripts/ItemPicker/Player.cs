using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Inventory inventory;

    [SerializeField]
    private UI_Inventory uiInventory;

    public Text log;
    
    public void setInventory() {
        inventory = new Inventory(log);
        uiInventory.SetInventory(inventory);
    }

}
