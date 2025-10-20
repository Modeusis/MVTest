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
            _disposables?.Dispose();

            _disposables = new CompositeDisposable();
            
            ControllerView.BackButton
                .OnClickAsObservable()
                .Subscribe(_ => HideView())
                .AddTo(_disposables);
            
            ControllerView.RotateButton.Button
                .OnClickAsObservable()
                .Subscribe(_ => _cubeModel.RotateCube())
                .AddTo(_disposables);
            
            ControllerView.StopButton.Button
                .OnClickAsObservable()
                .Subscribe(_ => _cubeModel.StopRotate())
                .AddTo(_disposables);
            
            SubscribeToModelChanges();
        }

        private void SubscribeToModelChanges()
        {
            _cubeModel.IsRotating
                .Subscribe(rotating =>
                {
                    ControllerView.UpdateButtons(rotating);
                })
                .AddTo(_disposables);
        }
        
        public override void ShowView() 
        {
            SetupEventHandlers();
            
            base.ShowView();
        }
        
        protected override void HideView()
        {
            _disposables?.Dispose();   
            
            base.HideView();
        }
    }
}