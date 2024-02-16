using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueLikeContactEnemyController : RogueLikeEnemyController
{
    [SerializeField] private AttackSO enemyAttackData;
    [SerializeField][Range(0f, 100f)] private float followRange;
    private bool _isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    private bool _isAttacking;
    private int collisionCount = 0;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 direction = Vector2.zero;
        float distanceToTarget = DistanceToTarget();

        if (!_isAttacking)
        {
            if (distanceToTarget < followRange)
            {
                direction = DirectionToTarget();

                if (distanceToTarget <= enemyAttackData.size && _timeSinceLastAttack >= enemyAttackData.delay)
                {
                    StartCoroutine(AttackAndWait());
                }
            }
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private IEnumerator AttackAndWait()
    {
        _isAttacking = true;
        _timeSinceLastAttack = 0f;

        // 여기에 실제 공격하는 동작 추가
        Debug.Log("적의 공격!");

        // 추가: 공격 이후의 추가 동작 추가

    

        yield return new WaitForSeconds(0.5f); // 0.5초 동안 대기

        _isAttacking = false;

        // 0.5초 후에 다시 따라오면서 공격하는 동작 시작
        StartCoroutine(FollowAndAttack());
    }

    private IEnumerator FollowAndAttack()
    {
        yield return new WaitForSeconds(0.5f); // 0.5초 동안 대기

       
        Debug.Log("다시 따라오며 공격!");

        _isAttacking = false;
    }

    private void Update()
    {
      
        _timeSinceLastAttack += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            collisionCount++;

            if (collisionCount >= 30)
            {
                DestroyEnemy();
            }
        }
    }
    private void DestroyEnemy()
    {
       
        Destroy(this.gameObject);
    }
}