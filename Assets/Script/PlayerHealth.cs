using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] float health = 100f;

    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        if(health<= 0)
        {
            Debug.Log("you died");
            GetComponent<DeatchHandler>().HandleDeath();
        }
    }    
    
}
