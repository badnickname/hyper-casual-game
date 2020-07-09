using System;
using Source.Ded;
using UnityEngine;
using UnityEngine.Events;

namespace Source.Triggers
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onStickTouched = null;
        private AudioSource _audio;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Stick>() != null)
            {
                _onStickTouched.Invoke();
                _audio.Play();
            }
        }
    }
}