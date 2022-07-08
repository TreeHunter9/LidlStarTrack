using System;
using System.Collections;
using Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CannonWeaponView : MonoBehaviour
    {
        [SerializeField] private SpaceshipController _spaceshipController;
        [SerializeField] private Image _cannonImage;

        private void Start()
        {
            _spaceshipController.GetFirstWeapon.onWeaponShoot += UpdateCannonImage;
        }

        private void OnDisable()
        {
            _spaceshipController.GetFirstWeapon.onWeaponShoot -= UpdateCannonImage;
        }

        private void UpdateCannonImage(float cooldownInSeconds)
        {
            StartCoroutine(UpdateCannonImageViewAsync(cooldownInSeconds));
        }

        private IEnumerator UpdateCannonImageViewAsync(float cooldownInSeconds)
        {
            float diff = 1 / cooldownInSeconds;
            _cannonImage.fillAmount = 0f;
            while (_cannonImage.fillAmount < 1f)
            {
                _cannonImage.fillAmount += diff * Time.deltaTime;
                yield return null;
            }
        }
    }
}