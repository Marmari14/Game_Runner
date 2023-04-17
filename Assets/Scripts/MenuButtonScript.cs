using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    public GameObject panelExit;
    public GameObject panelMenu;
    public GameObject panelRecords;
    public Text highScoreUI;

    private void Start()
    {
        panelExit.SetActive(false);
        panelRecords.SetActive(false);
        panelMenu.SetActive(true);
    }
    public void PlayClick()
    {
        SceneManager.LoadScene("Game");
        SpawnObjectScript.isCollision = false;
    }

    public void CloseClick()
    {
        panelMenu.SetActive(false);
        panelExit.SetActive(true);
    }

    public void YesExitClick()
    {
        Application.Quit();
    }

    public void NoExitClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RecordsClick()
    {
        panelMenu.SetActive(false);
        highScoreUI.text = PlayerPrefs.GetFloat("Highscore").ToString("F2");
        panelRecords.SetActive(true);
    }
}
