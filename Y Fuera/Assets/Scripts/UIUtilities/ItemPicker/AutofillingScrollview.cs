using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutofillingScrollview : MonoBehaviour {

    public AutofillingScrollviewItem[] items;
    public ScrollviewItem itemPrototype;
    
    void Start() {
        GameObject content = GetComponent<ScrollRect>().content.gameObject;
        foreach (var item in items) {
            ScrollviewItem newItem = GameObject.Instantiate(itemPrototype, content.transform);
            newItem.imageComponent.sprite = item.sprite;
            newItem.prefab = item.prefab;
            newItem.gameObject.SetActive(true);
        }
    }
}
