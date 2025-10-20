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
        
        public MvvmControllerSetup(ControllerView controllerView, CubeModelMVVM cubeModel)
        {
            ControllerView = controllerView;
            CubeModel = cubeModel;
        }
    }
}