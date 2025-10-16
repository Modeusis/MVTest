using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class BootstrapMenuButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private TMP_Text _buttonTextField;

        public void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void Initialize(string buttonText, UnityAction clickEvent)
        {
            if (_buttonTextField == null)
            {
                Debug.LogWarning("ButtonTextField should not be null");
                
                return;
            }
            
            _buttonTextField.text = buttonText;
            
            _button.onClick.AddListener(clickEvent);
        }
    }
}