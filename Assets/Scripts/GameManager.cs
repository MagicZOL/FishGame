using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Fish fish;
    [SerializeField] GameObject pipes;

    State state;

    int score;

    enum State
    {
        READY, PLAY, GAMEOVER
    }
    private void Start()
    {
        pipes.SetActive(false);
        state = State.READY;
        fish.SetKinematic(true);
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
                if (Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 활성화된 씬의 이름을 가져와서 Load시킴
                }
                break;
        }
    }

    void GameStart()
    {
        state = State.PLAY;

        //중력영향을 받게 한다
        fish.SetKinematic(false);

        pipes.SetActive(true);
    }

    void GameOver()
    {
        state = State.GAMEOVER;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
