using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    private float _currentValue;
    private float _targetValue;

    private void Awake()
    {
        Health.Changed.AddListener(OnHealthChanged);
    }

    private void OnHealthChanged(float value)
    {
        _targetValue = value;
        StartCoroutine(ChangeHealthSmoothly());
    }

    private IEnumerator ChangeHealthSmoothly()
    {
        float elapsedTime = 0;
        float normalizedTime;
        float duration = 0.5f;
        float value;

        while (elapsedTime < duration)
        {
            normalizedTime = elapsedTime / duration;
            value = Mathf.Lerp(_currentValue, _targetValue, normalizedTime);
            elapsedTime += Time.deltaTime;
            _slider.value = value;
            _text.text = value.ToString("F0");

            yield return null;
        }

        _currentValue = _targetValue;
    }
}