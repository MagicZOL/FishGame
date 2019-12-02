using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameOverPanel : GamePanel, IUnityAdsListener
{
    [SerializeField] Animator popupAnimator;
    [SerializeField] Button adsButton;

     [SerializeField] Text resultScoreText;
    [SerializeField] Text MaxScoreText;
    
#if Unity_ANDROID //유니티 안드로이일경우만 아래코드 실행, 안드로이드가 아니면 코드를 지움
    string gameId = "3382792";
#elif Unity_IOS
    string gameId = "3382793";
#endif

    string gameId = "3382792";

    string myPlacmentId = "rewardedVideo";

    private void Start() {
        adsButton.interactable = Advertisement.IsReady(myPlacmentId);

        Advertisement.AddListener(this);
    }

    public void ShowRewardedViedeo()
    {
        Advertisement.Show(myPlacmentId);
    }
    public override void Close()
    {
        popupAnimator.SetTrigger("hide");
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 활성화된 씬의 이름을 가져와서 Load시킴
    }
    public override void Open()
    {
        popupAnimator.SetTrigger("show");
    }

    public void OnUnityAdsReady(string placementId)
    {
        if(placementId == myPlacmentId)
        {
            adsButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("OnUnityAdsDidError : " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("" + placementId);
    }

    //광고가 끝났을때
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("OnUnityAdsDidFinish : " + placementId + " " + showResult);
    }
}
