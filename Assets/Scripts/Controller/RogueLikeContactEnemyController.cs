using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueLikeContactEnemyController : RogueLikeEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange;
    [SerializeField] private AttackSO enemyAttackData;
    private bool _isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    private float _timeSinceLastAttack;

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 direction = Vector2.zero;
        float distanceToTarget = DistanceToTarget();

        if (distanceToTarget < followRange)
        {
            direction = DirectionToTarget();

            if (distanceToTarget <= enemyAttackData.size && _timeSinceLastAttack >= enemyAttackData.delay)
            {
                Attack();
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

    private void Attack()
    {
 
        _timeSinceLastAttack = 0f;

      
        HealthSystem playerHealth = ClosestTarget.GetComponent<HealthSystem>();
        if (playerHealth != null)
        {
            playerHealth.ChangeHealth(-enemyAttackData.power);
        }

        // 여기에 실제 공격하는 동작 추가
        Debug.Log("적의 공격!");

        // 추가: 공격 이후의 추가 동작 추가
    }

    private void Update()
    {
        // 공격 쿨다운 시간 업데이트
        _timeSinceLastAttack += Time.deltaTime;
    }
}