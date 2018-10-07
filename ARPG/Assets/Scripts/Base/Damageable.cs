using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour { // Controls the health

    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    public int health { get { return _health; } set { _health = value; }}
    public int maxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    void Start()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int damage) {

    }

    public virtual void Die() {

    }
}
