using UnityEngine;
using TMPro;
using MenuLvls;

namespace Game.Logic
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _stepsCountText;
        private GameLogic _gameLogic;

        public static GameUI Instance { get; private set; }

        private void Awake() => Instance = this;
        private void Start() => _gameLogic = GameLogic.Instance;

        public void UpdateStepsCountUI()
            => _stepsCountText.text = $"{_gameLogic.stepsLeft}/{Level.Instance.currentLevelData.stepsHave}";
    }
}