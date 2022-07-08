using System;
using Models.Weapon;
using UnityEngine;

namespace Presenters
{
    public abstract class BaseEnemyComponent : MonoBehaviour, IDamageable
    {
        public abstract void TakeDamage();

        protected abstract void OnCollisionEnter2D(Collision2D col);
    }
}
