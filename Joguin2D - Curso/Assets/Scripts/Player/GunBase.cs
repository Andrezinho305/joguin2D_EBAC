using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform shootPosition;

    public float timeBetweenShots = .3f;

    private Coroutine _currentCoroutine;

    public Transform playerFacing;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        }

    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = shootPosition.position;
        projectile.side = playerFacing.transform.localScale.x;
    }
}
