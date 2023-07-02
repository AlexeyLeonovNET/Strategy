using TMPro;
using Abstractions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;
using UniRx;

namespace UserControlSystem.UI.Presenter
{
    public class BottomLeftPresenter : MonoBehaviour
    {
        [SerializeField] private Image _selectedImage;

        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillImage;

        [Inject] private IObservable<ISelecatable> _selectedValue;


        private void Start()
        {
            _selectedValue.Subscribe(OnSelected);
        }


        private void OnSelected(ISelecatable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _text.enabled = selected != null;

            if (selected != null)
            {
                _selectedImage.sprite = selected.Icon;

                _text.text = $"{selected.Health}/{selected.MaxHealth}";

                _healthSlider.minValue = 0;
                _healthSlider.maxValue = selected.MaxHealth;
                _healthSlider.value = selected.Health;
                var colorSlider = Color.Lerp(Color.red, Color.green, selected.Health / (float)selected.MaxHealth);
                _sliderBackground.color = colorSlider * 0.5f;
                _sliderFillImage.color = colorSlider;
            }
        }
    }
}
