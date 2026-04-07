using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

   [Header("UI Settings")]
   [SerializeField] private GameObject pauseMenu;
   [SerializeField] private bool isGamePaused;
   [SerializeField] private GameObject gameOverPanel;

   void Awake()
   {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
   }

   void Update()
   {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(isGamePaused)
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
       pauseMenu.SetActive(false);
       Time.timeScale = 1f;
        isGamePaused = false;
   }

   void Pause()
   {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
   }

   public void Restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
   }

   public void Menu()
   {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
   }

   public void GameOver()
   {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
   }
}