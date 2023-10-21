using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //game over
    HP pHP;
    HP cHP;

    //HPs
    int playerHP = 100;
    int cpuHP = 100;

    //timer
    float currentTime;
    public float startingTime = 60f; //how long I want the timer to go for
    [SerializeField] Text countdownText;

    //points
    // float currentPoints;
    public int points;
    [SerializeField] Text scoreText;
    int highScore;
    [SerializeField] Text highscoreText;

    // pause menu


    //enemy spawner
    public List<GameObject> enemies;
    public int numOfVirus;
    public int offset = 30;
    public float spawnTimeEnemy = 0f;
    public float timerE = 0f; //timer Enemies

    //powerUp Spawner
    public List<GameObject> powerUps;
    public int numOfPowerUps;
    public float spawnTimePowerUp = 0f;
    public float timerP = 0f; //timer PowerUps

    public float spawnTimeCoin = 0f;
    public float timerC = 0f;
    public GameObject coin;


    public float spawnTimeHourglass = 0f;
    public float timerH = 0f;
    public GameObject hourglass;
       
    //was for another method of enemy generation
    //   [SerializeField]
   //private GameObject virusPrefab;
    //[SerializeField]
    //private float virusInterval = 3.5f; //decide the range between when enemies should spawn


    // Start is called before the first frame update
    void Start()
{
        currentTime = startingTime;
        points= 0;
        pHP = GameObject.Find("Player").GetComponent<HP>();
        cHP = GameObject.Find("CPU").GetComponent<HP>();
        playerHP = pHP.GetHP();
        cpuHP = cHP.GetHP();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = highScore.ToString();
        //StartCoroutine(spawnEnemy(virusInterval, virusPrefab));
        EnemySpawner();
}

// Update is called once per frame
void Update()
{
        currentTime -= 1 * Time.deltaTime; 
        countdownText.text = currentTime.ToString();
                
       // currentPoints = points;
        scoreText.text = points.ToString();
        if (highScore < points) { highScore = points; }

        playerHP = pHP.GetHP();
        cpuHP = cHP.GetHP();

        if (playerHP <= 0 || cpuHP <= 0)
        {
            gameLost();
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            gameWon(playerHP, cpuHP); // End game
        }

     
       

        if (spawnTimePowerUp == 0f)
        {
            spawnTimePowerUp = Random.Range(10f, 20f); //this chooses how often the hearts spawn
        }
      
        timerP += Time.deltaTime;
           if (timerP >= spawnTimePowerUp)
           {
               PowerUpSpawner();
               timerP = 0f;
               spawnTimePowerUp = 0f;
          }


        if (spawnTimeCoin == 0f)
        {
            spawnTimeCoin = Random.Range(1f, 6f); //this chooses how often the coins spawn
        }

        timerC += Time.deltaTime;
        if (timerC >= spawnTimeCoin)
        {
            CoinSpawner();
            timerC = 0f;
            spawnTimeCoin = 0f;
        }

        if (spawnTimeHourglass == 0f)
        {
            spawnTimeHourglass = Random.Range(13f, 25f); //this chooses how often the hourglass spawn
        }
        timerH += Time.deltaTime;
        if (timerH >= spawnTimeHourglass)
        {
            TimeSpawner();
            timerH = 0f;
            spawnTimeHourglass = 0f;
        }

    }

    void FixedUpdate()
    {
        if (spawnTimeEnemy == 0f)
        {
            spawnTimeEnemy = Random.Range(2f, 3f); //this chooses how often the enemies spawn
        }


        timerE += Time.deltaTime;
            if (timerE >= spawnTimeEnemy)
            {
                EnemySpawner();
                timerE = 0f;
                spawnTimeEnemy = 0f;
            }
       
    }

    void EnemySpawner()
    {
        int count1 = 0;
        numOfVirus = Random.Range(1, 5); //this chooses how many enemies spawn at any given time

        while(count1 < numOfVirus)
        {
            int ranNum1 = Random.Range(0, enemies.Count); //selects a random enemy type (there are only viruses for now)

            Vector2 ranSpawn1 = new Vector2(Random.Range(-70f, 60f), Random.Range(-30f , 40f)); //sets the spawn points and makes sure its off screen w/offset

            // if (ranSpawn1[0] > -70f -offset && ranSpawn1[0] < 60f + offset && ranSpawn1[1] > -30f - offset && ranSpawn1[1] < 40f + offset) 
            if (ranSpawn1[0] > -40f && ranSpawn1[0] < 30f && ranSpawn1[1] > -20f && ranSpawn1[1] < 30f) //make this the CPU so it cant spawn in it
            { }
            else
            {
                /* GameObject clone1 = ObjectPool.SharedInstance.GetPooledObject();
                 if (clone1 != null)
                 {
                    // clone1.transform.position = turret.transform.position;
                     //clone1.transform.rotation = turret.transform.rotation;
                     clone1.SetActive(true);
                 }*/
                GameObject clone1 = Instantiate(enemies[ranNum1], ranSpawn1, Quaternion.identity);
                clone1.name = enemies[ranNum1].name;
                count1 ++;
            }
            
        }
    }

    void PowerUpSpawner()
    {
        int count2 = 0;
        numOfPowerUps = 1;

        while (count2 < numOfPowerUps)
        {
            int ranNum2 = Random.Range(0, powerUps.Count); //selects a powerup  type (there are only health for now)

            Vector2 ranSpawn2 = new Vector2(Random.Range(-70f, 60f), Random.Range(-30f, 40f)); //sets the spawn points and makes sure its not in cpu

            if (ranSpawn2[0] > -10f && ranSpawn2[0] < 0f && ranSpawn2[1] > 0f && ranSpawn2[1] < 10f) //make this the CPU so it cant spawn in it
            { }
            else
            {
                GameObject clone2 = Instantiate(powerUps[ranNum2], ranSpawn2, Quaternion.identity);
                clone2.name = powerUps[ranNum2].name;
                count2++;
            }


        }
    }

    void CoinSpawner()
    {
        int count3 = 0;
        int coins = 1; 
            
        while (count3 < coins)
        {
             //selects a powerup  type (there are only health for now)

            Vector2 ranSpawn3 = new Vector2(Random.Range(-70f, 60f), Random.Range(-30f, 40f)); //sets the spawn points and makes sure its not in cpu

            if (ranSpawn3[0] > -10f && ranSpawn3[0] < 0f && ranSpawn3[1] > 0f && ranSpawn3[1] < 10f) //make this the CPU so it cant spawn in it
            { }
            else
            {
                GameObject clone3 = Instantiate(coin, ranSpawn3, Quaternion.identity);
                clone3.name = coin.name;
                count3++;
            }


        }
    }

    void TimeSpawner()
    {
        int count4 = 0;
        int time = 1;

        while (count4 < time)
        {
            //selects a powerup  type (there are only health for now)

            Vector2 ranSpawn4 = new Vector2(Random.Range(-70f, 60f), Random.Range(-30f, 40f)); //sets the spawn points and makes sure its not in cpu

            if (ranSpawn4[0] > -10f && ranSpawn4[0] < 0f && ranSpawn4[1] > 0f && ranSpawn4[1] < 10f) //make this the CPU so it cant spawn in it
            { }
            else
            {
                GameObject clone4 = Instantiate(hourglass, ranSpawn4, Quaternion.identity);
                clone4.name = hourglass.name;
                count4++;
            }


        }
    }

    public void AddPoints(int addedPoints)
    {
        points += addedPoints;
        Debug.Log("points is " + points);
    }


    public void gameLost()
    {
        SceneManager.LoadScene("Game Over");
        FindObjectOfType<AudioManagement>().Stop("Hover");
        SetHighscore();
        SetScore();
    }

    public void gameWon(int pHP, int cHP)
    {
       
        SceneManager.LoadScene("Game Over");
        FindObjectOfType<AudioManagement>().Stop("Hover");
        addScoreBonus(pHP, cHP);
        SetHighscore();
        SetScore();
    }

    public int addScoreBonus(int pHP, int cHP)
    {
        //get hp of cpu and player
        //count HP left for each, each pHP is 100, each cHP is 500

        pHP *= 100;
        cHP *= 500;

        //add values to currentPoints
        points += (pHP + cHP);

        //return points
        Debug.Log("You have "+points);
        return points;
    }

    public void SetHighscore()
    {
        if (points > highScore)
        {
            PlayerPrefs.SetInt("HighScore", points);
            PlayerPrefs.Save();
        }
    }

    public void SetScore()
    {
        PlayerPrefs.SetInt("Score", points);
        PlayerPrefs.Save();
    }

    public void addToTimer(float time)
    {
        currentTime+= time;
    }

    // this was another way of having an enemy spawner.
    // private IEnumerator spawnEnemy(float interval, GameObject enemy)
    // {
    //    yield return new WaitForSeconds(interval);
    //    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-137f, 97), Random.Range(34, -28f), 0), Quaternion.identity);
    //    StartCoroutine(spawnEnemy(interval, enemy));
    //}





}
