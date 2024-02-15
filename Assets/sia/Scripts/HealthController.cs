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
            SceneManager.LoadScene("GameOverScene");
        }
    }
    void Heal(Collision2D otherCollision)
    {
        Debug.Log("��!");

        // ������ ����
        Destroy(otherCollision.gameObject); // other�� �浹�� �������� ��Ÿ���ϴ�.

        if (qtdLife < life.Length)
        {
            life[qtdLife].SetActive(true);
            qtdLife += 1;
        }
    }


}