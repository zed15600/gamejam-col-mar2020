using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateManager : MonoBehaviour {

    public SpriteRenderer[] backgournd;
    public GameObject noiseLossPanel;
    public GameObject nightUI;
    public GameObject dayUI;
    public GameObject human;
    public Sprite[] daySprites;

    public void goodMorning() {
        StartCoroutine(wakeUp());
    }

    private IEnumerator wakeUp() {
        Animator transitionAnimator = GameObject.Find("SceneTransition").GetComponent<Animator>();
        transitionAnimator.SetBool("AnimateOut", true);
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.audioSource.clip = AudioManager.Instance.clipBackgroundDay;
        for (int i=0; i<daySprites.Length; i++) {
            backgournd[i].sprite = daySprites[i];
        }
        nightUI.SetActive(false);
        dayUI.SetActive(true);
        AudioManager.Instance.audioSource.Play();
        transitionAnimator.SetBool("AnimateOut", false);
        yield return new WaitForSeconds(1f);
        human.SetActive(true);
    }

    public IEnumerator lose() {
        CrossSceneInfo.gameResult = "Loss";
        yield return new WaitForSeconds(2);
        SceneTransitionManager.instance.transitScene("EndGame");
    }

    public IEnumerator win() {
        CrossSceneInfo.gameResult = "Win";
        yield return new WaitForSeconds(2);
        SceneTransitionManager.instance.transitScene("EndGame");
    }

    public void abortTrap() {
        SceneTransitionManager.instance.transitScene("MainMenu");
    }

    public void noiseWakeUp() {
        //TODO: change this for the wakeup scene
        noiseLossPanel.SetActive(true);
        StartCoroutine(lose());
    }
}
