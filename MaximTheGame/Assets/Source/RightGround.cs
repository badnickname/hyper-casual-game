using System.Collections;
using UnityEngine;

namespace Source
{
    public class RightGround : MonoBehaviour
    {
        private PositionState _position;
        private bool _endAnimation = false;
        
        private void Start()
        {
            _position = new PositionState
            {
                Position = transform.position + Random.Range(0, 3f)*Vector3.left,
                Rotation = transform.rotation,
                Scale = transform.localScale,
                Object = gameObject
            };

            _position.Reset();
            transform.position += Vector3.down*5f;
            StartCoroutine(nameof(AnimationCoroutine), this);
        }

        private IEnumerator AnimationCoroutine(RightGround ground)
        {
            while (true)
            {
                ground.transform.position += Vector3.up*0.5f;
                if (ground.transform.position.y > ground._position.Position.y)
                {
                    ground._position.Reset();
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
        }

        public void OnEndScene()
        {
            if (!_endAnimation)
            {
                Invoke(nameof(InvokeCoroutine), 0.6f);
                _endAnimation = true;
            }
        }

        private void InvokeCoroutine()
        {
            StartCoroutine(AnimationDownCoroutine(this));
        }
        
        private IEnumerator AnimationDownCoroutine(RightGround ground)
        {
            while (true)
            {
                ground.transform.position += Vector3.down*0.4f;
                if (ground.transform.position.y < ground._position.Position.y-4f)
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}