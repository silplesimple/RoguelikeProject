using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class RogueLikeCharacterController : MonoBehaviour
{
    // event 외부에서는 호출하지 못하게 막는다.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;
    public event Action<AttackSO> OnSkillEvent;

    protected float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected bool IsSkill { get; set; }

    protected CharacterStatsHandler Stats { get;private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
        HandleSkillDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
            return;

        if(_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        
        if(IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.attackSO);
        }
    }

    private void HandleSkillDelay()
    {
        if (Stats.CurrentStats.skillSO == null)
            return;

        if (_timeSinceLastAttack <= Stats.CurrentStats.skillSO.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsSkill && _timeSinceLastAttack > Stats.CurrentStats.skillSO.delay)
        {
            _timeSinceLastAttack = 0;
            CallSkillEvent();
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
    
    public void CallSkillEvent()
    {
        if (Stats.CurrentStats.skillSO == null)
            return;

        AttackSO skillSO = Stats.CurrentStats.skillSO;

        OnSkillEvent?.Invoke(skillSO);
    }
}
