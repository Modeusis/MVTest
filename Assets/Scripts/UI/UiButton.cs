using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
    public class UiButton
    {
        [field: SerializeField] public Button Button { get; set; }
        [field: SerializeField] public TMP_Text TextField { get; set; }

        public void SetButtonText(string text)
        {
            TextField.text = text;
        }

        public void SetButtonOnClick(UnityAction onClick)
        {
            Button.onClick.AddListener(onClick);
        }

        public void SetEnabled(bool enabled)
        {
            Button.interactable = enabled;
        }
    }
}