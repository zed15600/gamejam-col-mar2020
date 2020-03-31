using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour {

    public Sprite[] daySprites;
    public SpriteRenderer[] backgournd;
    public GameObject nightUI;
    public GameObject dayUI;
    public GameObject human;

    public void goodMorning() {
        AudioManager.Instance.audioSource.clip = AudioManager.Instance.clipBackgroundDay;
        for (int i=0; i<daySprites.Length; i++) {
            backgournd[i].sprite = daySprites[i];
        }
        nightUI.SetActive(false);
        dayUI.SetActive(true);
        human.SetActive(true);
        AudioManager.Instance.audioSource.Play();
    }

    public IEnumerator loser() {
        CrossSceneInfo.gameResult = "Loss";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
    }

    public IEnumerator win() {
        CrossSceneInfo.gameResult = "Win";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
    }

    public void abortTrap() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
