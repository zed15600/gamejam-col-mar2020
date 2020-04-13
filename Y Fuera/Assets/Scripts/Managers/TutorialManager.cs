using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public Animator scrollScreenAnimator;
    public Animator scrollMenuAnimator;
    [TextArea] public string[] texts;
    public Text tutorialLabel;
    public int i = 0;

    void Start() {
        next();
    }

    public void next() {
        if (i >= texts.Length) {
            SceneTransitionManager.instance.transitScene("Intro");
            return;
        }
        tutorialLabel.text = texts[i];
        switch (i) {
            case 4:
                scrollMenuAnimator.SetBool("Animate", true);
                break;
            case 5:
                scrollMenuAnimator.SetBool("Animate", false);
                scrollScreenAnimator.SetBool("Animate", true);
                break;
            case 6:
                scrollScreenAnimator.SetBool("Animate", false);
                break;
            default:
                break;
        }
        i++;
    }
}
