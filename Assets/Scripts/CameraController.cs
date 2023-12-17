using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// Camera controller class
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        void FollowPlayer()
        {
            if (target != null)
            {
                Vector3 targetPosition = target.position + offset;
                transform.position = targetPosition;
            }
        }

        private void LateUpdate()
        {
            FollowPlayer();
        }
    }
}