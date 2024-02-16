using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEmemyFloor : MonoBehaviour
{    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("몬스터 죽었다!!");
            MapManager.instance.livingEnemyIndex--;            
        }
    }
}
