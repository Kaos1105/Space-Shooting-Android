using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    // Use this for initialization
    public GameObject explosion;
    public GameObject powerUP;
    public GameObject playerexplosion;
    public int lifetime;
    public int scoreValue;
    private Spawn gameController;
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Spawn>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUP"))
        //{
        //    return;
        //}
        //if (other.CompareTag("Shield"))
        //{
        //    goto Finish;
        //}
        //if (explosion != null)
        //{
        //    Instantiate(explosion, transform.position, transform.rotation);
        //    if (Random.value >= 0.95)
        //        Instantiate(powerUP, transform.position, transform.rotation);
        //}
        //if (other.CompareTag("Player"))
        //{
        //    Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
        //    gameController.GameOver();
        //    gameController.StartCoroutine(gameController.Respawn());
        //    Debug.Log("Respawn");
        //    if (gameController.lives > 0)
        //        gameController.Dead();
        //    else gameController.GameOver();
        //}
        switch (other.tag)
        {
            case "Boundary":
            case "Enemy":
            case "PowerUP":
                return;
            case "Player":
                Debug.Log("Player");
                Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
                if (gameController.lives > 1)
                    gameController.Dead();
                else gameController.GameOver();
                break;
            case "Shield":
                Debug.Log("Shield");
                goto Finish;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if ((Random.value >= 0.8)&&(Time.time%2==0))
                Instantiate(powerUP, transform.position, transform.rotation);
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    Finish:
        {
            Destroy(gameObject);
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                if ((Random.value >= 0.95))
                    Instantiate(powerUP, transform.position, transform.rotation);
            }
        }
    }
}
