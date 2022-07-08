using System.Collections;
using Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class LaserWeaponView : MonoBehaviour
    {
        [SerializeField] private SpaceshipController _spaceshipController;
        [SerializeField] private Image _laserImage;
        [SerializeField] private TextMeshProUGUI _laserCountTMP;

        private int _currentBulletCount;
        private bool _isAnimated;

        private void Start()
        {
            _spaceshipController.GetSecondWeapon.onWeaponShoot += UpdateLaserImage;
            _spaceshipController.GetSecondWeapon.onWeaponEndCooldown += AddBullet;
            
            _currentBulletCount = _spaceshipController.GetSecondWeapon.BulletsCount;
            _laserCountTMP.text = _currentBulletCount.ToString();
        }

        private void OnDisable()
        {
            _spaceshipController.GetSecondWeapon.onWeaponShoot -= UpdateLaserImage;
            _spaceshipController.GetSecondWeapon.onWeaponEndCooldown -= AddBullet;
        }

        private void AddBullet() => UpdateLaserCount(_currentBulletCount + 1);
        private void RemoveBullet() => UpdateLaserCount(_currentBulletCount - 1);

        private void UpdateLaserCount(int bulletCount)
        {
            _currentBulletCount = bulletCount;
            _laserCountTMP.text = _currentBulletCount.ToString();
        }

        private void UpdateLaserImage(float cooldownInSeconds)
        {
            RemoveBullet();
            StartCoroutine(UpdateLaserImageViewAsync(cooldownInSeconds, _isAnimated));
            _isAnimated = true;
        }

        private IEnumerator UpdateLaserImageViewAsync(float cooldownTimeInSeconds, bool alreadyAnimated)
        {
            float diff = 1 / cooldownTimeInSeconds;
            float fillAmount = 0f;
            _laserImage.fillAmount = 0f;
            while (fillAmount < 1f)
            {
                fillAmount += diff * Time.deltaTime;
                if (alreadyAnimated == false)
                    _laserImage.fillAmount = fillAmount;
                if (_isAnimated == false)
                {
                    _isAnimated = true;
                    alreadyAnimated = false;
                }
                yield return null;
            }
            _isAnimated = false;
        }
    }
}