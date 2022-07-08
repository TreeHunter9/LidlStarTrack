using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Models.Weapon
{
    public abstract class BaseWeapon
    {
        protected float cooldownTimeInSeconds;
        protected int bulletsCount;
        
        public float CooldownTimeInSeconds => cooldownTimeInSeconds;
        public int BulletsCount => bulletsCount;
        
        public event Action<float> onWeaponShoot;
        public event Action onWeaponEndCooldown;

        public BaseWeapon(float cooldownTimeInSeconds, int bulletsCount)
        {
            this.cooldownTimeInSeconds = cooldownTimeInSeconds;
            this.bulletsCount = bulletsCount;
        }

        public abstract bool TryShoot(Vector2 position, Vector2 direction, out Bullet bullet);
        
        public void RaiseWeaponShootEvent(float cooldownTimeInSeconds) => onWeaponShoot?.Invoke(cooldownTimeInSeconds);
        
        protected virtual async Task StartCooldownAsync()
        {
            bulletsCount -= 1;
            await Task.Delay((int) (cooldownTimeInSeconds * 1000f));
            onWeaponEndCooldown?.Invoke();
            bulletsCount += 1;
        }
    }
}