using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab1; // 아이템 종류 1의 프리팹
    public GameObject itemPrefab2; // 아이템 종류 2의 프리팹
    public float spawnRadius = 5f; // 아이템 생성 반경

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
