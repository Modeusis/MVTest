using Utilities;
using Zenject;

namespace DI
{
    public class ResourceLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ResourceLoader>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}