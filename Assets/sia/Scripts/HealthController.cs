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

   

    void OnCollisionEnter2D(Collision2D other)
    {                       //Case of Touch
        if (other.gameObject.tag == "Monster")
        {

            Hurt();
        }
       


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            Heal(other);
        }
    }
    void Hurt()
    {
        if (rateOfHit < Time.time)
        {
            rateOfHit = Time.time + cooldownHit;
            life[qtdLife - 1].SetActive(false);
            qtdLife -= 1;
        }

        if (qtdLife <= 0)
        {
            GameManager.instance.GameClear = false;
            if(!GameManager.instance.GameClear)
            SceneManager.LoadScene("GameOverScene");
        }
    }
    void Heal(Collider2D otherCollider)
    {
        Debug.Log("힐!");

        // 아이템 제거
        Destroy(otherCollider.gameObject); // other는 충돌한 아이템을 나타냅니다.

        if (qtdLife < life.Length)
        {
            life[qtdLife].SetActive(true);
            qtdLife += 1;
        }
    }


}