using System;
using System.Collections.Generic;
using Setups;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Utilities
{
    public class Bootstrap
    {
        private readonly MvcControllerSetup _mvcControllerSetup;
        
        private readonly Dictionary<MvPatternType, BootstrapMenuButton> _buttons;
        
        public Bootstrap(Dictionary<MvPatternType, BootstrapMenuButton> bootstrapButtons, MvcControllerSetup mvcControllerSetup)
        {
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
        
        private void ShowMvcExample()
        {
            Debug.Log("Show mvc example");
        }
        
        private void ShowMvpExample()
        {
            Debug.Log("Show mvp example");
        }
        
        private void ShowMvvmExample()
        {
            Debug.Log("Show mvvm example");
        }
    }


    public enum MvPatternType
    {
        Mvc,
        Mvp,
        Mvvm
    }

    public class OperationResult
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        private OperationResult(bool isSuccess, string message = "Empty message")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        
        public static OperationResult Success()
        {
            return new OperationResult(true);
        }

        
        public static OperationResult Failure(string errorMessage)
        {
            return new OperationResult(false, errorMessage);
        }
    }
}