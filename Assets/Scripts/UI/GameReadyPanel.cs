using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameReadyPanel : GamePanel
{
    [SerializeField] Animator logoAnimator;
    [SerializeField] Animator touchAnimator;
    [SerializeField] GameObject bestScoreObject;
    [SerializeField] Text bestScore;

    private void Start() {
        GameManager.Instance.LoadScore();
        bestScore.text = GameManager.Instance.bestScore.ToString();
    }
    public override void Close()
    {
        logoAnimator.SetTrigger("hide");
        touchAnimator.SetTrigger("hide");
        bestScoreObject.SetActive(false);
    }

    public override void Open()
    {
        // logoAnimator.SetTrigger("show");
        // touchAnimator.SetTrigger("show");
        // bestScoreObject.SetActive(true);
    }
}
