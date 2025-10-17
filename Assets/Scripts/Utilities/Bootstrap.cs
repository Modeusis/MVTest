using System;
using System.Collections.Generic;
using Models;
using Setups;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Utilities
{
    public class Bootstrap
    {
        private readonly GameObject _bootstrapMenu;
        
        private readonly MvcControllerSetup _mvcControllerSetup;
        
        private readonly Dictionary<MvPatternType, BootstrapMenuButton> _buttons;
        
        private CubeControllerMVC _cubeControllerMvc;
        
        public Bootstrap(GameObject bootstrapMenu, Dictionary<MvPatternType, BootstrapMenuButton> bootstrapButtons, MvcControllerSetup mvcControllerSetup)
        {
            _bootstrapMenu = bootstrapMenu;
            
            _mvcControllerSetup = mvcControllerSetup;
            
            _buttons = bootstrapButtons;

            var initButtonsResult = InitializeButtons();

            if (!initButtonsResult.IsSuccess)
            {
                Debug.LogWarning(initButtonsResult.Message);
            }
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

        public void Show()
        {
            _bootstrapMenu.SetActive(true);
        }

        public void Hide()
        {
            _bootstrapMenu.SetActive(false);
        }
        
        private void ShowMvcExample()
        {
            _cubeControllerMvc = new CubeControllerMVC(_mvcControllerSetup , this);
            
            Hide();
        }
        
        private void ShowMvpExample()
        {
            
        }
        
        private void ShowMvvmExample()
        {
            
        }
    }
}