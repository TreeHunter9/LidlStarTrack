using System.Collections;
using TMPro;
using UnityEngine;

namespace Views
{
    public class CoordinatesView : MonoBehaviour
    {
        [SerializeField] private Transform _spaceshipController;
        [SerializeField] private TextMeshProUGUI _coordinatesTMP;

        private const string CoordinatesText = "Coordinates ";

        private void Awake()
        {
            StartCoroutine(UpdateCoordinatesViewAsync());
        }

        private IEnumerator UpdateCoordinatesViewAsync()
        {
            WaitForSeconds waitForQuarterOfSecond = new WaitForSeconds(0.25f);
            while (true)
            {
                Vector2 position = _spaceshipController.transform.position;
                _coordinatesTMP.text = CoordinatesText + $"x = {position.x:F2}, y = {position.y:F2}";
                yield return waitForQuarterOfSecond;
            }
        }
    }
}