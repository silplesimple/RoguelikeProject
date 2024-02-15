using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    public float cooldownHit;
    private float rateOfHit;
    private GameObject[] life;
    private int qtdLife;

    void Start()
    {
        rateOfHit = Time.time;
        life = GameObject.FindGameObjectsWithTag("Life");
        qtdLife = life.Length;
    }

    void OnTriggerEnter2D(Collider2D other)
    {                           //Case of Bullet
        if (other.tag == "Monster")
        {

            Hurt();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {                       //Case of Touch
        if (other.gameObject.tag == "Monster")
        {

            Hurt();
        }
    }

    void Hurt()
    {
        if (rateOfHit < Time.time)
        {
            rateOfHit = Time.time+ cooldownHit;
            Destroy(life[qtdLife - 1]);
            qtdLife -= 1;
          
        }

        if (qtdLife <= 0)
        {
            SceneManager.LoadScene("GameOverScene");

        }
    }



}