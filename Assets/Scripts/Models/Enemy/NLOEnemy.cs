using UnityEngine;

namespace Models.Enemy
{
    public class NLOEnemy : BaseEnemy
    {
        public Transform target;

        public NLOEnemy(Transform target, Vector2 position) : base(position)
        {
            this.target = target;
        }
    }
}