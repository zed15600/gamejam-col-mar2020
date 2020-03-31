using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
