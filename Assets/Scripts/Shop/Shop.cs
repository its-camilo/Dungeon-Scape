using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentItem;
    public int currentItemCost;
    
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            
            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }
            
            shopPanel.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0: 
                UIManager.Instance.UpdateShopSelection(54);
                currentItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-53);
                currentItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-162);
                currentItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (player.diamonds >= currentItemCost)
        {
            if (currentItem == 0)
            {
                GameManager.Instance.HasFlameSword = true;
            }
            
            else if (currentItem == 1)
            {
                GameManager.Instance.HasBootsOfFlight = true;
            }
            
            if (currentItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            
            AudioManager.Instance.PlayExtrasSound(0);
            player.diamonds -= currentItemCost;
            UIManager.Instance.UpdateGemCount(player.diamonds);
            shopPanel.SetActive(false);
        }
        
        else
        {
            Debug.Log("You do not have enough gems. Closing shop.");
            shopPanel.SetActive(false);
        }
    }
}
