using System;
using UnityEngine;
[AddComponentMenu("DangSon/Enemy")]
public class Enemy : MonoBehaviour,ICanTakeDamage
{
    [Header("Enemy Health")]
    public int maxHealth = 100;
    private int currenHealth;
    private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenHealth = maxHealth;
    }
    public void TakeDamage(int damage, Vector2 fore, GameObject instigator)
    {
        if (isDead) return;
        currenHealth -= damage;
        if(currenHealth<=0)
        {
            isDead = true;
            currenHealth=0;
            DeadEnemy();
        }
    }
    private void DeadEnemy()
    {
        Destroy(gameObject);
    }
}
