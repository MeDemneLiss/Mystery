using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameManu;
    public GameObject heals;
    public GameObject opit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseGame) 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }
    public void Resume()
    {
        heals.SetActive(true);
        opit.SetActive(true);
        pauseGameManu.SetActive(false);
        Time.timeScale = 1.0f;
        PauseGame = false;
    }
    public void Pause()
    {
        heals.SetActive(false);
        opit.SetActive(false);
        pauseGameManu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }
    public void LoadManu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
