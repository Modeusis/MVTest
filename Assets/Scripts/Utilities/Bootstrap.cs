using System.Collections.Generic;
using Models;
using Setups;
using UI;
using UnityEngine;

namespace Utilities
{
    public class Bootstrap
    {
        private readonly ResourceLoader _resourceLoader;
        
        private readonly BootstrapMenu _bootstrapMenu;
        
        private readonly Transform _uiContainer;
        
        private readonly Dictionary<MvPatternType, BootstrapMenuButton> _buttons;
        
        private readonly CubeModelMVC _cubeModelMvc;
        private readonly CubeModelMVP _cubeModelMvp;
        private readonly CubeModelMVVM _cubeModelMvvm;
        
        private ControllerView _controllerView;
        
        private CubeControllerMVC _cubeControllerMvc;
        private CubeControllerMVP _cubeControllerMvp;
        private CubeControllerMVVM _cubeControllerMvvm;
        
        public Bootstrap(Transform uiContainer, BootstrapMenu bootstrapMenu,  Dictionary<MvPatternType,
            BootstrapMenuButton> bootstrapButtons, CubeModelMVC cubeModelMvc, CubeModelMVP cubeModelMvp,
            CubeModelMVVM cubeModelMvvm, ResourceLoader resourceLoader)
        {
            _uiContainer = uiContainer;
            _bootstrapMenu = bootstrapMenu;
            
            _buttons = bootstrapButtons;
            
            _cubeModelMvc = cubeModelMvc;
            _cubeModelMvp = cubeModelMvp;
            _cubeModelMvvm = cubeModelMvvm;
            
            _resourceLoader = resourceLoader;

            var initButtonsResult = InitializeButtons();

            if (!initButtonsResult.IsSuccess)
            {
                Debug.LogWarning(initButtonsResult.Message);
            }
        }

        public void Show()
        {
            _bootstrapMenu.gameObject.SetActive(true);
        }

        private void Hide()
        {
            _bootstrapMenu.gameObject.SetActive(false);
        }
        
        private void ShowMvcExample()
        {
            var tempView = _resourceLoader.LoadPrefab<ControllerViewMVC>(_uiContainer);
            
            if (tempView == null)
            {
                Debug.LogError("ControllerView is null");
                
                return;
            }
            
            tempView.SetupModel(_cubeModelMvc);
            _controllerView = tempView;
            
            _cubeControllerMvc ??= 
                new CubeControllerMVC(new MvcControllerSetup(_controllerView, _cubeModelMvc), this);
            _cubeControllerMvc.ShowView();
            
            Hide();
        }
        
        private void ShowMvpExample()
        {
            _controllerView ??= _resourceLoader.LoadPrefab<ControllerView>(_uiContainer);
            
            if (_controllerView == null)
            {
                Debug.LogError("ControllerView is null");
                
                return;
            }

            _cubeControllerMvp ??= 
                new CubeControllerMVP(new MvpControllerSetup(_controllerView, _cubeModelMvp), this);
            _cubeControllerMvp.ShowView();
            
            Hide();
        }
        
        private void ShowMvvmExample()
        {
            _controllerView ??= _resourceLoader.LoadPrefab<ControllerView>(_uiContainer);
            
            if (_controllerView == null)
            {
                Debug.LogError("ControllerView is null");
                
                return;
            }

            _cubeControllerMvvm ??=
                new CubeControllerMVVM(new MvvmControllerSetup(_controllerView, _cubeModelMvvm), this);
            _cubeControllerMvvm.ShowView();
            
            Hide();
        }
        
        private OperationResult InitializeButtons()
        {
            if (!_buttons.TryGetValue(MvPatternType.Mvc, out var showMvcButton))
            {
                return OperationResult.Failure("MVC button not found");
            }
            
            showMvcButton.Initialize("Show MVC", ShowMvcExample);
            
            if (!_buttons.TryGetValue(MvPatternType.Mvp, out var showMvpButton))
            {
                return OperationResult.Failure("MVP button not found");
            }
            
            showMvpButton.Initialize("Show MVP", ShowMvpExample);
            
            if (!_buttons.TryGetValue(MvPatternType.Mvvm, out var showMvvmButton))
            {
                return OperationResult.Failure("MVVM button not found");
            }
            
            showMvvmButton.Initialize("Show MVVM", ShowMvvmExample);
            
            return OperationResult.Success();
        }
    }
}