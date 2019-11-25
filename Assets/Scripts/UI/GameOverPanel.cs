using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : GamePanel
{
    [SerializeField] Animator popupAnimator;

    public override void Close()
    {
        popupAnimator.SetTrigger("hide");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 활성화된 씬의 이름을 가져와서 Load시킴
    }
    public override void Open()
    {
        popupAnimator.SetTrigger("show");
    }
}
