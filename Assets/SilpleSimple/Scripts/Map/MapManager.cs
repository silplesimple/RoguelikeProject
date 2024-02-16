using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    [SerializeField] private GameObject[] map;
    public GameObject monster;
    public int monsterIndex = 0;
    private Vector3 SpawnPoint;
    public GameObject Boss;    
    public int itemIndex = 0;
    public GameObject itemPrefab;
    public int livingEnemyIndex = 0;
    public int BossIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        CreateMap();

        
        Vector2 monsterSpawnPosition = new Vector2(Random.Range(-6f, 6f), Random.Range(-4f, 4f));
        CreateMonster(monsterSpawnPosition);
    }

    public void CreateMonster(Vector2 direction)
    {
        for (int i = 0; i < monsterIndex; i++)
        {
            GameObject newMonster = Instantiate(monster, direction, Quaternion.identity);

            // 몬스터 생성 시 위치를 기록하여 CreateRandomItem에 전달
            Vector2 monsterPosition = newMonster.transform.position;

            // 몬스터 옆에 아이템 생성
            CreateRandomItem(monsterPosition);
        }
    }
    public void CreateBoss(Vector2 direction)
    {
            Instantiate(Boss, direction, Quaternion.identity);            
    }

    private void CreateMap()
    {
        int randomIndex = Random.Range(0, map.Length);
        SpawnPoint = new Vector3(0, 0);
        Instantiate(map[randomIndex], SpawnPoint, Quaternion.identity);
    }

    public void CreateRandomItem(Vector2 monsterPosition)
    {
       
        Vector2 randomOffset = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        Vector2 randomPosition = monsterPosition + randomOffset;

       
        if (itemPrefab != null)
        {
           
            GameObject newItem = Instantiate(itemPrefab, randomPosition, Quaternion.identity);

          
            HealthRestoreItem healthRestoreItem = newItem.GetComponent<HealthRestoreItem>();

            if (healthRestoreItem != null)
            {
               
                healthRestoreItem.OnPickup += PlayerPickedUpItem;
            }
        }
    }

    private void PlayerPickedUpItem(int restorationAmount)
    {
        // 플레이어가 아이템을 줍게 되었을 때의 동작
        HealthSystem playerHealth = FindObjectOfType<HealthSystem>().GetComponent<HealthSystem>();

        if (playerHealth != null)
        {
            // 플레이어 체력 회복
            playerHealth.RestoreHealth(restorationAmount);
        }
    }
}