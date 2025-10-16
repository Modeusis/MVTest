using Models;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DI
{
    public class MVCInstaller : MonoInstaller
    {
        [SerializeField, Space] private CubeModelMVC _cubeModel;
        [SerializeField, Space] private Transform _cubeViewTransform;
        
        [SerializeField, Space] private UiButton _rotateCubeButton;
        [SerializeField] private UiButton _stopRotatingButton;
        
        public override void InstallBindings()
        {
            var cubeController = new CubeRotatingController(_cubeViewTransform, _cubeModel, _rotateCubeButton, _stopRotatingButton);
            
            Container.BindInterfacesAndSelfTo<CubeRotatingController>().FromInstance(cubeController);
        }
    }
}