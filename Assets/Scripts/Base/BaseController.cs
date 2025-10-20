using UI;
using Utilities;

namespace Base
{
    public class BaseController
    {
        protected Bootstrap Bootstrap;
        protected ControllerView ControllerView;
        
        public virtual void ShowView()
        {
            ControllerView.gameObject.SetActive(true);
        }
        
        protected virtual void HideView()
        {
            ControllerView.gameObject.SetActive(false);
            
            
            Bootstrap.Show();
        }
    }
}