using SplatTheRat.Model.Data;
using UnityEngine;
using UnityEngine.UI;

namespace SplatTheRat.HUD
{
    public class HealthWidget : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        [SerializeField] private IntVariable _playerHealth;
        [SerializeField] private IntReference _playerMaxHealth;

        public void UpdateHealth()
        {
            _healthImage.fillAmount = (float) _playerHealth.Value / _playerMaxHealth.Value;
        }
    }
}