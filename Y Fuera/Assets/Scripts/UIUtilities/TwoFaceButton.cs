using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoFaceButton : MonoBehaviour
{
    public GameObject secondFace;

    private void OnMouseDown() {
        Debug.Log("MouseDown");
        secondFace.SetActive(true);
    }

    private void OnMouseUp() {
        Debug.Log("MouseDown");
        secondFace.SetActive(false);
    }
}
