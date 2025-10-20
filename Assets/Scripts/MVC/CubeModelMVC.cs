using System;
using Base;
using DG.Tweening;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CubeModelMVC :  BaseCubeModel
    {
        private Tween _rotatingTween;
        
        private bool _isRotating;
        public bool IsRotating
        {
            get => _isRotating;
            set
            {
                if (_isRotating == value)
                {
                    return;
                }
                
                _isRotating = value;
                
                OnRotatingStateChanged?.Invoke(value);
            }
        }
        
        public Action<bool> OnRotatingStateChanged { get; set; }
        
        public void StartRotating() 
        {
            IsRotating = true;
            
            var currentRotation = CubeTransform.eulerAngles;
            var destination = currentRotation + RotationValue;

            _rotatingTween = CubeTransform.DORotate(destination, RotationDuration, RotateMode.FastBeyond360)
                .OnComplete(() =>
                {
                    IsRotating = false;
                });
        }

        public void StopRotating()
        {
            IsRotating = false;
            
            _rotatingTween?.Kill();
            _rotatingTween = null;
        }
    }
}