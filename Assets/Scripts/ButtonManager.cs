using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject PausedPanel;
    public GameObject GameController;

    public int paused = 0;

    public void PauseButton() {
        if (GameController.GetComponent<GameControl>().death == 0) {
            paused = 1;
            //PausedPanel.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
            PausedPanel.SetActive(true);
            PausedPanel.GetComponent<Image>().CrossFadeAlpha(0.8f, 0.15f, true);
        }
    }

    public void MenuButton() {
        SceneManager.LoadScene("Menu");
    }

    public void RestartButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeButton() {
        StartCoroutine(DelayedDeactivatePausedPanel());
    }

    IEnumerator DelayedDeactivatePausedPanel() {
        yield return new WaitForSeconds(0.2f);
        paused = 0;
        PausedPanel.SetActive(false);
    }

    public void Update() {
        if (Input.GetKey(KeyCode.Escape) && PausedPanel.activeSelf == false)
            PauseButton();
        else if(Input.GetKey(KeyCode.Escape) && PausedPanel.activeSelf == true)
            ResumeButton();
    }
}
