using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _startValue = 50;
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _changeHealthDuration = 0.5f;
    [SerializeField] private HealthView _healthView;

    private bool _isHealthChanging = false;

    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        HealthChangeButton.Clicked.AddListener(OnHealthChangeButtonClicked);
    }

    private void Start()
    {
        CurrentHealth = _startValue;
        _healthView.Render(this);
    }

    private IEnumerator ChangeHealthSmoothly(float damage)
    {
        _isHealthChanging = true;

        float startHealth = CurrentHealth;
        float targetHealth = Mathf.Clamp(CurrentHealth + damage, _minValue, _maxValue);
        float elapsedTime = 0;
        float normalizedTime;

        while (elapsedTime < _changeHealthDuration)
        {
            normalizedTime = elapsedTime / _changeHealthDuration;
            CurrentHealth = Mathf.Lerp(startHealth, targetHealth, normalizedTime);
            _healthView.Render(this);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _isHealthChanging = false;
    }

    private void OnHealthChangeButtonClicked(float value)
    {
        if (_isHealthChanging)
            return;

        StartCoroutine(ChangeHealthSmoothly(value));
    }
}