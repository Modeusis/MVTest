using System;
using UI;

namespace Models
{
    public class ControllerViewMVC : ControllerView
    {
        private CubeModelMVC _cubeModelMVC;

        protected override void OnDisable()
        {
            base.OnDisable();
            
            if (_cubeModelMVC != null)
            {
                _cubeModelMVC.OnRotatingStateChanged -= UpdateButtons;
                _cubeModelMVC = null;
            }
        }

        public void SetupModel(CubeModelMVC model)
        {
            if (_cubeModelMVC != null)
            {
                return;
            }
            
            _cubeModelMVC = model;
            _cubeModelMVC.OnRotatingStateChanged += UpdateButtons;
            UpdateButtons(_cubeModelMVC.IsRotating);
        }
    }
}