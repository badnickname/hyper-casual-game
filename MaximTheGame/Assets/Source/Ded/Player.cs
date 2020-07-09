using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Ded
{
    public class Player : MonoBehaviour, IFreezeable
    {
        private Rigidbody2D _body;
        private PositionState _default;
        private Animator _animator;
        [SerializeField] private Stick _stick = null;
        private AudioSource _audio;
        void Start()
        {
            _animator = GetComponent<Animator>();
            
            _body = GetComponent<Rigidbody2D>();
            _default = new PositionState
            {
                Position = transform.position,
                Rotation = transform.rotation,
                Scale = transform.localScale,
                Object = gameObject
            };
            Freeze();
            
            _audio = GetComponent<AudioSource>();
        }

        public void Increase()
        {
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
            
            _animator.SetInteger("Status", 1);
            _stick.Increase();
            _stick.Freeze();
        }

        public IEnumerator DecreaseCoroutine(Player player)
        {
            while (!player.Decrease())
            {
                yield return new WaitForEndOfFrame();
            }
        }
        
        public bool Decrease()
        {
            _animator.SetInteger("Status", 0);
            _stick.Freeze();
            return _stick.Decrease();
        }

        public void Shake(float v)
        {
            _audio.Stop();
            
            Unfreeze();
            _stick.Unfreeze();
            _stick.Shake(v);
        }

        public void Freeze()
        {
            _body.velocity = default;
            _body.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        public void Unfreeze()
        {
            _body.constraints = RigidbodyConstraints2D.None;
        }
    }
}
