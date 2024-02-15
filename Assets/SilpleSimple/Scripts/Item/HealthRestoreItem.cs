using System;
using UnityEngine;

public class HealthRestoreItem : MonoBehaviour
{
    [SerializeField] private int restorationAmount = 20;

    public event Action<int> OnPickup;

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.CompareTag("Player"))
        {
 
            OnPickup?.Invoke(restorationAmount);
   
        }
    }
}