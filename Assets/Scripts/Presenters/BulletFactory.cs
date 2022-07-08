using Models.Weapon;
using UnityEngine;

namespace Presenters
{
    public class BulletFactory : BaseFactory<Bullet>
    {
        [SerializeField] private CannonBulletComponent cannonCannonBulletPrefab;
        [SerializeField] private LaserBulletComponent laserCannonBulletPrefab;
    
        public override void Create(Bullet bullet)
        {
            if (bullet is CannonBullet)
            {
                CannonBulletComponent cannonBulletComponent =
                    Instantiate(cannonCannonBulletPrefab, bullet.position, Quaternion.identity);
                cannonBulletComponent.Init(bullet.direction);
            }
            else if (bullet is LaserBullet)
            {
                LaserBulletComponent cannonBulletComponent = Instantiate(laserCannonBulletPrefab, bullet.position,
                    Quaternion.LookRotation(Vector3.forward, bullet.direction));
                cannonBulletComponent.Init(bullet.direction);
            }
        }
    }
}