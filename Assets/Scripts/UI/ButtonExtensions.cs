using R3;
using UnityEngine.UI;

namespace UI
{
    public static class ButtonExtensions
    {
        public static Observable<Unit> OnClickAsObservable(this Button button)
        {
            return Observable.FromEvent(
                h => button.onClick.AddListener(() => h()),
                h => button.onClick.RemoveListener(() => h())
            );
        }
    }
}