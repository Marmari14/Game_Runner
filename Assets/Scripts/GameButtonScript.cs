using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonScript : MonoBehaviour
{
    public void ReplayClick()
    {
        SceneManager.LoadScene("Game");
        SpawnObjectScript.isCollision = false;
        PlayerMove.isBoost = false;
    }

    public void MenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BuyClick()
    {
        if (PlayerMove.CoinCount >= 50)
        {
            PlayerMove.CoinCount -= 50;
            PlayerMove.isBoost = true;
        }
        else return;
    }
}
