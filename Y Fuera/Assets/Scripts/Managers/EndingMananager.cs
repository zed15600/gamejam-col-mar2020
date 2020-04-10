using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingMananager : MonoBehaviour
{
    public Image bgImage;
    public Sprite loseBG;

    // Start is called before the first frame update
    void Start()
    {
        if (CrossSceneInfo.gameResult == "Loss") {
            bgImage.sprite = loseBG;
        }
    }

    public void goToMainMenu() {
        SceneTransitionManager.instance.transitScene("MainMenu");
    }
}
