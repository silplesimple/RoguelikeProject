using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    [SerializeField] private GameObject Map;
    public GameObject monster;
    public int monsterIndex=0;
    private Vector3 SpawnPoint;

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
    }
    public void CreateMonster(Vector2 direction)//ÁÂÇ¥¹Þ±â
    {
        for(int i=0;i<monsterIndex;i++)
        {
            Instantiate(monster,direction, Quaternion.identity);
        }
    }
    
    private void CreateMap()
    {
        SpawnPoint = new Vector3(0, 0);
        Instantiate(Map, SpawnPoint, Quaternion.identity);
    }
}
