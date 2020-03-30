using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDatabase: MonoBehaviour
{
    public static ItemDatabase Instance {get; private set;}
    public Player player;
    public Text log;


    private void Awake()
    {
        Instance = this;
        player.setInventory();
    }

    public List<Item> itemDatabase = new List<Item>();


}
