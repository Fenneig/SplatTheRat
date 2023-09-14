using SplatTheRat.ScriptableObjects.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SplatTheRat.Interface.Menu
{
    public class EntryWidget : MonoBehaviour
    {
        [SerializeField] private FieldSetup _fieldSetup;
        [SerializeField] private TextMeshProUGUI _gridAmountText;
        [SerializeField] private Slider _gridAmountSlider;

        private string _startText;

        private void Awake()
        {
            _gridAmountSlider.onValueChanged.AddListener(ValueChanged);
            _startText = _gridAmountText.text;
            _gridAmountSlider.value = _fieldSetup.GridLength;
            UpdateText();
            gameObject.SetActive(false);
        }

        private void UpdateText()
        {
            _gridAmountText.text = $"{_startText} {_fieldSetup.GridLength}";
        }
        
        private void ValueChanged(float newValue)
        {
            _fieldSetup.GridLength = (int) newValue;
            UpdateText();
        }

        private void OnDestroy()
        {
            _gridAmountSlider.onValueChanged.RemoveListener(ValueChanged);
        }
    }
}