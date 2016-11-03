using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsPerformancePlayground
{
    public partial class LargeFormStackLayout : ContentPage
    {
        public LargeFormStackLayout()
        {
            InitializeComponent();
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            DateTime dt1 = DateTime.Now;
            base.LayoutChildren(x, y, width, height);
            DateTime dt2 = DateTime.Now;

            TimeSpan span = dt2 - dt1;
            int ms = (int)span.TotalMilliseconds;
            System.Diagnostics.Debug.WriteLine("Difference for stack in milliseconds is: " + ms);
        }
    }
}
