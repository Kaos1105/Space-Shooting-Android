using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Spawn : MonoBehaviour {

    // Use this for initialization
    
    private int score;
    public Text scoreText;
    //public Text restartText;
    public Text gameOverText;
    public Text live;
    private bool gameOver;
    //private bool restart;
    public GameObject []hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int lives;
    public GameObject player;
    public GameObject Shield;
    public GameObject restartButton;
    //public int nums;
    //public GameObject cloned;
    void Start () {
        lives = 3;
        gameOver = false;
        restartButton.SetActive(false);
        //restart = false;
        //restartText.text ="";
        gameOverText.text ="";
        score = 0;
        UpdateScore();
        live.text = "Lives: " + lives;
        StartCoroutine(SpawnWaves());
        //StartCoroutine(Respawn());
    }
	
	// Update is called once per frame
	void Update () {
        //if (restart)
        //{
        //    if (Input.GetButton("Fire1"))
        //    {
        //        SceneManager.LoadScene("1st");
        //    }
        //}
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver)
                {
                    //restartText.text = "Press 'R' for restart";
                    Debug.Log("gameOver");
                    restartButton.SetActive(true);
                    break;
                }
                //Debug.Log(i);
                GameObject hazard = hazards[Random.Range(0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        if (score % 50 == 0 && score > 0)
        {
            hazardCount += 1;
            Debug.Log(hazardCount);
            if (score % 200 == 0)
            {
                hazardCount += 3;
                Debug.Log("CoroutineStarted");
            }
           
        }
    }
    public void GameOver()
    {
        lives--;
        live.text = "Lives " + lives;
        gameOverText.text = "Game overrrr!";
        gameOver = true;
        GetComponent<AudioSource>().Play();
    }
    public void Dead()
    {
        Instantiate(Shield, new Vector3(0, 2, -8), Quaternion.identity);
        lives--;
        live.text = "Lives " + lives;
        StartCoroutine(Respawn());
    }
    public IEnumerator Respawn()
    { 
        yield return new WaitForSeconds(startWait);
        Instantiate(player, new Vector3(0, 2, -9), Quaternion.identity);
        //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        //for (var i = 0; i < gameObjects.Length; i++)
        //    Destroy(gameObjects[i]);
    }
    public void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene("1st");
    }
}
