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

        // ���⿡ ���� �����ϴ� ���� �߰�
        Debug.Log("���� ����!");

        // �߰�: ���� ������ �߰� ���� �߰�

    

        yield return new WaitForSeconds(0.5f); // 0.5�� ���� ���

        _isAttacking = false;

        // 0.5�� �Ŀ� �ٽ� ������鼭 �����ϴ� ���� ����
        StartCoroutine(FollowAndAttack());
    }

    private IEnumerator FollowAndAttack()
    {
        yield return new WaitForSeconds(0.5f); // 0.5�� ���� ���

       
        Debug.Log("�ٽ� ������� ����!");

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