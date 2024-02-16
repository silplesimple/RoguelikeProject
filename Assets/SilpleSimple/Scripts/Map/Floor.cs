using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private bool monsterPresent = false;
    private bool enterPlayer = false;    
    public Transform doorTransform ;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            monsterPresent = true;           
        }        
        if(other.CompareTag("Player"))
        {
            if(!enterPlayer)
            {
                Debug.Log("플레이어가 밟았다!enterPlayer"+enterPlayer);
                MapManager.instance.monsterIndex++;
                MapManager.instance.livingEnemyIndex = MapManager.instance.monsterIndex;
                MapManager.instance.CreateMonster(gameObject.transform.position);
                MapManager.instance.CreateRandomItem(gameObject.transform.position);
                enterPlayer = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    private void Start()
    {
        
    }
    
    private void FixedUpdate()
    {
        OpenDoor();
        if (MapManager.instance.livingEnemyIndex == 0)
            monsterPresent = false;
    }
    
    private void OpenDoor(){
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
