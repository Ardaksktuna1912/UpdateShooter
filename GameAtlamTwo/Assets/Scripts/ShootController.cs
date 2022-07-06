using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private BulletControl Bulletprefab;
    public void Shoot(Vector3 direction, Vector3 position)
    {
        var bullet = Instantiate(Bulletprefab, position, Quaternion.identity);
        bullet.Fire(direction);
    }
}
