using System;
using System.Collections.Generic;
using Models;
using Setups;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace Utilities
{
    public class Bootstrap
    {
        private readonly ResourceLoader _resourceLoader;
        
        private readonly BootstrapMenu _bootstrapMenu;
        
        private readonly Transform _uiContainer;
        
        private readonly Dictionary<MvPatternType, BootstrapMenuButton> _buttons;
        
        private readonly CubeModelMVC _cubeModelMvc;
        private readonly CubeModelMVVM _cubeModelMvp;
        private readonly CubeModelMVP _cubeModelMvvm;
        
        private ControllerView _controllerView;
        
        private CubeControllerMVC _cubeControllerMvc;
        
        public Bootstrap(Transform uiContainer, BootstrapMenu bootstrapMenu,  Dictionary<MvPatternType,
            BootstrapMenuButton> bootstrapButtons, CubeModelMVC cubeModelMvc, ResourceLoader resourceLoader)
        {
            _uiContainer = uiContainer;
            _bootstrapMenu = bootstrapMenu;
            
            _buttons = bootstrapButtons;
            _cubeModelMvc = cubeModelMvc;
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
            _controllerView ??= _resourceLoader.LoadPrefab<ControllerView>(_uiContainer);
            
            if (_controllerView == null)
            {
                Debug.LogError("ControllerView is null");
                
                return;
            }
            
            _cubeControllerMvc ??= new CubeControllerMVC(new (_controllerView, _cubeModelMvc), this);
            _cubeControllerMvc.ShowView();
            
            Hide();
        }
        
        private void ShowMvpExample()
        {
            
        }
        
        private void ShowMvvmExample()
        {
            
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