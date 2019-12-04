using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CreateUsernamePanel : GamePanel
{
    [SerializeField] Animator popupAnimator;
    [SerializeField] InputField nameInputField;

    Action CloseAction;

    public void OnClickOKButton()
    {
        //서버에 ID 요청하기
        string username = nameInputField.text;
        if(username !="")
        {
            NetWork.Instance.GetServerID(username, () => {
                Close();
            });
        }
    }
    public override void Close()
    {
        popupAnimator.SetTrigger("hide");
    }
    public override void Open()
    {
        //popupAnimator.SetTrigger("show");
    }
    public void Open(Action didFinished)
    {
        gameObject.SetActive(true);
        popupAnimator.SetTrigger("show");
        CloseAction = didFinished;
    }

    public void Finish()
    {
        CloseAction();
        gameObject.SetActive(false);
    }
}
