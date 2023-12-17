using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// Base class for all type of Guns
    /// </summary>
    public abstract class WeaponController : MonoBehaviour
    {
        public WeaponType weaponType;
        public GameObject bulletPrefab;
        public Transform bulletSpawnPoint;
        public float fireRate = 0.2f;
        public float nextFireTime = 0f;

        public abstract void AutoShoot(Quaternion rotation);
    }
}