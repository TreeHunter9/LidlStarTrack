using System.Collections;
using Models.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Presenters
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spaceshipTransform;
        [SerializeField] private BaseFactory<BaseEnemy> _enemyFactory;
        [Range(0f, 1f)]
        [SerializeField] private float _spawnThreshold = 0.1f;

        [Header("Asteroids Settings")]
        [SerializeField] private float _minTimeToSpawnAsteroid = 3f;
        [SerializeField] private float _maxTimeToSpawnAsteroid = 0.3f;
        [SerializeField] private float _deltaTimeToSpawnAsteroid = 0.05f;

        [Header("NLO Settings")] 
        [SerializeField] private float _minTimeToSpawnNLO = 10f;
        [SerializeField] private float _maxTimeToSpawnNLO = 2f;
        [SerializeField] private float _deltaTimeToSpawnNLO = 0.5f;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            StartCoroutine(ActivateAsteroidSpawnerAsync());
            StartCoroutine(ActivateNLOSpawnerAsync());
        }

        private IEnumerator ActivateAsteroidSpawnerAsync()
        {
            float currentTimeToSpawn = _minTimeToSpawnAsteroid;
            while (true)
            {
                SpawnAsteroidEnemy();   
                yield return new WaitForSeconds(currentTimeToSpawn);
                currentTimeToSpawn = Mathf.Clamp(currentTimeToSpawn - _deltaTimeToSpawnAsteroid,
                    _maxTimeToSpawnAsteroid, _minTimeToSpawnAsteroid);
            }
        }
        
        private IEnumerator ActivateNLOSpawnerAsync()
        {
            float currentTimeToSpawn = _minTimeToSpawnNLO;
            while (true)
            {
                yield return new WaitForSeconds(currentTimeToSpawn);
                SpawnNLOEnemy();
                currentTimeToSpawn = Mathf.Clamp(currentTimeToSpawn - _deltaTimeToSpawnNLO,
                    _maxTimeToSpawnNLO, _minTimeToSpawnNLO);
            }
        }

        private void SpawnAsteroidEnemy()
        {
            Vector2 position = FindSpawnPosition();
            Vector2 direction = FindDirection(position);
            AsteroidEnemy asteroidEnemy = new AsteroidEnemy(position, direction);
            _enemyFactory.Create(asteroidEnemy);
        }

        private void SpawnNLOEnemy()
        {
            Vector2 position = FindSpawnPosition();
            NLOEnemy nloEnemy = new NLOEnemy(_spaceshipTransform, position);
            _enemyFactory.Create(nloEnemy);
        }

        private Vector2 FindSpawnPosition()
        {
            Vector3 viewport = Vector3.zero;
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, 4f));
            float randomPositionValue = Random.Range(-_spawnThreshold, 1 + _spawnThreshold);
            switch (randomNumber)
            {
                case 0:
                    viewport.y = 1 + _spawnThreshold;
                    viewport.x = randomPositionValue;
                    break;
                case 1:
                    viewport.x = 1 + _spawnThreshold;
                    viewport.y = randomPositionValue;
                    break;
                case 2:
                    viewport.y = -_spawnThreshold;
                    viewport.x = randomPositionValue;
                    break;
                default:
                    viewport.x = -_spawnThreshold;
                    viewport.y = randomPositionValue;
                    break;
            }

            return _camera.ViewportToWorldPoint(viewport);
        }

        private Vector2 FindDirection(Vector2 position)
        {
            Vector2 randomPoints = Random.insideUnitCircle;
            Vector2 direction = _spaceshipTransform.position - (Vector3)position;
            return (direction + randomPoints * 2f).normalized;
        }
    }
}