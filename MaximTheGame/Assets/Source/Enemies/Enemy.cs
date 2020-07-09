using System;
using Source.Triggers;
using UnityEngine;

namespace Source.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private bool _activated = false;
        [SerializeField] private float _speed = 0.01f;
        [SerializeField] private Blood _blood = null;
        private Rigidbody2D _body;
        private bool _alive = true;
        private AudioSource _audio;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _body = GetComponent<Rigidbody2D>();
        }
        public void Kill()
        {
            if (!_alive) return;

            _alive = false;
            var blood = _blood.Clone() as Blood;
            blood.transform.position = transform.position;
            _body.constraints = RigidbodyConstraints2D.None;
            
            if(transform.position.x > -2.31 && transform.position.x < -0.51) _audio.Play();
            
            Destroy(this);
        }
        public void AwakeMoving()
        {
            _activated = true;
        }
        private void FixedUpdate()
        {
            if (_activated)
            {
                transform.position += Vector3.left * _speed;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.GetComponent<Wall>()) return;
            Kill();
        }
    }
}