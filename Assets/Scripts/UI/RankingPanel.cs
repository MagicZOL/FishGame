using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingPanel : GamePanel
{
    [SerializeField] Animator popupAnimator;

    public override void Close()
    {
        popupAnimator.SetTrigger("hide");
    }

    public override void Open()
    {
        popupAnimator.SetTrigger("show");
    }
}
