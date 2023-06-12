using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _startValue = 50;
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _minValue = 0;
    [SerializeField] private float _changeHealthDuration = 0.5f;
    [SerializeField] private HealthView _healthView;

    private float _currentHealth;

    public static UnityEvent<float> HealthChanged = new UnityEvent<float>();

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            HealthChanged.Invoke(_currentHealth);
        }
    }

    private void Start()
    {
        CurrentHealth = _startValue;
    }

    public void ChangeHealth(float value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, _minValue, _maxValue);
    }
}