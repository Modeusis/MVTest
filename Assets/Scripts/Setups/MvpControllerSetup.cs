using Models;
using UI;

namespace Setups
{
    public class MvpControllerSetup
    {
        public ControllerView ControllerView { get; private set; }
        
        public CubeModelMVP CubeModel { get; private set; }
        
        public MvpControllerSetup(ControllerView controllerView, CubeModelMVP cubeModel)
        {
            ControllerView = controllerView;
            CubeModel = cubeModel;
        }   
    }
}