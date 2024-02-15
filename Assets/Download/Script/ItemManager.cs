using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab1; // ������ ���� 1�� ������
    public GameObject itemPrefab2; // ������ ���� 2�� ������
    public float spawnRadius = 5f; // ������ ���� �ݰ�

    void Start()
    {
 
        SpawnItem();
    }

    void SpawnItem()
    {
  
        Vector2 spawnPosition = new Vector2(
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(-spawnRadius, spawnRadius)
        );

    
        int randomItem = Random.Range(0, 2); 

      
        GameObject selectedItemPrefab = (randomItem == 0) ? itemPrefab1 : itemPrefab2;

      
        Instantiate(selectedItemPrefab, spawnPosition, Quaternion.identity);
    }
}
