using System.Collections.Generic;
using UnityEngine;

namespace MenuLvls
{
    public class Level : MonoBehaviour
    {
        public List<LevelData> allLevels;
        public LevelData currentLevelData;
        private GameObject _currentLevel;

        private Canvas _canvas;

        public static readonly string LastLvlNumSave = nameof(LastLvlNumSave);

        public static Level Instance { get; private set; }
        
        private void Awake() => Instance = this;

        private void Start()
        {
            foreach(var level in allLevels) level.levelNum = allLevels.IndexOf(level);
            _canvas = GameObject.FindObjectOfType<Canvas>();

            if(PlayerPrefs.HasKey(LastLvlNumSave))
                OpenLevel(allLevels[PlayerPrefs.GetInt(LastLvlNumSave)]);
        }

        public void OpenLevel(LevelData level)
        {
            foreach(var lvl in allLevels) lvl.levelOnScene = false;
            level.levelOnScene = true;
            PlayerPrefs.SetInt(LastLvlNumSave, level.levelNum);
            CloseCurrentLevel();
            currentLevelData = level;
            _currentLevel = level.levelPrefab;
            Instantiate
                (
                _currentLevel,
                _currentLevel.transform.position,
                Quaternion.identity,
                _canvas.transform
                );
        }
        public void OpenLevel(int levelNum)
        {
            LevelData level = allLevels[levelNum];
            level.levelOnScene = true;
            PlayerPrefs.SetInt(LastLvlNumSave, level.levelNum);
            CloseCurrentLevel();
            currentLevelData = level;
            _currentLevel = level.levelPrefab;
            Instantiate
                (
                _currentLevel,
                _currentLevel.transform.position,
                Quaternion.identity,
                _canvas.transform
                );
        }
        public void CloseCurrentLevel()
        {
            if(_currentLevel is null) return;
            Destroy(_currentLevel);
        }
    }
}