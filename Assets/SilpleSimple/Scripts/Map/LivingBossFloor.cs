using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingBossFloor : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("���� �׾���!");
            //MapManger���� ���ε�
        }
    }
}
