using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Health _health;

    private float _currentValue;
    private float _targetValue;

    private Coroutine _healthChangingRoutine;

    private void Awake()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        if (_healthChangingRoutine != null)
        {
            StopCoroutine(_healthChangedRoutine);
        }

        _targetValue = value;
        _healthChangingRoutine = StartCoroutine(ChangeHealthSmoothly());
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
            _currentValue = value;
            _slider.value = value;
            _text.text = value.ToString("F0");

            yield return null;
        }
    }
}
