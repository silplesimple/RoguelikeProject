using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public int damage = 10; 

    private Transform player;
    private bool isAttacking = false;

    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
       
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer < detectionRange)
        {
          
            transform.LookAt(player);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

          
            if (distanceToPlayer < attackRange)
            {
                
                Attack();
            }
        }
    }

    void Attack()
    {
        if (!isAttacking)
        {
            Debug.Log("공격!");

          
            //player.GetComponent<PlayerHealth>().TakeDamage(damage);

           
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
       
        isAttacking = true;
        yield return new WaitForSeconds(1f); // 1초간 대기

   
        isAttacking = false;
    }
}