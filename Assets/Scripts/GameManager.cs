using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject spawnObjectGround;
    public GameObject spawnObjectAir;
    public GameObject spawnObjectMobile;
    public GameObject spawnObjectCoin;
    public GameObject spawnObjectBoost;
    public GameObject[] spawnPointsEnemy;
    public GameObject[] spawnPointsCoin;
    float timerForEnemy;
    float timeBetweenSpawnEnemy;
    float timeBetweenSpawnCoin;
    float timerForCoin;
    float timerForBoost;
    
    bool isCollision;

    public float speedMultiplier;

    public Text ScoreUI;
    public Text CoinUI;
    float score;
    float highScore;
    // Start is called before the first frame update
    void Start()
    {
        isCollision = false;
        timeBetweenSpawnEnemy = 3f;
        timeBetweenSpawnCoin = 2f;
        PlayerMove.CoinCount = PlayerPrefs.GetInt("Coin", PlayerMove.CoinCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollision)
        {
            if (PlayerMove.isBoost) 
            {
                score += 20;
                PlayerMove.isBoost = false;
            }
            ScoreUI.text = score.ToString("F2");
            speedMultiplier += Time.deltaTime * 0.1f;
            score += Time.deltaTime * 0.8f;
            highScore = score;


            if (PlayerPrefs.GetFloat("Highscore") < highScore)
                PlayerPrefs.SetFloat("Highscore", highScore);
            CoinUI.text = PlayerMove.CoinCount.ToString();

            timerForEnemy += Time.deltaTime;
            timerForCoin += Time.deltaTime;
            timerForBoost += Time.deltaTime;
            int timeBetweenSpawnBoost = Random.Range(15, 31);

            if (timerForEnemy > timeBetweenSpawnEnemy) SpawnEnemy(); 
            if (timerForCoin > timeBetweenSpawnCoin) SpawnCoin();
            if (timerForBoost > timeBetweenSpawnBoost) SpawnBoost();


            if (timeBetweenSpawnEnemy > 1.5)
                timeBetweenSpawnEnemy -= 0.0001f;
            gameOver.SetActive(false);
        }
        else
        {
            gameOver.SetActive(true);
            BackgroundScroller.scrollSpeed = 0;
            PlayerPrefs.SetInt("Coin", PlayerMove.CoinCount);
            PlayerPrefs.Save();
        }

        if (SpawnObjectScript.isCollision)
            isCollision = true;
    }

    private void SpawnEnemy()
    {
        timerForEnemy = 0;
        int randNum = Random.Range(0, 2);
        if (randNum == 0)
            Instantiate(spawnObjectGround, spawnPointsEnemy[randNum].transform.position, Quaternion.identity);
        else
        {
            int num = Random.Range(0, 2);
            if (num == 0)
                Instantiate(spawnObjectAir, spawnPointsEnemy[randNum].transform.position, Quaternion.identity);
            else Instantiate(spawnObjectMobile, spawnPointsEnemy[randNum].transform.position, Quaternion.identity);
        }
    }

    private void SpawnCoin()
    {
        timerForCoin = 0;
        int randNum = Random.Range(0, 2);
        Instantiate(spawnObjectCoin, spawnPointsCoin[randNum].transform.position, Quaternion.identity);
    }

    private void SpawnBoost()
    {
        timerForBoost = 0;
        int randNum = Random.Range(0, 2);
        Instantiate(spawnObjectBoost, spawnPointsCoin[randNum].transform.position, Quaternion.identity);
    }
}
