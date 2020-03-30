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
    bool started = false;
    float final_distance = 0;
    Vector3 final_position;
    float speed = 3;
    public Dictionary<bool, Dictionary<string, Sprite>> sprites = new Dictionary<bool, Dictionary<string, Sprite>>();
    public HumanState current_state = new HumanState();
    public Animator animator;
    public SpriteRenderer sprrenderer;
    public string[] spriteNames;
    public Sprite[] fallenSprites;
    public Sprite[] standingSprites;

    // Start is called before the first frame update
    void Start() {
        sprites.Add(true, new Dictionary<string, Sprite>());
        sprites.Add(false, new Dictionary<string, Sprite>());
        for(int i=0; i<fallenSprites.Length; i++){
            sprites[true].Add(spriteNames[i], fallenSprites[i]);
        }
        for(int i=0; i<standingSprites.Length; i++){
            sprites[false].Add(spriteNames[i], standingSprites[i]);
        }
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
        if (final_distance > 0 && transform.position.x < final_position.x) {
            Vector3 vector_final_position = final_position - transform.position;
            Vector3 direction = vector_final_position.normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void ChangeSprite(){
        sprrenderer.sprite = sprites[fallen][current_state.name];
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (!started && other.gameObject.CompareTag("ground")) {
            started = true;
            final_distance = Random.Range(3f,5f);
            final_position = new Vector3(transform.position.x+final_distance, transform.position.y, transform.position.z);
        } else if (other.gameObject.CompareTag("object")) {
            speed = 7;
            ObjectObstacle obj = other.gameObject.GetComponent<ObjectObstacle>();
            if (obj != null) {
                current_state = obj.effect_on_human;
                animator.SetTrigger("Flip");
                if(current_state.current_state == ObjectType.MOVE) {
                    float displacement = current_state.distance;
                    if(fallen == true){
                        displacement += 1;
                    }
                    displacement *= 2;
                    final_position = new Vector3(transform.position.x + displacement, transform.position.y, transform.position.z);
                }
            }
        }
    }
}
