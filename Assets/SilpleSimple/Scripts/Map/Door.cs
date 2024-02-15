using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool monsterPresent = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            monsterPresent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            monsterPresent = false;
        }
    }

    private void Start()
    {
        StartCoroutine(CheckMonsterAndOpenDoor());
    }

    IEnumerator CheckMonsterAndOpenDoor()
    {
        while(true)
        {
            yield return null;
            if (!monsterPresent)
            {
                OpenDoor();
                yield break;
            }
        }
    }
    void OpenDoor()
    {

    }

}
