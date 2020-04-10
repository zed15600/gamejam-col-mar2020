using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoldMenu : MonoBehaviour, IPointerClickHandler {

    public Animator inventoryAnimator;

    public void OnPointerClick(PointerEventData eventData) {
        bool fold = inventoryAnimator.GetBool("Fold");
        inventoryAnimator.SetBool("Fold", !fold);
    }
}
