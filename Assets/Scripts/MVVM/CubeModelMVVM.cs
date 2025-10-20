using System;
using Base;
using DG.Tweening;
using R3;

namespace Models
{
    [Serializable]
    public class CubeModelMVVM : BaseCubeModel
    {
        public ReactiveProperty<bool> IsRotating { get; } = new (false);
        
        private Tween _rotateTween;
        
        public void RotateCube()
        {
            if (IsRotating.Value)
            {
                return;
            }    
            
            IsRotating.Value = true;
            
            var currentRotation = CubeTransform.eulerAngles;
            var destination = currentRotation + RotationValue;
            
            _rotateTween = CubeTransform.DORotate(destination, RotationDuration, RotateMode.FastBeyond360)
                .OnComplete(() =>
                {
                    IsRotating.Value = false;
                });
        }

        public void StopRotate()
        {
            if (!IsRotating.Value || _rotateTween == null)
            {
                return;
            }
            
            _rotateTween?.Kill();
            _rotateTween = null;
            
            IsRotating.Value = false;
        }
    }
}