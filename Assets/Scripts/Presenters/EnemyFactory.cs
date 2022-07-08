using Models.Enemy;
using UnityEngine;

namespace Presenters
{
    public class EnemyFactory : BaseFactory<BaseEnemy>
    {
        [SerializeField] private AsteroidEnemyComponent[] _asteroidPrefabs;
        [SerializeField] private NLOEnemyComponent _nloPrefab;
        
        public override void Create(BaseEnemy enemy)
        {
            if (enemy is AsteroidEnemy asteroidEnemy)
            {
                int asteroidID = Random.Range(0, _asteroidPrefabs.Length - 1);
                AsteroidEnemyComponent asteroid = Instantiate(_asteroidPrefabs[asteroidID], asteroidEnemy.position,
                    Quaternion.identity);
                asteroid.Init(asteroidEnemy.direction);
            }
            else if (enemy is NLOEnemy nloEnemy)
            {
                NLOEnemyComponent nlo = Instantiate(_nloPrefab, nloEnemy.position, Quaternion.identity);
                nlo.Init(nloEnemy.target);
            }
        }
    }
}