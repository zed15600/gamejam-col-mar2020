using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    int screenWidth;
    int offset;
    public Transform human;
    public float leftEdge;
    public float rightEdge;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        offset = (screenWidth - 1024)/2;
        Vector3 initialPos = new Vector3(leftEdge, transform.position.y, transform.position.z);
        transform.position = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (human.gameObject.activeInHierarchy) {
            if (human.position.x < rightEdge) {
                transform.position = new Vector3(Mathf.Max(human.position.x, leftEdge), transform.position.y, transform.position.z);
            }
        } else {
            if (Input.mousePosition.x > 0+offset && Input.mousePosition.x < 100+offset){
                if (transform.position.x > leftEdge) {
                    moveCamera(true);
                }
            } else if (Input.mousePosition.x < 1024+offset && Input.mousePosition.x > 924+offset && Input.mousePosition.y > 250){
                if (transform.position.x < rightEdge) {
                    moveCamera(false);
                }
            }
        }
    }

    private void moveCamera(bool toLeft) {
        float speed = 4f;
        Vector3 direction = new Vector3(toLeft?-1:1, 0, 0);
        transform.position += direction * speed * Time.deltaTime;
    }
}
