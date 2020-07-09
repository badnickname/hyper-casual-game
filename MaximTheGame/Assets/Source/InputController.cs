using Source.Ded;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private SceneDirector _director = null;
        [SerializeField] private Player _player = null;

        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                if(_director.Phase == SceneDirector.State.SceneLoad)
                    _player.Increase();
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (_director.Phase == SceneDirector.State.SceneLoad)
                {
                    _player.Shake(100);
                    _director.OnStickFly();
                }

                if (_director.Phase == SceneDirector.State.StickPlaced)
                    StartCoroutine(_player.DecreaseCoroutine(_player));

                if (_director.Phase == SceneDirector.State.SceneEnd)
                {
                    _director.board.ResetValue();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}