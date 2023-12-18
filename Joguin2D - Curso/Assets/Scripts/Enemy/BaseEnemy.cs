using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int damage = 1;

    public float destroyTimer = 1f;

    public BaseHealth healthBase;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        Destroy(gameObject, destroyTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<BaseHealth>();

        if (health != null)
        {
            health.Damage(damage);
        }
    }

    public void Damage(int amout)
    {
        healthBase.Damage(amout);
    }

}
