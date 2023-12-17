using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// This classs handles all the enemy in the Game
    /// </summary>
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private  Transform player;
        [SerializeField] private EnemyAI enemyAIPrefab;
        [SerializeField] private float detectionRange = 10f;
        [SerializeField] private List<Transform> enemySpawnPoints = new List<Transform>();

        public List<EnemyAI> enemies = new List<EnemyAI>();

        public static EnemyController Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            SpawnEnemies();
        }  

        private void Update()
        {
            foreach (EnemyAI enemy in enemies)
            {
                if (player != null)
                {
                    float distanceToPlayer = Vector3.Distance(enemy.transform.position, player.position);
                    if (distanceToPlayer <= detectionRange)
                    {
                        enemy.ChasePlayer(player.position);
                    }
                }
            }
        }

        //spawn enemies on given points
        void SpawnEnemies()
        {
            for (int i = 0; i < enemySpawnPoints.Count; i++)
            {
                EnemyAI enemyAI = Instantiate(enemyAIPrefab, enemySpawnPoints[i].transform.position, Quaternion.identity, transform);
                enemies.Add(enemyAI);
                enemyAI.health = 100f;
            }
        }

        //resets the list of enemies when retry button is pressed
        public void Reset()
        {
            foreach(EnemyAI enemyAI in enemies)
            {
                Destroy(enemyAI.gameObject);
            }
            enemies.Clear();
            SpawnEnemies();
        }
    }
}
