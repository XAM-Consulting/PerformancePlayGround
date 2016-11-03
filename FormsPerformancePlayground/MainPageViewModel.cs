using System.Threading.Tasks;

namespace FormsPerformancePlayground
{
    public class MainPageViewModel
    {
        LargeFormStackLayout _largeFormStackLayout;
        LargeFormGrid _largeFormGrid;

        public MainPageViewModel()
        {
            Task.Run(() =>
            {
                InflateViews();
            });
        }

        void InflateViews()
        {
            _largeFormStackLayout = new LargeFormStackLayout();
            _largeFormGrid = new LargeFormGrid();
        }

        public System.Windows.Input.ICommand FormStackTapped
        {
            get
            {
                return new Xamarin.Forms.Command(() =>
                {
                    Xamarin.Forms.Performance.Clear();
                    App.Nav.PushAsync(_largeFormStackLayout); 
                }
                );
            }
        }

        public System.Windows.Input.ICommand FormGridTapped
        {
            get
            {
                return new Xamarin.Forms.Command(() =>
                {
                    Xamarin.Forms.Performance.Clear();
                    App.Nav.PushAsync(_largeFormGrid);
                }

                );
            }
        }
        
    }
}