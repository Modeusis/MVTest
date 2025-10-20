using Base;
using Setups;
using Utilities;

namespace Models
{
    public class CubeControllerMVC : BaseController
    {
        private readonly CubeModelMVC _cubeModel;
        
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
            
            _cubeModel.StartRotating();
        }

        private void StopRotating()
        {
            if (!_cubeModel.IsRotating)
            {
                return;
            }
            
            _cubeModel.StopRotating();
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