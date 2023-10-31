using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int baseLife = 1;

    public bool destroyOnKill = false;

    private int _currentLife;
    private bool _isDead = false;



    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _currentLife = baseLife;
        _isDead = false;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }


    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject);
        }
    }

}
