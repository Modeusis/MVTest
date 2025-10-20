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
        [SerializeField, Space] private BootstrapMenu _bootstrapMenu;
        [SerializeField, Space] private RectTransform _uiContainer;
        
        [SerializeField, Space] private CubeModelMVC _cubeModelMvc;
        [SerializeField] private CubeModelMVP _cubeModelMvp;
        [SerializeField] private CubeModelMVVM _cubeModelMvvm;
        
        public override void InstallBindings()
        {
            var buttonsDictionary = new Dictionary<MvPatternType, BootstrapMenuButton>
            {
                { MvPatternType.Mvc, _bootstrapMenu.MvcExampleButton },
                { MvPatternType.Mvp, _bootstrapMenu.MvpExampleButton },
                { MvPatternType.Mvvm, _bootstrapMenu.MvvmExampleButton },
            };

            var loader = Container.Resolve<ResourceLoader>();

            var bootstrap = new Bootstrap(_uiContainer, _bootstrapMenu, buttonsDictionary, _cubeModelMvc,
                _cubeModelMvp, _cubeModelMvvm, loader);

            Container.BindInterfacesAndSelfTo<Bootstrap>()
                .FromInstance(bootstrap)
                .AsSingle();
        }
    }
}