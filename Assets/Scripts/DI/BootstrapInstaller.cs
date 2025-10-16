using System.Collections.Generic;
using Models;
using Setups;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Zenject;

namespace DI
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField, Space] private MvcControllerSetup _mvcControllerSetup;
        
        [SerializeField, Space] private BootstrapMenuButton _mvcExampleButton;
        [SerializeField] private BootstrapMenuButton _mvpExampleButton;
        [SerializeField] private BootstrapMenuButton _mvvmExampleButton;
        
        public override void InstallBindings()
        {
            var buttonsDictionary = new Dictionary<MvPatternType, BootstrapMenuButton>
            {
                { MvPatternType.Mvc, _mvcExampleButton },
                { MvPatternType.Mvp, _mvpExampleButton },
                { MvPatternType.Mvvm, _mvvmExampleButton },
            };
            
            var cubeController = new Bootstrap(buttonsDictionary, _mvcControllerSetup);
            
            Container.BindInterfacesAndSelfTo<Bootstrap>().FromInstance(cubeController);
        }
    }
}