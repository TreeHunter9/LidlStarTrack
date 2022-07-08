using UnityEngine;

namespace Presenters
{
    public class BordersTeleport : MonoBehaviour
    {
        [SerializeField] private Transform _spaceshipTransform;
        [SerializeField] private float _threshold = 0.025f;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 pos = _camera.WorldToViewportPoint(_spaceshipTransform.position);
            if (pos.x < -_threshold)
            {
                ChangePosition(1f + _threshold, pos.y, pos.z);
                return;
            }
            if (pos.x > 1f + _threshold)
            {
                ChangePosition(-_threshold, pos.y, pos.z);
                return;
            }

            if (pos.y < -_threshold)
            {
                ChangePosition(pos.x, 1f + _threshold, pos.z);
                return;
            }
            if (pos.y > 1f + _threshold)
            {
                ChangePosition(pos.x, -_threshold, pos.z);
                return;
            }
        }

        private void ChangePosition(float x, float y, float z)
        {
            _spaceshipTransform.position = _camera.ViewportToWorldPoint(new Vector3(x, y, z));
        }
    }
}
