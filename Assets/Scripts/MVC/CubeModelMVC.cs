using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CubeModelMVC
    {
        public bool IsRotating { get; private set; }
        
        [field: SerializeField, Range(1, 10)] public float RotationDuration { get; private set; }
        [field: SerializeField] public Vector3 RotationValue { get; private set; }

        public void StartRotating()
        {
            IsRotating = true;
        }

        public void StopRotating()
        {
            IsRotating = false;
        }
    }
}