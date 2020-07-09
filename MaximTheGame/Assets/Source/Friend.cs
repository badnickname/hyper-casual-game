using System;
using UnityEngine;

namespace Source
{
    public class Friend : MonoBehaviour
    {
        private Animator _animator;
        private bool _activated = false;
        [SerializeField] private float _speed = 0.01f;
        [SerializeField] private Blood _blood = null;
        private Rigidbody2D _body;
        private bool _alive = true;
        private AudioSource _audio;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _body = GetComponent<Rigidbody2D>();
            _audio = GetComponent<AudioSource>();
        }

        private void AwakeMoving()
        {
            _animator.SetInteger("Status", 1);
            _activated = true;
        }

        public void Kill()
        {
            if (!_alive) return;

            _alive = false;
            var blood = _blood.Clone() as Blood;
            blood.transform.position = transform.position;
            _body.constraints = RigidbodyConstraints2D.None;
            
            _audio.Play();
            
            Destroy(this);
        }

        public void Activate()
        {
            Invoke(nameof(AwakeMoving), 0.5f);
        }
        private void FixedUpdate()
        {
            if (_activated)
            {
                transform.position += Vector3.left * _speed;
            }
        }
    }
}