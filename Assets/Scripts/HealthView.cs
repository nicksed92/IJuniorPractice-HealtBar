using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    public void Render(Health health)
    {
        _slider.value = health.CurrentHealth;
        _text.text = health.CurrentHealth.ToString("F0");
    }
}