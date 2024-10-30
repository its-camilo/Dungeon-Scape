using UnityEngine;

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
    
    private void Awake()
    {
        instance = this;
    }
}
