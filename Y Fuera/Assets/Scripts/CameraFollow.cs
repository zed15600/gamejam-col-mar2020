using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform human;
    public float leftEdge;
    public float rightEdge;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 initialPos = new Vector3(leftEdge, transform.position.y, transform.position.z);
        transform.position = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (human.position.x > leftEdge && human.position.x < rightEdge) {
            transform.position = new Vector3(human.position.x, transform.position.y, transform.position.z);
        }
    }
}
