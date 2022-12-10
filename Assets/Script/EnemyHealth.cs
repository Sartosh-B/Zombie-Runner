using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    // ceate a public method which reduces hitpoints by the amount of damage

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Debug.Log("Hit points are <= 0 so " + name + "died");
            gameObject.SetActive(false);
        }
    }

}
