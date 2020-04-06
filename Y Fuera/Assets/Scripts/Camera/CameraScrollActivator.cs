using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScrollActivator : MonoBehaviour {

    public bool pointerOver;
    public CameraFollow cam;
    public bool left;

    private void Update() {
        if (pointerOver) {
            cam.moveCamera(left);
        }
    }

    public void setPointerOver(bool value) {
        pointerOver = value;
    }
}
