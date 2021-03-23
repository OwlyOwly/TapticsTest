using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int baseHealth = 10;
    private int totalHealth;
    private int currentHealth;
    private Animator anim;
    private int hpLevelMultiplier = 10;
    private int currentLevel;

    public event Action OnEnemyDiedEvent;
    public event Action OnEnemyDamaged;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetStats(int level)
    {
        totalHealth = baseHealth + (level * hpLevelMultiplier);
        currentHealth = totalHealth;
        currentLevel = level;
    }

    public void GetDamage(int amount)
    {
        anim.SetTrigger("isAttacked");
        currentHealth -= amount;
        OnEnemyDamaged?.Invoke();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetTrigger("isDead");
        OnEnemyDiedEvent?.Invoke();
        Destroy(gameObject, 1f);
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public int GetMaxHealth()
    {
        return totalHealth;
    }
}
