using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsShowListener
{
    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"Ad clicked: {placementId}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Ad failed to show: {placementId}, Error: {error}, Message: {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"Ad started: {placementId}");
    }

    private void Awake()
    {
        Debug.Log("Initializing Unity Ads");
        Advertisement.Initialize("5713131", true);
    }

    public void ShowRewardedAd()
    {
        Debug.Log("Showing Rewarded Ad");
        Advertisement.Show("Rewarded_Android", this);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        ShowResult result;
        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.COMPLETED:
                Debug.Log("Player watched the ad and completed it");
                //Award the player for watching the ad
                result = ShowResult.Finished;
                break;
            case UnityAdsShowCompletionState.SKIPPED:
                Debug.Log("Player skipped the ad");
                result = ShowResult.Skipped;
                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                Debug.Log("The ad did not finish due to an unknown error");
                result = ShowResult.Failed;
                break;
            default:
                Debug.Log("The ad did not finish due to an error");
                result = ShowResult.Failed;
                break;
        }
        HandleShowResult(result);
    }
    
    private void HandleShowResult(ShowResult result)
    {
        // Implementa la lógica para manejar el resultado aquí
        Debug.Log($"Resultado del anuncio: {result}");
    }
}