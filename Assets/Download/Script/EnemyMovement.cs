using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float CreateTime = 0.0f; // �����ǰ� �� �� ���ʰ� ��������
    public float speed = 0.05f; // ������ �̵��ϴ� �ӵ�
    public float moveTIme = 0.1f; // ���� ������ �����̱� �����ϴ� �ð�
    public bool canmove = false; // �����̴� �Ұ�
    public int rotateSpeed;

    public GameObject target; // �̵��� ��ġ ������ ������Ʈ

    private void Awake() // Start���� ����� ����
    {
        target = GameObject.FindGameObjectWithTag("Player"); // ������ ������� ���� Tag�� ������Ʈ�� target�� �־���
    }
    private void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        CreateTime += Time.deltaTime; // �����ǰ� �� ���� �ð��� ������
        if (CreateTime >= moveTIme) // ������ �ð��� ������ �� �ִ� �ð����� �������� canmove true
            canmove = true;



        if (canmove) // canmove = true
            transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed);
        //�� ������Ʈ�� ��ġ�� Vector2���� ��� �־� target.transform.position���� �̵���Ŵ �ӵ��� speed�� ���� ũ��� �̵�

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
