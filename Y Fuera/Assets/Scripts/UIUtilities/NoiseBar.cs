using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseBar : MonoBehaviour
{

    float current_noise=0;
    public SceneStateManager stateMngr;
    public float max_noise = 20;
    public Image fill;
    public float max_height = 530;
    public float max_width = 51.8f;
    
    
    public void AddNoise(float noise_made){
        current_noise += noise_made;
        if(current_noise >= max_noise){
            stateMngr.noiseWakeUp();
        }
    }

    void Update()
    {
        fill.rectTransform.sizeDelta = new Vector2(max_width,(max_height*current_noise)/max_noise);
    }

}
