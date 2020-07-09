using System;
using UnityEngine;

namespace Source
{
    public class Blood : MonoBehaviour, ICloneable
    {
        private ParticleSystem _particle;
        private void Start()
        {
            _particle = GetComponent<ParticleSystem>();
        }

        public void Burst()
        {
            _particle.Play();
        }

        public object Clone()
        {
            var obj = Instantiate(this);
            obj.Invoke(nameof(Burst), 0.01f);
            return obj;
        }
    }
}