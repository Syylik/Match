using UnityEngine;

namespace MenuLvls
{
    [CreateAssetMenu(fileName = "Lvl", menuName = "ScriptableObjects/LevelData")]

    public class LevelData : ScriptableObject
    {
        public GameObject levelPrefab;
        public int stepsHave;
        [Multiline()] public string taskDescription;

        [HideInInspector] public int levelNum;
        [HideInInspector] public bool levelOnScene = false;
        [HideInInspector] public bool levelIsOpen = false;
        
        private void Awake()
        {
            if(PlayerPrefs.GetInt($"{levelNum}IsOpen", 0) == 1) levelIsOpen = true;
            else levelIsOpen = false;
        }
    }
}