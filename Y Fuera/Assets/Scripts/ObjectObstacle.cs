using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType {
    UP,
    DOWN,
    MOVE
}


public class ObjectObstacle : MonoBehaviour
{
    public HumanState effect_on_human = new HumanState{};
    public ObjectType Type;
    public float distance = 0;
    public string objectName;
    public float sound_cost;
    public NoiseBar noise_bar;
    public string description;

    // Start is called before the first frame update
    void Start()
    {
        effect_on_human.current_state = Type;        
        effect_on_human.distance = distance;
        effect_on_human.name = objectName;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("human")) {
            CapsuleCollider2D collider = this.GetComponent<CapsuleCollider2D>();
            collider.enabled = false;
        } else if (other.gameObject.CompareTag("ground")) {
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.Play(0);
            this.noise_bar.AddNoise(this.sound_cost);
        }
    }

}
