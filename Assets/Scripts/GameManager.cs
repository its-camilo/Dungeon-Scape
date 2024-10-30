using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game Manager is null");
            }
            return instance;
        }
    }
    
    public bool HasKeyToCastle { get; set; }
    public bool HasFlameSword { get; set; }
    public bool HasBootsOfFlight { get; set; }
    public GameObject winPanel;
    
    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        winPanel.SetActive(false);
    }

    public void Win()
    {
        winPanel.SetActive(true);
        AudioManager.Instance.PlayExtrasSound(1);
    }
}
