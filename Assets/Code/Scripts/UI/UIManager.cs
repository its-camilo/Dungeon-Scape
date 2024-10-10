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
    
    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount.ToString() + "G";
    }

    private void Awake()
    {
        instance = this;
    }
}
