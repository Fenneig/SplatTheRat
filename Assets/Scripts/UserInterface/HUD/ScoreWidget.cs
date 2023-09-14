using JetBrains.Annotations;
using SplatTheRat.Model.Data;
using TMPro;
using UnityEngine;

namespace SplatTheRat.UserInterface.HUD
{
    public class ScoreWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amount;
        [SerializeField] private IntVariable _playerScore;

        [UsedImplicitly]
        public void UpdateScore()
        {
            _amount.text = _playerScore.Value.ToString();
        }
    }
}