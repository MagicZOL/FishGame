﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;

    [SerializeField] Fish fish;
    [SerializeField] GameObject pipes;

    [SerializeField] GamePanel gameReadPanel;
    [SerializeField] GamePanel gamePlayPanel;
    [SerializeField] GamePanel gameOverPanel;
    State state;

    public int score;

    public int bestScore;

    string gameId = "3382792";

    string placementId = "banner";

    string serverId;

    public static GameManager Instance;
    private void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
    }
    enum State
    {
        READY, PLAY, GAMEOVER
    }
    private void Start()
    {
        GameReady();

        Advertisement.Initialize(gameId, false);
        StartCoroutine(ShowBannerWhenReady());

        //플레이어의 서버 ID 확인
        serverId = PlayerPrefs.GetString("Id");

        if(serverId == "")
        {
            NetWork.Instance.GetServerID();
        }
    }

    IEnumerator ShowBannerWhenReady()
    {
        while(!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }
    private void Update()
    {
        switch (state)
        {
            case State.READY:
                if(Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;
            case State.PLAY:
                if (fish.IsDead) GameOver();
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void GameReady()
    {
        pipes.SetActive(false);
        state = State.READY;
        fish.SetKinematic(true);
    }
    void GameStart()
    {
        state = State.PLAY;

        //중력영향을 받게 한다
        fish.SetKinematic(false);

        pipes.SetActive(true);

        gamePlayPanel.Open();
        gameReadPanel.Close();
    }

    void GameOver()
    {
        state = State.GAMEOVER;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }

        SaveScore();

        //GameOVer 패널 활성화
        gamePlayPanel.Close();
        gameOverPanel.Open();

    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void OnClickQuit()
    {
        gameOverPanel.Close();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SaveScore()
    {
        if(bestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }

    public void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
    }
}
