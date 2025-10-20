using System;
using Models;
using UI;
using UnityEngine;

namespace Setups
{
    public class MvcControllerSetup
    {
        public ControllerView ControllerView { get; private set; }
        
        public CubeModelMVC CubeModel { get; private set; }
        
        public MvcControllerSetup(ControllerView controllerView, CubeModelMVC cubeModel)
        {
            ControllerView = controllerView;
            CubeModel = cubeModel;
        }
    }
}