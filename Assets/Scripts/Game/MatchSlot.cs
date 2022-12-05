using UnityEngine;
using UnityEngine.UI;
using Game.Logic;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class MatchSlot : MonoBehaviour
    {
        [SerializeField] private GameObject _matchPrefab;
        [SerializeField] private Match _matchInSlot;
        [HideInInspector] public bool haveMatch;

        private Button _butt;

        private void Start()
        {
            TryGetComponent(out _butt);
            switch(GameLogic.Instance.gameMatchState)
            {
                case GameLogic.GameMatchState.Add:
                    _butt.onClick.AddListener(AddMatch);
                    break;
                case GameLogic.GameMatchState.Remove:
                    _butt.onClick.AddListener(RemoveMatch);
                    break;
            }

            if(_matchInSlot is null) haveMatch = false;
            else haveMatch = true;
        }

        public void AddMatch()
        {
            if(haveMatch || !GameLogic.Instance.HaveSteps()) return;
            haveMatch = true;
            _matchInSlot = Instantiate
                (
                _matchPrefab,
                (Vector2)transform.position + new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f)),
                transform.rotation,
                transform
                ).GetComponent<Match>();

            GameLogic.Instance.MakeStep();
        }
        public void RemoveMatch()
        {
            if(!haveMatch || !GameLogic.Instance.HaveSteps()) return;
            haveMatch = false;
            Destroy(_matchInSlot.gameObject);
            GameLogic.Instance.MakeStep();
        }
    }
}