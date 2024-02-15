using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private bool monsterPresent = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            monsterPresent = true;
            Debug.Log("몬스터 왔다!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            monsterPresent = false;
            Debug.Log("몬스터 없다!"+monsterPresent);
        }
    }

    private void Start()
    {
        StartCoroutine(CheckMonsterAndOpenDoor());
    }

    IEnumerator CheckMonsterAndOpenDoor()
    {
        while (true)
        {
            yield return null;
            if (!monsterPresent)
            {                
                OpenDoor(false);
                yield break;
            }
            else if (monsterPresent)
            {
                OpenDoor(true);
                yield break;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!monsterPresent)
            OpenDoor(false);
        else if(monsterPresent)
            OpenDoor(true);
    }
    private void OpenDoor(bool door){
        
        Transform doorTransform = transform.Find("Door");
        if (doorTransform != null)
        {
            
            doorTransform.gameObject.SetActive(door);
            
        }
    }
}
