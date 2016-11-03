using System;
using Xamarin.Forms;

namespace FormsPerformancePlayground
{
    public class YesNoFormSection : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(YesNoFormSection), default(string));
        public static readonly BindableProperty YesCommandProperty = BindableProperty.Create("YesCommand", typeof(Command), typeof(YesNoFormSection), default(Command));
        public static readonly BindableProperty NoCommandProperty = BindableProperty.Create("NoCommand", typeof(Command), typeof(YesNoFormSection), default(Command));

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
                //return _titleLabel.Text;
            }
            set
            {
                SetValue(TitleProperty, value);
                //SetValue(_titleLabel, value);
                _titleLabel.Text = value;
            }
        }
        bool YesButtonSelected = false;


        public Command YesCommand
        {
            get { return (Command)GetValue(YesCommandProperty); }
            set { SetValue(YesCommandProperty, value); }
        }

        public Command NoCommand
        {
            get { return (Command)GetValue(NoCommandProperty); }
            set { SetValue(NoCommandProperty, value); }
        }

        Label _titleLabel;
        private bool YesPressed = false;
        private bool NoPressed = false;

        public YesNoFormSection()
        {

            var mainGrid = new Grid();
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(600) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });

            _titleLabel = new Label { };
            mainGrid.Children.Add(_titleLabel, 0, 0);
            _titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
            _titleLabel.BindingContext = this;

            var yesButton = new Button { Text = "Yes" };
            mainGrid.Children.Add(yesButton, 1, 0);
            yesButton.SetBinding(Button.CommandProperty, new Binding("YesCommand"));
            yesButton.BorderRadius = 30;
            yesButton.BackgroundColor = Color.Silver;


            var noButton = new Button { Text = "No" };
            mainGrid.Children.Add(noButton, 2, 0);
            noButton.SetBinding(Button.CommandProperty, new Binding("NoCommand"));
            noButton.BorderRadius = 30;
            noButton.BackgroundColor = Color.Silver;

            yesButton.Clicked += (sender, e) =>
            {
                if (YesPressed == false)
                {
                    yesButton.BackgroundColor = Color.Yellow;
                    noButton.BackgroundColor = Color.Silver;

                    YesPressed = true;
                    NoPressed = false;
                }
            };

            noButton.Clicked += (sender, e) =>
            {
                if (NoPressed == false)
                {
                    noButton.BackgroundColor = Color.Yellow;
                    yesButton.BackgroundColor = Color.Silver;

                    NoPressed = true;
                    YesPressed = false;
                }
            };

            Content = mainGrid;
        }
    }
}
