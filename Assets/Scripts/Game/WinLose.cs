using UnityEngine;

namespace Game.Logic
{
    public class WinLose : MonoBehaviour
    {
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _winPanel;

        [SerializeField] private MatchSlot[] _matchesFullSlots;  //� ���� ������ ������ ���� ������
        [SerializeField] private MatchSlot[] _matchesEmptySlots; //� ���� ������ �� ������ ���� ������

        public void CheckWinLose()
        {
            foreach(var fullMatchSlot in _matchesFullSlots)
                if(!fullMatchSlot.haveMatch) { OpenLose(); return; }

            foreach(var emptyMatchSlot in _matchesEmptySlots)
                if(emptyMatchSlot.haveMatch) { OpenLose(); return; }

            OpenWin();
        }
        public void OpenLose()
        {
            _losePanel.SetActive(true);
        }
        public void OpenWin()
        {
            _winPanel.SetActive(true);
        }

    }
}