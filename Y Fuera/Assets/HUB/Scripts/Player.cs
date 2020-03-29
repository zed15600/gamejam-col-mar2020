using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Inventory inventory;

    [SerializeField]
    private UI_Inventory uiInventory;

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        ItemWorld.SpawnItemWorld(new Vector3(1, 1), ItemDatabase.Instance.itemDatabase[0]);
        ItemWorld.SpawnItemWorld(new Vector3(-1, 1), ItemDatabase.Instance.itemDatabase[1]);
        ItemWorld.SpawnItemWorld(new Vector3(0, -1), ItemDatabase.Instance.itemDatabase[2]);
    }


}
