using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        StartCoroutine(WaitForSoundAndLoadScene(1));
    }
    
    public void MainMenuButton()
    {
        StartCoroutine(WaitForSoundAndLoadScene(0));
    }

    private IEnumerator WaitForSoundAndLoadScene(int sceneIndex)
    {
        AudioManager.Instance.PlayMenuSelection();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void QuitButton()
    {
        AudioManager.Instance.PlayMenuSelection();
        Application.Quit();
    }
}