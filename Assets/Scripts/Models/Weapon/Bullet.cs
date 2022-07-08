using UnityEngine;

namespace Models.Weapon
{
    public abstract class Bullet
    {
        public Vector2 position;
        public Vector2 direction;

        public Bullet(Vector2 position, Vector2 direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }
}