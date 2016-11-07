using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsPerformancePlayground
{
    public partial class StackLayoutSample : ContentPage
    {
        int counter = 0;
        public StackLayoutSample()
        {
            InitializeComponent();
            
            Device.StartTimer(TimeSpan.FromMilliseconds(500), Timer);
        }

        bool Timer()
        {
            counterLabel.Text = $"counter {counter}";
            counter++;
            return counter < 20;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            mainLayout.Children.Add(new Label { Text = DateTime.Now.ToString() });
        }

    }
}
