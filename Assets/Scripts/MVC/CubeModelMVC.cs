using System;
using DG.Tweening;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CubeModelMVC
    {
        public bool IsRotating { get; private set; }
        
        [field: SerializeField, Space] public Transform CubeTransform { get; private set; }
        
        [field: SerializeField, Range(1, 10), Space] public float RotationDuration { get; private set; }
        [field: SerializeField] public Vector3 RotationValue { get; private set; }

        public Tween StartRotating(Action callback = null) 
        {
            IsRotating = true;
            
            var currentRotation = CubeTransform.eulerAngles;
            var destination = currentRotation + RotationValue;

            return CubeTransform.DORotate(destination, RotationDuration, RotateMode.FastBeyond360)
                .OnComplete(() =>
                {
                    IsRotating = false;
                    
                    callback?.Invoke();
                });
        }

        public void StopRotating()
        {
            IsRotating = false;
        }
    }
}