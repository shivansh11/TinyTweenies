﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsForMenu : MonoBehaviour {

    public GameObject Blackness;
    public GameObject ExitPanel;
    public GameObject RatePanel;
    public GameObject TutPanel;
    public GameObject InvitePanel;
    public GameObject NoInternerText;
    public GameObject Loading;
    public GameObject RewardPanel;
    AsyncOperation operation;

    public void Start() {
        if (!PlayerPrefs.HasKey("Tut")) {
            PlayerPrefs.SetInt("Tut", 1);
            TutUp();
        }

        if (!PlayerPrefs.HasKey("Rated")) {
            PlayerPrefs.SetInt("Rated", 1);
        }

        if (PlayerPrefs.GetInt("Rated") != 0) {
            if (PlayerPrefs.GetInt("Rated") == 10)
                RateUp();
            else
                PlayerPrefs.SetInt("Rated", PlayerPrefs.GetInt("Rated") + 1);
        }
    }

    public void Play() {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync() {
        Blackness.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
        Blackness.SetActive(true);
        Blackness.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
        yield return new WaitForSeconds(1f);
        Loading.SetActive(true);
        operation = SceneManager.LoadSceneAsync("TheMain");
    }

    public void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            if (!ExitPanel.activeSelf)
                ExitUp();
            else
                ExitDown();
        }           
    }

    public void RateUp() {
        RatePanel.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
        RatePanel.SetActive(true);
        RatePanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
    }

    public void RateDown() {
        PlayerPrefs.SetInt("Rated", 0);
        RatePanel.SetActive(false);
    }

    public void RateYes() {
        Application.OpenURL("market://details?id=com.loyalsheep.TinyTweenies");
        RateDown();
    }

    public void ExitUp() {
        ExitPanel.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
        ExitPanel.SetActive(true);
        ExitPanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
    }

    public void ExitDown() {
        ExitPanel.SetActive(false);
    }

    public void TutUp() {
        TutPanel.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
        TutPanel.SetActive(true);
        TutPanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
    }

    public void TutDown() {
        TutPanel.SetActive(false);
    }

    public void Exit() {
        Application.Quit();
    }

    public void Invite() {
        if (Application.internetReachability != NetworkReachability.NotReachable) {
            InvitePanel.GetComponent<Image>().CrossFadeAlpha(0f, 0f, true);
            InvitePanel.SetActive(true);
            InvitePanel.GetComponent<Image>().CrossFadeAlpha(1f, 0.5f, true);
        } else {
            NoInternerText.GetComponent<TextFader>().Fade();
        }
    }

    public void RewardDown() {
        RewardPanel.SetActive(false);
    }

    public void Leaderboard() {
        PlayGamesScript.ShowLeaderboard();
    }
}
