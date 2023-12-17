using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// This class handles bullet Movement
    /// </summary>
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float bulletForce = 100f;
        [SerializeField] private TrailRenderer trail;
        [SerializeField] private int damage;

        private Rigidbody rb;


        private void OnEnable()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
        }

        private void OnDisable()
        {
            rb.velocity = Vector3.zero;
        }


        private void OnTriggerEnter(Collider other)
        {
            EnemyAI enemyAI = other.gameObject.GetComponent<EnemyAI>();

            if (enemyAI != null)
            {
                enemyAI.TakeDamage(damage);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}