using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loadScreen,creditsPanel,volumePanel,volumeButton;
    void Start()
    {
        loadScreen.GetComponent<Animator>().Play("LoadScreenUnload");
        Invoke("LoadScreen", 0.55f);
    }
    void LoadScreen()
    {
        loadScreen.SetActive(false);
    }
    public void StartGame()
    {
        loadScreen.SetActive(true);
        loadScreen.GetComponent<Animator>().Play("LoadScreenAnimation");
        Invoke("StartGameAfterAnimation", 0.55f);
    }
    public void StartGameAfterAnimation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void loadCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }
    public void unloadCreditsPanel()
    {
        creditsPanel.GetComponent<Animator>().Play("CreditsPanelUnload");
        Invoke("unloadCreditsPanelAfterAnimation",0.35f);
    }
    void unloadCreditsPanelAfterAnimation()
    {
        creditsPanel.SetActive(false);
    }
    public void ShowVolumePanel()
    {
        volumePanel.SetActive(true);
        volumeButton.SetActive(false);
    }
    public void HideVolumePanel()
    {
        volumePanel.SetActive(false);
        volumeButton.SetActive(true);
    }
    public void YouTube()
    {
        Application.OpenURL("https://youtube.com/channel/UC8wnCdL-1yoasg45qVOoWKw");
    }
    public void Instagram()
    {
         Application.OpenURL("https://instagram.com/cadengame?igshid=9s6rffk452hm");
    }
    public void Discord()
    {
        Application.OpenURL("https://discord.gg/5gMjBPePmU");
    }
    public void Telegram()
    {
        Application.OpenURL("https://t.me/cadengames");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
