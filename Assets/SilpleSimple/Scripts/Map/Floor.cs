using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private bool monsterPresent = false;
    private bool enterPlayer = false;
    private int livingEnemyIndex = 0;

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
                MapManager.instance.monsterIndex++;
                livingEnemyIndex = MapManager.instance.monsterIndex;
                MapManager.instance.CreateMonster(gameObject.transform.position);
                enterPlayer = true;
            }
            CameraManager.instance.MoveCamera(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            livingEnemyIndex--;
            if (livingEnemyIndex == 0)
                monsterPresent = false;
        }
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (!monsterPresent)
            OpenDoor(false);
        else if (monsterPresent)
            OpenDoor(true);
    }
    private void OpenDoor(bool door)
    {

        Transform doorTransform = transform.Find("Door");
        if (doorTransform != null)
        {
            doorTransform.gameObject.SetActive(door);
        }
    }
}
