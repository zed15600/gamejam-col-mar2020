using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTeller : MonoBehaviour {

    public Image background;
    public Sprite[] images;
    private float timeBetweenImages = 5f;
    private float timeCounter = 0;
    private bool storyTold = false;
    private int prevSecond = 0;
    private int i = 0;

    private void Start() {
        background.sprite = images[i];
    }

    private void Update() {
        timeCounter += Time.deltaTime;
        int actualSecond = (int)(timeCounter % timeBetweenImages);
        if (!storyTold && actualSecond == 0 && prevSecond == timeBetweenImages-1) {
            i++;
            if (i >= images.Length) {
                storyTold = true;
                skipAll();
                return;
            }
            background.sprite = images[i];
        }
        prevSecond = actualSecond;
    }

    public void skipFrame() {
        timeCounter = 0;
        prevSecond = (int)timeBetweenImages-1;
    }

    public void skipAll() {
        SceneTransitionManager.instance.transitScene("Corridor");
    }
}
