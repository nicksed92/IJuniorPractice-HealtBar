using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealthChangeButton : MonoBehaviour
{
    [SerializeField] private float _value;

    private Button _button;

    public static UnityEvent<float> Clicked = new UnityEvent<float>();

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnCicked);
    }

    private void OnCicked()
    {
        Clicked.Invoke(_value);
    }
}