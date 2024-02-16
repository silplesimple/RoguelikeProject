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
    public int itemIndex = 0;
    public GameObject itemPrefab;
    public int livingEnemyIndex = 0;

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

            // ���� ���� �� ��ġ�� ����Ͽ� CreateRandomItem�� ����
            Vector2 monsterPosition = newMonster.transform.position;

            // ���� ���� ������ ����
            CreateRandomItem(monsterPosition);
        }
    }

    private void CreateMap()
    {
        int randomIndex = Random.Range(0, map.Length);
        SpawnPoint = new Vector3(0, 0);
        Instantiate(map[randomIndex], SpawnPoint, Quaternion.identity);
    }

    public void CreateRandomItem(Vector2 monsterPosition)
    {
       
        Vector2 randomOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
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
        // �÷��̾ �������� �ݰ� �Ǿ��� ���� ����
        HealthSystem playerHealth = FindObjectOfType<HealthSystem>().GetComponent<HealthSystem>();

        if (playerHealth != null)
        {
            // �÷��̾� ü�� ȸ��
            playerHealth.RestoreHealth(restorationAmount);
        }
    }
}