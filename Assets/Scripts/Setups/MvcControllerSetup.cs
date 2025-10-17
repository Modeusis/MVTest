using System;
using Models;
using UI;
using UnityEngine;

namespace Setups
{
    [Serializable]
    public class MvcControllerSetup
    {
        [field: SerializeField, Space] public ControllerViewMVC ControllerViewMvc { get; private set; }
        
        [field: SerializeField, Space] public CubeModelMVC CubeModel { get; private set; }
    }
}