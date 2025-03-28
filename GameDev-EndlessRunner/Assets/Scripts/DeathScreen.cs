using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{

    public GameObject deathScreen;
    public Button restartButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathScreen.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDeathScreen()
    {
      
      deathScreen.SetActive(true);
        Time.timeScale = 0f;

    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");  

    }


}
