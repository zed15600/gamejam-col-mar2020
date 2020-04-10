using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {

    public static SceneTransitionManager instance;

    private void Awake() {
        DontDestroyOnLoad(this);
        if (SceneTransitionManager.instance != null) {
            Destroy(this);
        } else {
            SceneTransitionManager.instance = this;
        }
    }

    public void transitScene(string sceneName) {
        StartCoroutine(transit(sceneName));
    }

    private IEnumerator transit(string sceneName) {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetBool("AnimateOut", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
