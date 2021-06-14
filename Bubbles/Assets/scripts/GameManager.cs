using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gm;
    public GameObject mainPanel, gameOverPanel, pausePanel,loadScreen,tutorialText,advertisePanel,advertiseTimerBar;
    public Text pointsText, scoreText,highScoreText;
    public Player player;
    public int points;
    public float advertiseTimer;
    public bool firstTime,gameOver,revived;
    
    void Awake()
    {
        if(!gm)
        {
            gm = this.gameObject.GetComponent<GameManager>();
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        points = 0;
        Invoke("LoadScreen", 0.55f);
        if (PlayerPrefsManager.GetFirstTime() == 0)
        {
            firstTime = true;
            PlayerPrefsManager.SetFirstTime(1);
        }
        else
        {
            firstTime = false;
        }
        if (firstTime)
        {
            tutorialText.SetActive(true);
        }
    }

    // Update is called once per frame
    
    void Update()
    {
        if(player.dead&&!gameOver)
        {
            player.speed = 0f;
            gameOver = true;
            Invoke("GameOver",0.5f); 
        }
        
        advertiseTimerBar.transform.localScale = new Vector3(advertiseTimer / 5f, 1f, 1f);
    }
    void LateUpdate()
    {
        pointsText.text = ":"+points.ToString();
        if(points>PlayerPrefsManager.GetHighScore())
        {
            PlayerPrefsManager.SetHighScore(points);
        }
    }
    public void GameOver()
    {
       
        
        scoreText.text = "Score:" + points.ToString();
        highScoreText.text = "HighScore:" + PlayerPrefsManager.GetHighScore();
        mainPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        
    }
    public void ShowAdvertise()
    {
        advertisePanel.SetActive(false);
        mainPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        player.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        player.dead = false;
        player.shielded = true;
        gameOver = false;
        player.speed = 5f;
    }
    public void DontShowAdvertise()
    {
        advertisePanel.SetActive(false);
    }
    public void Pause()
    {
        
        mainPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void Resume()
    {
        
        pausePanel.transform.GetChild(0).GetComponent<Animator>().Play("PausePanelResume");
        Invoke("ResumeGameAfterAnimation",0.5f);
    }
    public void Restart()
    {
        gameOverPanel.GetComponent<Animator>().Play("GameOverRestart");
        loadScreen.SetActive(true);
        loadScreen.GetComponent<Animator>().Play("LoadScreenAnimation");
        Invoke("RestartAfterAnimation", 0.55f);
    }
    
    public void GoToMainMenu()
    {
        loadScreen.SetActive(true);
        loadScreen.GetComponent<Animator>().Play("LoadScreenAnimation");
        Invoke("GoToMenuAfterAnimation", 0.55f);
    }
    public void GoToMenuAfterAnimation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void ResumeGameAfterAnimation()
    {
        mainPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    void RestartAfterAnimation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void LoadScreen()
    {
        loadScreen.SetActive(false);
    }
    
}
