using Base;
using DG.Tweening;
using Setups;
using UI;
using Utilities;

namespace Models
{
    public class CubeControllerMVC : BaseController
    {
        private readonly CubeModelMVC _cubeModel;
        
        private Tween _rotatingTween;
        
        public CubeControllerMVC(MvcControllerSetup controllerSetup, Bootstrap bootstrap)
        {
            Bootstrap = bootstrap;

            ControllerView = controllerSetup.ControllerView;

            _cubeModel = controllerSetup.CubeModel;
        }

        private void RotateCube()
        {
            if (_cubeModel.IsRotating)
            {
                return;
            }
            
            _rotatingTween = _cubeModel.StartRotating(() =>
            {
                ControllerView.UpdateButtons(false);
            });
            
            ControllerView.UpdateButtons(true);
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
            
            ControllerView.UpdateButtons(false);
        }

        public override void ShowView()
        {
            ControllerView.BackButton.onClick.AddListener(HideView);
            
            ControllerView.RotateButton.SetButtonOnClick(RotateCube);
            ControllerView.StopButton.SetButtonOnClick(StopRotating);
            
            ControllerView.UpdateButtons(false);
            
            base.ShowView();
        }
    }
}