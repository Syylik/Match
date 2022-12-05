using UnityEngine;
using MenuLvls;

namespace Game.Logic
{
    public class GameLogic : MonoBehaviour
    {
        public enum GameMatchState
        {
            [InspectorName("Добавлять спички")] Add,
            [InspectorName("Убирать спички")] Remove,
            [InspectorName("Двигать спички")] Move
        }
        public GameMatchState gameMatchState;

        [HideInInspector] public int stepsLeft;

        private WinLose _winLose;
        private Level _level;

        public static GameLogic Instance { get; private set; }

        private void Awake() => Instance = this;
        private void Start()
        {
            _level = Level.Instance;
            _winLose = GameObject.FindObjectOfType<WinLose>();

            stepsLeft = _level.currentLevelData.stepsHave;
            GameUI.Instance.UpdateStepsCountUI();
        }

        public void MakeStep()
        {
            if(!HaveSteps()) return;
            stepsLeft--;
            GameUI.Instance.UpdateStepsCountUI();

            if(!HaveSteps()) _winLose.CheckWinLose();
        }
        public bool HaveSteps()
        {
            if(stepsLeft <= 0) return false;
            return true;
        }
    }
}