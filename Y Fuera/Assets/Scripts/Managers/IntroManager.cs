using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    public Image bgImage;
    public Sprite bg2;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(changeSprite());
    }

    public IEnumerator changeSprite () {
        yield return new WaitForSeconds(5f);
        bgImage.sprite = bg2;
        yield return new WaitForSeconds(5f);
        SceneTransitionManager.instance.transitScene("Corridor");
    }
}
