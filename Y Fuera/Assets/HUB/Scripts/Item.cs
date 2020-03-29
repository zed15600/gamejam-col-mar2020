using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField]
    private string name;
    public string Name{ get{return name;} set{ name = value; }}

    public enum ItemType {
        UP,
        DOWN,
        MOVE
    }

    public ItemType itemType;

    [SerializeField]
    private Sprite sprite;
    public Sprite Sprite{ get { return sprite; } set { sprite = value; }}

    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab{get { return prefab; } set{ prefab = value; }}
}
