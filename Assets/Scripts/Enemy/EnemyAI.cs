using UnityEngine;
using UnityEngine.AI;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// This class is attached on each enemy with navmesh component attached on it
    /// </summary>
    public class EnemyAI : MonoBehaviour, IDamagable
    {
        private NavMeshAgent agent;
        public float chaseSpeed = 5f;
        public float health;
        public GameObject coinPrefab;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        //chase to player
        public void ChasePlayer(Vector3 targetPosition)
        {
            agent.SetDestination(targetPosition);
            agent.speed = chaseSpeed;
        }

        public void StopChasing()
        {
            agent.isStopped = true;
            agent.speed = 0f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<CharacterMovement>() != null)
            {
                collision.gameObject.SetActive(false);

                //we can show ad here

                GameController.Instance.ActivateYouLoseScreen();
            }
        }


        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                //GameController.Instance.FillTheFilBar(1f);
                GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
                GameController.Instance.coins.Add(coin);
                EnemyController.Instance.enemies.Remove(this);
                gameObject.SetActive(false);
            }
        }
    }
}
