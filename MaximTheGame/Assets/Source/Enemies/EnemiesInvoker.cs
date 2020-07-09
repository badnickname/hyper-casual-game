using System.Collections.Generic;
using UnityEngine;

namespace Source.Enemies
{
    public class EnemiesInvoker : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies = null;

        public void Activate()
        {
            Invoke(nameof(AwakeMoving), 0.5f);
        }
        
        private void AwakeMoving()
        {
            foreach (var enemy in _enemies)
            {
                enemy.AwakeMoving();
            }
        }
    }
}