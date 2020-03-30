using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Human human_script;

    public void Change(){
        human_script.ChangeSprite();
    }
}
