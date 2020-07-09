using UnityEngine;

namespace Source.Ded
{
    public class Stick : MonoBehaviour, IFreezeable
    {
        [SerializeField] private float _increaseSpeed = 0.01f; 
        private Rigidbody2D _body;
        private PositionState _default;
        void Start()
        {
            _body = GetComponent<Rigidbody2D>();
            _default = new PositionState
            {
                Position = transform.position,
                Rotation = transform.rotation,
                Scale = new Vector3(transform.localScale.x*0.05f, 
                    transform.localScale.y, 
                    transform.localScale.z),
                Object = gameObject
            };
            _default.Reset();
            _default.ResetScale();
        }

        public void Increase()
        {
            _default.Reset();
            transform.localScale += Vector3.right*_increaseSpeed;
        }

        public bool Decrease()
        {
            transform.localScale += _increaseSpeed * 3f * Vector3.left;
            if (transform.localScale.x < _default.Scale.x)
            {
                _default.ResetScale();
                return true;
            }
            return false;
        }

        public void Shake(float force)
        {
            transform.Rotate(0,0,-Mathf.Sign(force)*2);
            _body.angularVelocity = -force;
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