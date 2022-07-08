using UnityEngine;

namespace Models.Enemy
{
    public abstract class BaseEnemy
    {
        public Vector2 position;

        public BaseEnemy(Vector2 position)
        {
            this.position = position;
        }
    }
}