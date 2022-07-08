using UnityEngine;

namespace Models.Weapon
{
    public class CannonWeapon : BaseWeapon
    {
        public CannonWeapon(float cooldownTimeInSeconds, int bulletCount) : base(cooldownTimeInSeconds, bulletCount)
        { }

        public override bool TryShoot(Vector2 position, Vector2 direction, out Bullet bullet)
        {
            if (bulletsCount > 0)
            {
                RaiseWeaponShootEvent(cooldownTimeInSeconds);
                StartCooldownAsync();
                bullet = new CannonBullet(position, direction);
                return true;
            }

            bullet = null;
            return false;
        }
    }
}