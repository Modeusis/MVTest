using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ControllerView : MonoBehaviour
    {
        [field: SerializeField, Space] public Button BackButton { get; private set; }
        
        [field: SerializeField, Space] public UiButton RotateButton { get; private set; }
        [field: SerializeField] public UiButton StopButton { get; private set; }
        
        public void OnDisable()
        {
            BackButton.onClick.RemoveAllListeners();
            
            RotateButton.Clear();
            StopButton.Clear();
        }
        
        public void UpdateButtons(bool isCubeRotating)
        {
            if (isCubeRotating)
            {
                SetupButton(RotateButton, "Cube is now rotating", false);
                SetupButton(StopButton, "Stop rotating");
                
                return;
            }
            
            SetupButton(RotateButton, "Rotate cube");
            SetupButton(StopButton, "Cube is not rotating", false);
        }
        
        private void SetupButton(UiButton button, string text, bool isEnabled = true)
        {
            button.SetEnabled(isEnabled);
            button.SetButtonText(text);
        }
    }
}