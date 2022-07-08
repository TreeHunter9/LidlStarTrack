using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Views
{
    public class AngleView : MonoBehaviour
    {
        [SerializeField] private Transform _spaceshipTransform;
        [SerializeField] private TextMeshProUGUI _angleTMP;

        private const string AngleText = "Angle = ";

        private void Awake()
        {
            StartCoroutine(UpdateAngleViewAsync());
        }

        private IEnumerator UpdateAngleViewAsync()
        {
            WaitForSeconds waitForQuarterOfSecond = new WaitForSeconds(0.25f);
            while (true)
            {
                float angle = Vector2.SignedAngle(Vector2.up, _spaceshipTransform.up);
                _angleTMP.text = AngleText + $"{angle:F0}";
                yield return waitForQuarterOfSecond;
            }
        }
    }
}