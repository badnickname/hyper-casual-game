using System;
using System.Collections;
using UnityEngine;

namespace Source.EndGameScreen
{
    public class BackgroundScreen : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private AudioSource _audio;
        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            
            _spriteRenderer = GetComponent<SpriteRenderer>();
            var color = _spriteRenderer.material.color;
            color.a = 0;
            _spriteRenderer.material.color = color;
        }

        public void Show()
        {
            if(!_audio.isPlaying) _audio.Play();
            Invoke(nameof(InvokedAlphaMethod), 0.5f);
        }

        private void InvokedAlphaMethod()
        {
            StartCoroutine(AlphaCoroutine(_spriteRenderer));
        }

        private IEnumerator AlphaCoroutine(SpriteRenderer renderer)
        {
            while (true)
            {
                var color = renderer.material.color;
                if (color.a + 0.05f > 1f)
                {
                    color.a = 1;
                    renderer.material.color = color;
                    break;
                }
                
                color.a += 0.05f;
                renderer.material.color = color;
                
                yield return new WaitForEndOfFrame();
            }
        }
    }
}