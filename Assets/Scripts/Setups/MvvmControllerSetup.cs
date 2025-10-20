using System;
using Models;
using UI;
using UnityEngine;

namespace Setups
{
    [Serializable]
    public class MvvmControllerSetup 
    {
        [field: SerializeField, Space] public ControllerView ControllerView { get; private set; }
        
        [field: SerializeField, Space] public CubeModelMVVM CubeModel { get; private set; }
    }
}