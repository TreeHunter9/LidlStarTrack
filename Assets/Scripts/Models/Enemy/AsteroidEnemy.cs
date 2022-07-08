using UnityEngine;

namespace Models.Enemy
{
    public class AsteroidEnemy : BaseEnemy
    {
        public Vector2 direction;

        public AsteroidEnemy(Vector2 position, Vector2 direction) : base(position)
        {
            this.direction = direction;
        }
    }
}