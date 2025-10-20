using System;
using UnityEngine;

namespace Base
{
    [Serializable]
    public class BaseCubeModel
    {
        public bool IsRotating { get; protected set; }
        
        [field: SerializeField, Space] public Transform CubeTransform { get; protected set; }
        
        [field: SerializeField, Range(1, 10), Space] public float RotationDuration { get; protected set; }
        [field: SerializeField] public Vector3 RotationValue { get; protected set; }
    }
}