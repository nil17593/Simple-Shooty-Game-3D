using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// ShotGun Gun class this handles the firerate and auto aiming
    /// </summary>
    public class ShotGun : WeaponController
    {
        public override void AutoShoot(Quaternion rotation)
        {
            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + fireRate;
                GameObject bullet = ObjectPool.Instance.GetPooledObject();
                bullet.transform.position = bulletSpawnPoint.position;
                bulletSpawnPoint.rotation = rotation;
                bullet.transform.rotation = bulletSpawnPoint.rotation;
                bullet.SetActive(true);
            }
        }
    }
}