using Base;
using R3;
using Setups;
using UI;
using Utilities;

namespace Models
{
    public class CubeControllerMVVM : BaseController
    {
        private readonly CubeModelMVVM _cubeModel;
        
        private CompositeDisposable _disposables;
        
        public CubeControllerMVVM(MvvmControllerSetup mvvmSetup, Bootstrap bootstrap)
        {
            Bootstrap = bootstrap;
            
            _cubeModel = mvvmSetup.CubeModel;
            
            ControllerView = mvvmSetup.ControllerView;
            ControllerView.UpdateButtons(false);
            
            _disposables = new CompositeDisposable();
        }

        private void SetupEventHandlers()
        {
            ControllerView.BackButton
                .OnClickAsObservable()
                .Subscribe(_ => HideView())
                .AddTo(_disposables);
            
            ControllerView.RotateButton.Button
                .OnClickAsObservable()
                .Subscribe(_ => RotateCube())
                .AddTo(_disposables);
            
            ControllerView.StopButton.Button
                .OnClickAsObservable()
                .Subscribe(_ => StopRotateCube())
                .AddTo(_disposables);
            
            SubscribeToModelChanges();
        }

        private void SubscribeToModelChanges()
        {
            
        }
        
        private void RotateCube()
        {
            
        }

        private void StopRotateCube()
        {
            
        }
    }
}