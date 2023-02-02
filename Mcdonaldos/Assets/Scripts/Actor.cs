using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private int health;

    private bool IsDead()
    {
        return health <= 0;
    }

	private void Die()
    {
        Destroy(gameObject);
    }

	public void TakeDamange(int damageAmount)
    {
        health -= damageAmount;

        if (IsDead())
        {
            Die();
        }
    }

    private void Start()
    {
        health = maxHealth;
    }
}
