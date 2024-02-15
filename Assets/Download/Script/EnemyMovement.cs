using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float CreateTime = 0.0f; // 생성되고 난 후 몇초가 지났는지
    public float speed = 0.05f; // 점으로 이동하는 속도
    public float moveTIme = 0.1f; // 작은 원들이 움직이기 시작하는 시간
    public bool canmove = false; // 움직이는 불값
    public int rotateSpeed;

    public GameObject target; // 이동할 위치 가져올 오브젝트

    private void Awake() // Start여도 상관은 없음
    {
        target = GameObject.FindGameObjectWithTag("Player"); // 게임이 실행되자 마자 Tag로 오브젝트를 target에 넣어줌
    }
    private void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        CreateTime += Time.deltaTime; // 생성되고 난 후의 시간을 더해줌
        if (CreateTime >= moveTIme) // 생성된 시간이 움직일 수 있는 시간보다 많아지면 canmove true
            canmove = true;



        if (canmove) // canmove = true
            transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed);
        //이 오브젝트의 위치에 Vector2값을 계속 주어 target.transform.position으로 이동시킴 속도는 speed의 값의 크기로 이동

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
