using System;
using Base;
using DG.Tweening;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CubeModelMVC :  BaseCubeModel
    {
        public bool IsRotating { get; private set; }
        
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