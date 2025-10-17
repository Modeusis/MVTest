using DG.Tweening;
using Setups;
using UI;
using Utilities;

namespace Models
{
    public class CubeControllerMVC
    {
        private readonly Bootstrap _bootstrap;
     
        private readonly ControllerViewMVC _controllerViewMvc;
        
        private readonly CubeModelMVC _cubeModel;
        
        private Tween _rotatingTween;
        
        public CubeControllerMVC(MvcControllerSetup controllerSetup, Bootstrap bootstrap)
        {
            _bootstrap = bootstrap;

            _controllerViewMvc = controllerSetup.ControllerViewMvc;
            _controllerViewMvc.View.SetActive(true);

            _cubeModel = controllerSetup.CubeModel;
            
            _controllerViewMvc.BackButton.onClick.AddListener(HideView);
            
            _controllerViewMvc.RotateButton.SetButtonOnClick(RotateCube);
            _controllerViewMvc.StopButton.SetButtonOnClick(StopRotating);
            
            _controllerViewMvc.UpdateButtons(false);
        }

        private void RotateCube()
        {
            if (_cubeModel.IsRotating)
            {
                return;
            }
            
            _rotatingTween = _cubeModel.StartRotating(() =>
            {
                _controllerViewMvc.UpdateButtons(false);
            });
            
            _controllerViewMvc.UpdateButtons(true);
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
            
            _controllerViewMvc.UpdateButtons(false);
        }
        
        private void HideView()
        {
            _controllerViewMvc.View.SetActive(false);
            
            _bootstrap.Show();
        }
    }
}