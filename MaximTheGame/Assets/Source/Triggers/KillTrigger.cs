using UnityEngine;
using UnityEngine.Events;

namespace Source.Triggers
{
    public class KillTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onKill = null;
        [SerializeField] private Friend _friend = null;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.GetComponent<ExitTrigger>() != null) return;
            _friend.Kill();
            _onKill.Invoke();
        }
    }
}