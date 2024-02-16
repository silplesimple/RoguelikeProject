using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFloor : MonoBehaviour
{
    private bool monsterPresent = false;
    private bool enterPlayer = false;
    public Transform doorTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            monsterPresent = true;
        }
        if (other.CompareTag("Player"))
        {
            if (!enterPlayer)
            {
                Debug.Log("플레이어가 밟았다!enterPlayer" + enterPlayer);                
                MapManager.instance.CreateBoss(gameObject.transform.position);                
                enterPlayer = true;
            }
        }
    }

    private void FixedUpdate()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        doorTransform = transform.Find("Door");
        if (doorTransform != null)
        {
            if (!monsterPresent)
                doorTransform.gameObject.SetActive(false);
            else if (monsterPresent)
                doorTransform.gameObject.SetActive(true);
        }
    }
}
