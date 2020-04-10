using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public RectTransform content;
    public bool toLeft;
    private bool mouseInside;

    private void Update() {
        if (mouseInside) {
            float speed = 200f;
            int dir = toLeft ? -1 : 1;
            float newPos = content.anchoredPosition.x + dir * speed * Time.deltaTime;
            content.anchoredPosition = new Vector2(newPos, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        mouseInside = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        mouseInside = false;
    }
}
