using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class CubeRotatingController
    {
        private readonly CubeModelMVC _cubeModel;
        private readonly Transform _cubeViewTransform;
        
        private readonly UiButton _rotateCubeButton;
        private readonly UiButton _stopRotatingButton;
        
        private Tween _rotatingTween;
        
        public CubeRotatingController(Transform cubeViewTransform,CubeModelMVC cubeModel,
            UiButton rotateCubeButton, UiButton stopRotatingButton)
        {
            _cubeViewTransform = cubeViewTransform;
            _cubeModel = cubeModel;
            
            _rotateCubeButton = rotateCubeButton;
            _stopRotatingButton = stopRotatingButton;
            
            _rotateCubeButton.SetButtonOnClick(RotateCube);
            _stopRotatingButton.SetButtonOnClick(StopRotating);
            
            UpdateButton(false);
        }

        private void RotateCube()
        {
            if (_cubeModel.IsRotating)
            {
                return;
            }
            
            _cubeModel.StartRotating();
            
            var currentRotation = _cubeViewTransform.eulerAngles;
            var destination = currentRotation + _cubeModel.RotationValue;

            _rotatingTween = _cubeViewTransform.DORotate(destination, _cubeModel.RotationDuration, RotateMode.FastBeyond360)
                .OnComplete(() =>
                {
                    _cubeModel.StopRotating();
                    
                    UpdateButton(false);   
                });
            
            UpdateButton(true);
        }

        private void StopRotating()
        {
            if (!_cubeModel.IsRotating || _rotatingTween == null)
            {
                return;
            }
            
            _cubeModel.StopRotating();
            
            _rotatingTween?.Kill();
            _rotatingTween = null;
            
            UpdateButton(false);
        }

        private void SetupButton(UiButton button, string text, bool enabled = true)
        {
            button.SetEnabled(enabled);
            button.SetButtonText(text);
        }
        
        private void UpdateButton(bool isCubeRotating)
        {
            if (isCubeRotating)
            {
                SetupButton(_rotateCubeButton, "Cube is now rotating", false);
                SetupButton(_stopRotatingButton, "Stop rotating");
                
                return;
            }
            
            SetupButton(_rotateCubeButton, "Rotate cube");
            SetupButton(_stopRotatingButton, "Cube is not rotating", false);
        }
    }
}