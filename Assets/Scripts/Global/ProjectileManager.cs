using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;

    [SerializeField] private GameObject testObj;

    public static ProjectileManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = Instantiate(testObj);

        obj.transform.position = startPosition;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }
}
