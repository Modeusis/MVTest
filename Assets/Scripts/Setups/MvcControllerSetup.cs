using System;
using Models;
using UI;
using UnityEngine;

namespace Setups
{
    [Serializable]
    public class MvcControllerSetup
    {
        [SerializeField, Space] private CubeModelMVC _cubeModel;
        [SerializeField, Space] private Transform _cubeViewTransform;
        
        [SerializeField, Space] private UiButton _rotateCubeButton;
        [SerializeField] private UiButton _stopRotatingButton;
    }
}