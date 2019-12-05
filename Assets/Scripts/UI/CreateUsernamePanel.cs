using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CreateUsernamePanel : GamePanel
{
    [SerializeField] Animator popupAnimator;
    [SerializeField] InputField nameInputField;
    [SerializeField] Button oKButton; //확인버튼

    Action CloseAction;

    public void OnClickOKButton()
    {
        string username = nameInputField.text;

        if (username !="")
        {
            //서버에 ID 요청하기
            oKButton.interactable = false;
            nameInputField.interactable = false;

            NetWork.Instance.GetServerID(username, 
            () => {
                Close();
            },
            () =>
            {
                //에러 팝업 띄워줘도 됨 이쯤에다
                oKButton.interactable = true;
                nameInputField.interactable = true;
                nameInputField.text = "";
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
