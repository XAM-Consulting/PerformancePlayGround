using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsPerformancePlayground
{
    public partial class GridLayoutSample : ContentPage
    {
        int counter = 0;

        public GridLayoutSample()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(500), Timer);
        }

        bool Timer()
        {
            //counterLabel.Text = $"counter {counter}";
            box.WidthRequest = counter % 2 * 10 + 5;
            counter++;
            return counter < 20;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //mainLayout.Children.Add(new Label { Text = DateTime.Now.ToString() });
        }
    }
}
