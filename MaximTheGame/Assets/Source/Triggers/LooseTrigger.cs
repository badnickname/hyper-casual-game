using System;
using Source.Ded;
using Source.Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace Source.Triggers
{
    public class LooseTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onLost = null;
        private AudioSource _audio;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>() != null || other.GetComponent<Stick>() != null)
            {
                _audio.Play();
                _onLost.Invoke();
            }
        }
    }
}