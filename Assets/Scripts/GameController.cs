using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// This class handles the Game where win or lose conditions are handled 
    /// also the reset condition on Retry button click is handled
    /// </summary>
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject youWinPanel;
        [SerializeField] private GameObject youLoosePanel;
        [SerializeField] private CharacterMovement character;
        [SerializeField] private Transform characterStartingPoint;
        [SerializeField] private Image fillbar;
        public List<GameObject> coins = new List<GameObject>();
        public static GameController Instance { get; set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void ActivateYouWinScreen()
        {
            youWinPanel.SetActive(true);
        }

        public void FillTheFilBar(float value)
        {
            fillbar.fillAmount += value;
        }

        public void ActivateYouLoseScreen()
        {
            youLoosePanel.SetActive(true);
        }

        //triggers on retry button pressed
        public void OnRetryButtonClick()
        {
            if (coins.Count > 0)
            {
                foreach(GameObject coin in coins)
                {
                    Destroy(coin);
                }
            }
            coins.Clear();

            if (!character.gameObject.activeSelf)
            {
                character.gameObject.SetActive(true);
            }
            character.gameObject.transform.SetPositionAndRotation(characterStartingPoint.position, Quaternion.identity);
            EnemyController.Instance.Reset();
            youWinPanel.SetActive(false);
            youLoosePanel.SetActive(false);
        }

    }
}