using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public bool fallen = false;
    public float distance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("enter Collider");
        if (other.gameObject.CompareTag("object")) {
            Debug.Log("tag object");
            ObjectObstacle obj = other.gameObject.GetComponent<ObjectObstacle>();
            if (obj != null) {
                Debug.Log(obj.Type);
                switch (obj.Type){
                    case ObjectType.UP:
                        this.fallen = false;
                        break;
                    case ObjectType.DOWN:
                        this.fallen = true;
                        break;
                    case ObjectType.MOVE:
                        this.distance = obj.distance;
                        break;
                }
                
            }
        }
    }
}
