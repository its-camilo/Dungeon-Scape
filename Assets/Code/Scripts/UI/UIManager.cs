using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("UIManager is null");
            }

            return instance;
        }
    }
    
    public TextMeshProUGUI playerGemCountText;
    public Image selectionImage;
    public TextMeshProUGUI gemCountText;
    public Image[] healthBars;
    
    private void Awake()
    {
        instance = this;
    }
    
    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount.ToString() + "G";
    }
    
    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
    
    public void UpdateGemCount(int count)
    {
        gemCountText.text = count.ToString() + "G";
    }
    
    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }
}
