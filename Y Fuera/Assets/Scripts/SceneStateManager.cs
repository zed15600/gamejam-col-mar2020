using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateManager : MonoBehaviour {

    public Sprite[] daySprites;
    public SpriteRenderer[] backgournd;
    public GameObject nightUI;
    public GameObject human;

    public void goodMorning() {
        for (int i=0; i<daySprites.Length; i++) {
            backgournd[i].sprite = daySprites[i];
        }
        nightUI.SetActive(false);
        human.SetActive(true);
    }
}
