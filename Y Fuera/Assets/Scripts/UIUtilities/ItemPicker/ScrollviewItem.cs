using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollviewItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler {

    public RectTransform inventory;
    public GameObject prefab;
    public NoiseBar noiseBar;
    public Image imageComponent;
    private RectTransform rectTransform;
    private GameObject prefabInstance;
    private Canvas canvas;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        prefabInstance = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
        prefabInstance.GetComponent<ObjectObstacle>().noise_bar = noiseBar;
        prefabInstance.GetComponent<CapsuleCollider2D>().enabled = false;
        prefabInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void OnDrag(PointerEventData eventData) {
        Vector3 pos = new Vector3(eventData.position.x, eventData.position.y, 20);
        prefabInstance.transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventData) {
        float inventoryUpperLimit = Screen.height * inventory.anchorMax.y;
        if (eventData.position.y > inventoryUpperLimit + 100) {
            prefabInstance.GetComponent<CapsuleCollider2D>().enabled = true;
            prefabInstance.GetComponent<Rigidbody2D>().gravityScale = 1;
            prefabInstance.GetComponent<SpriteRenderer>().sortingOrder = -1;
            Destroy(gameObject);
        } else {
            Destroy(prefabInstance);
        }
    }
}
