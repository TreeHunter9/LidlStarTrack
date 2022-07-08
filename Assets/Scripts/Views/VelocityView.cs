using System;
using System.Collections;
using Presenters;
using TMPro;
using UnityEngine;

namespace Views
{
    public class VelocityView : MonoBehaviour
    {
        [SerializeField] private SpaceshipController _spaceshipController;
        [SerializeField] private TextMeshProUGUI _velocityTMP;

        private const string VelocityText = "Velocity = ";

        private void Awake()
        {
            StartCoroutine(UpdateVelocityViewAsync());
        }

        private IEnumerator UpdateVelocityViewAsync()
        {
            WaitForSeconds waitForQuarterOfSecond = new WaitForSeconds(0.25f);
            while (true)
            {
                int velocity = (int)(_spaceshipController.GetVelocity() * 10000f);
                _velocityTMP.text = VelocityText + $"{velocity}";
                yield return waitForQuarterOfSecond;
            }
        }
    }
}