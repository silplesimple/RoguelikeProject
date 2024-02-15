using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedBoostAmount = 2f; // 이속 증가량

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
            
    //        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
    //        if (playerMovement != null)
    //        {
    //            playerMovement.ApplySpeedBoost(speedBoostAmount);

    //            // 아이템을 소멸시킵니다.
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
