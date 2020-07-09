using System;
using UnityEngine;

namespace Source
{
    public class Soundtrack : MonoBehaviour
    {
        private static bool _loop;
        private AudioSource _audio;
        private void Start()
        {
            if (!_loop)
            {
                _loop = true;
                _audio = GetComponent<AudioSource>();
                DontDestroyOnLoad(_audio);
                _audio.Play();
            }
        }
    }
}