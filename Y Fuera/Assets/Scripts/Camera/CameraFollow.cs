using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    int screenWidth;
    int offset;
    public Transform human;
    public float leftEdge;
    public float rightEdge;

    // Start is called before the first frame update
    void Start() {
        screenWidth = Screen.width;
        offset = (screenWidth - 1024)/2;
        Vector3 initialPos = new Vector3(leftEdge, transform.position.y, transform.position.z);
        transform.position = initialPos;
    }

    // Update is called once per frame
    void Update() {
        if (human != null && human.gameObject.activeInHierarchy) {
            if (human.position.x < rightEdge) {
                transform.position = new Vector3(Mathf.Max(human.position.x, leftEdge), transform.position.y, transform.position.z);
            }
        }
    }

    public void moveCamera(bool toLeft) {
        float speed = 4f;
        Vector3 direction = new Vector3(toLeft?-1:1, 0, 0);
        Vector3 newPos = transform.position + direction* speed * Time.deltaTime;
        if (newPos.x >= leftEdge && newPos.x <= rightEdge) {
            transform.position = newPos; 
        }
    }
}
