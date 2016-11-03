using System;

namespace FormsPerformancePlayground
{
    public static class ViewModelLocator
    {
        public static MainPageViewModel MainPageViewModel = new MainPageViewModel();

        public static LargeFormViewModel LargeFormViewModel = new LargeFormViewModel();
    }
}