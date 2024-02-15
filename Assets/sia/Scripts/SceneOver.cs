using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOver : MonoBehaviour
{
    // Start is called before the first frame update
    public string targetObjectName;
    public string scenename;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == targetObjectName)
        {
            SceneManager.LoadScene("GameoverScene");
            Debug.Log("게임오버");
        }
    }
}
