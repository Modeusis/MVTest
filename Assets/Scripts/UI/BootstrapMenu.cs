using UnityEngine;

namespace UI
{
    public class BootstrapMenu : MonoBehaviour
    {
        [field: SerializeField, Space] public BootstrapMenuButton MvcExampleButton {get; private set;}
        [field: SerializeField] public BootstrapMenuButton MvpExampleButton {get; private set;}
        [field: SerializeField] public BootstrapMenuButton MvvmExampleButton {get; private set;}
    }
}