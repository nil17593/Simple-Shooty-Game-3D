using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// This class is attached on character handles character movement
    /// </summary>
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private FixedJoystick fixedJoystick;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private GameObject currentGun;
        [SerializeField] private float lookSpeed;
        [SerializeField] private WeaponController[] weapons;
        [SerializeField] private Animator animator;
        [SerializeField] private float rangeDistanceFromenemy;
        private Rigidbody rb;
        private Vector3 moveVector;

        private int currentWeaponIndex = 0;
        private WeaponController currentWeapon;


        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            foreach (WeaponController weapon in weapons)
            {
                weapon.gameObject.SetActive(false);
            }
            weapons[0].gameObject.SetActive(true);
            currentWeapon = weapons[0];
        }


        private void Update()
        {
            JoyStickMovement();
            foreach (EnemyAI enemy in EnemyController.Instance.enemies)
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist <= rangeDistanceFromenemy && enemy != null)
                {
                    animator.SetBool("Shoot", true);
                    Vector3 direction = enemy.transform.position - transform.position;
                    Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                    weapons[currentWeaponIndex].GetComponent<WeaponController>().AutoShoot(targetRotation);
                }
            }


        }

        public void SwitchWeapon()
        {
            weapons[currentWeaponIndex].gameObject.SetActive(false);
            currentWeaponIndex++;
            if (currentWeaponIndex >= weapons.Length)
            {
                currentWeaponIndex = 0;
            }

            if (weapons[currentWeaponIndex].weaponType == WeaponType.MachineGun)
            {
                //we can show ad here
            }

            weapons[currentWeaponIndex].gameObject.SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];
            return;
        }



        private void JoyStickMovement()
        {
            Vector3 inputDirection = new Vector3(fixedJoystick.Horizontal, 0f, fixedJoystick.Vertical);
            if (inputDirection.magnitude > 1f)
                inputDirection.Normalize();
            Vector3 desiredVelocity = inputDirection * movementSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + desiredVelocity);

            animator.SetFloat("Blend", fixedJoystick.Horizontal);
            animator.SetFloat("BlendSide", fixedJoystick.Vertical);
        }



        #region Collision

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("FinishArea"))
            {
                if (EnemyController.Instance.enemies.Count <= 0)
                {
                    GameController.Instance.ActivateYouWinScreen();
                }
            }
            if (collision.gameObject.CompareTag("Coin"))
            {
                Destroy(collision.gameObject);
            }
        }
        #endregion
    }
}