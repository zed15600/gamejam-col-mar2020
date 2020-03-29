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
    public float speed = 0;
    int sprite_index = 0;
    // Start is called before the first frame update
    void Start()
    {
        effect_on_human.current_state = Type;        
        effect_on_human.distance = distance;
        effect_on_human.speed = speed;
        effect_on_human.sprite = sprite_index;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
