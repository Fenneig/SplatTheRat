using SplatTheRat.Model.Data;
using TMPro;
using UnityEngine;

namespace SplatTheRat.HUD
{
    public class ScoreWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amount;
        [SerializeField] private IntVariable _playerScore;

        public void UpdateScore()
        {
            _amount.text = _playerScore.Value.ToString();
        }
    }
}