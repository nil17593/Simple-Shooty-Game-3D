using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kwalee.SimpleShootyTest
{

    /// <summary>
    /// This is Object Pool Class
    /// will take pool gameobject
    /// we have to give amount for pool objects
    /// </summary>

    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> projectilepooledObjects;
        [SerializeField] private GameObject projectileobjectToPool;
        public static ObjectPool Instance;
        [SerializeField] private int amtToPool;

        void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            projectilepooledObjects = new List<GameObject>();
            GameObject temp;
            for (int i = 0; i < amtToPool; i++)
            {
                temp = Instantiate(projectileobjectToPool);
                temp.SetActive(false);
                projectilepooledObjects.Add(temp);
            }
        }

        //returns pooled Gameobject
        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amtToPool; i++)
            {
                if (!projectilepooledObjects[i].activeInHierarchy)
                {
                    return projectilepooledObjects[i];
                }
            }
            return null;
        }
    }
}
