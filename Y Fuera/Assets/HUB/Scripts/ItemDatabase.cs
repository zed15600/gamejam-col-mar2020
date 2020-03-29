using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase: MonoBehaviour
{
    public static ItemDatabase Instance {get; private set;}

    private void Awake()
    {
        Instance = this;
    }

    public List<Item> itemDatabase = new List<Item>();


}
