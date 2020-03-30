using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HumanState {
    public float speed;
    public ObjectType current_state;
    public string name;
    public float distance;
}

public class Human : MonoBehaviour
{
    bool fallen = false;
    float final_distance = 0;
    Vector3 final_position;
    public HumanState current_state = new HumanState{};
    public Animator animator;
    public SpriteRenderer sprrenderer;

    // Start is called before the first frame update
    void Start()
    {
        final_distance = Random.Range(1.00f,3.33f);
        final_position = new Vector3(transform.position.x+final_distance, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(current_state.current_state == ObjectType.UP){
            this.fallen = false;
        }
        if(current_state.current_state == ObjectType.DOWN){
            this.fallen = true;
        }
        Vector3 vector_final_position = final_position - transform.position;
        Vector3 direction = vector_final_position.normalized;
        transform.position += direction * Time.deltaTime;
    }

    public void ChangeSprite(){
        //TODO change sprite
        //sprrenderer.sprite = this.current_state.sprite;
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("enter Collider");
        if (other.gameObject.CompareTag("object")) {
            Debug.Log("tag object");
            ObjectObstacle obj = other.gameObject.GetComponent<ObjectObstacle>();
            if (obj != null) {
                Debug.Log(obj.Type);
                current_state = obj.effect_on_human;
                animator.SetTrigger("Flip");
                if(current_state.current_state == ObjectType.MOVE)
                {
                    float x_position = other.transform.position.x + current_state.distance;
                    if(this.fallen == true){
                        x_position += 1;
                    }
                    this.final_position = new Vector3(x_position, this.transform.position.y, this.transform.position.z);
                }
            }
        }
    }
}
