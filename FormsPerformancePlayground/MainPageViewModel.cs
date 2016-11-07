using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsPerformancePlayground
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
        }

        public System.Windows.Input.ICommand StackTapped
        {
            get
            {
                return new Xamarin.Forms.Command(() =>
                {
                    Xamarin.Forms.Performance.Clear();
                    Performance.Start("PageLoaded", "PageLoaded", "PageLoaded");
                    App.Nav.PushAsync(new StackLayoutSample()); 
                }
                );
            }
        }

        public System.Windows.Input.ICommand GridTapped
        {
            get
            {
                return new Xamarin.Forms.Command(() =>
                {
                    Xamarin.Forms.Performance.Clear();
                    Performance.Start("PageLoaded", "PageLoaded", "PageLoaded");
                    App.Nav.PushAsync(new GridLayoutSample());
                }

                );
            }
        }
        
    }
}