using UnityEngine;

namespace Source
{
    public class PositionState
    {
        public GameObject Object { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public void Reset()
        {
            Object.transform.position = Position;
            Object.transform.rotation = Rotation;
        }

        public void ResetScale()
        {
            Object.transform.localScale = Scale;
        }
    }
}