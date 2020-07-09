using Source.EndGameScreen;
using Source.Scoreboard;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source
{
    public class SceneDirector : MonoBehaviour
    {
        [SerializeField] private TextScreen _textScreen = null;
        public Board board = null;
        private bool _lose = false;

        public enum State
        {
            SceneLoad,
            StickFlyed,
            StickPlaced,
            SceneEnd
        };

        public State Phase
        {
            get;
            private set;
        }
        
        public SceneDirector()
        {
            Phase = State.SceneLoad;
        }
        private void ShowText()
        {

            _textScreen.Enable();
        }

        private void NextRoom()
        {
            if (!_lose)
            {
                board.Increase(1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void OnStickFly()
        {
            Phase = State.StickFlyed;
        }

        public void OnDeath()
        {
            _textScreen.SetText("Вот и помер дед Максим");
            Invoke(nameof(ShowText), 1f);
            Phase = State.SceneEnd;
        }
        
        public void OnKillFriend()
        {
            if(_lose) return;
            _textScreen.SetText("Вы убили товарища");
            Invoke(nameof(ShowText), 1f);
            Phase = State.SceneEnd;
        }

        public void OnStickPlaced()
        {
            if(Phase == State.SceneEnd) return;
            Phase = State.StickPlaced;
        }

        public void OnLose()
        {
            if (!_lose)
            {
                _textScreen.SetText("Колыхните, чтобы сбросить врагов");
                Invoke(nameof(ShowText), 0.3f);
                _lose = true;
                Phase = State.SceneEnd;
            }
        }

        public void OnWin()
        {
            Invoke(nameof(NextRoom), 1f);
        }
    }
}