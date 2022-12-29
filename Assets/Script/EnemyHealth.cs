using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;
    // ceate a public method which reduces hitpoints by the amount of damage

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("die");
    }
    public bool IsDead()
    {
        return isDead;
    }
}
