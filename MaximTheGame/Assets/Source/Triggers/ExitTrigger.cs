using Source.Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace Source.Triggers
{
    public class ExitTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onWin = null;
        [SerializeField] private UnityEvent _onLose = null;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Enemy>())
            {
                _onLose.Invoke();
                return;
            }

            if (other.GetComponent<Friend>())
            {
                _onWin.Invoke();
            }
        }
    }
}