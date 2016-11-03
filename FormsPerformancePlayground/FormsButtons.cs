using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsPerformancePlayground
{
    public class FormButtons : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IList), typeof(FormButtons), null, BindingMode.TwoWay, null, new BindableProperty.BindingPropertyChangedDelegate(FormButtons.OnItemsSourceChanged), null, null, null);
        public static readonly BindableProperty TappedCommandProperty = BindableProperty.Create("TappedCommand", typeof(Command), typeof(FormButtons), default(Command));

        private int _buttonsPerRow;
        public int ButtonsPerRow
        {
            get
            {
                return _buttonsPerRow;
            }
            set
            {
                _buttonsPerRow = value;
                //Draw();
            }
        }

        public int ButtonWidth { get; set; }
        public int ButtonRadius { get; set; }
        public Color ButtonBackgroundColor { get; set; }

        public IList ItemsSource
        {
            get { return (IList)base.GetValue(FormButtons.ItemsSourceProperty); }
            set { base.SetValue(FormButtons.ItemsSourceProperty, value); }
        }

        public FormButtons()
        {
            //var button = new Button();
            //button.Text = "test";

            //Draw();

            //Content = button;
            //Content = new Label { Text = "Hello ContentView" };

            /*mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(600) });
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

            Content = mainGrid;*/
        }

        private void testerror()
        {
            for (int i = 0; i < 6; i++)
            {

                System.Diagnostics.Debug.WriteLine("blah#1: " + i);
            }

            for (int i = 0; i < 3; i++)
            {
                System.Diagnostics.Debug.WriteLine("balah#2: " + i);
            }
        }

        private void Draw()
        {
            //testerror();
            if (ButtonsPerRow > 0 && ItemsSource != null)
            {
                int numItems = 0;
                try
                {
                    numItems = ItemsSource.Count;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("error in formsButton: " + ex);
                }
                if (numItems > ButtonsPerRow)
                {
                    //grid
                    var mainGrid = new Grid();

                    for (int j = 0; j < ButtonsPerRow; j++)
                    {

                        mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(ButtonWidth) });
                    }
                    //mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });

                    for (int i = 0; i < numItems; i++)
                    {
                        int x = i % ButtonsPerRow;
                        int y = 0;

                        if (i == 0)
                        {
                            y = 0;
                        }
                        else
                        {
                            double ydouble = (double)i / (double)ButtonsPerRow;
                            if (ydouble % 1 != 0)
                                ydouble -= 1;
                            y = (int)Math.Ceiling(ydouble);

                        }
                        //System.Diagnostics.Debug.WriteLine("Button" + i + ": " + "x:" + x + " y:" + y);

                        var button = GetNewStyledButton(ItemsSource[i].ToString());
                        mainGrid.Children.Add(button, x, y);
                        button.SetBinding(Button.CommandProperty, new Binding("TappedCommand"));
                        button.CommandParameter = ItemsSource[i].ToString();
                    }

                    Content = mainGrid;
                }
                else if (numItems <= ButtonsPerRow && numItems > 0)
                {
                    //stack
                    StackLayout stack = new StackLayout();
                    stack.Orientation = StackOrientation.Horizontal;
                    //stack.WidthRequest = 110;


                    //List<Button> buttonList = new List<Button>();
                    for (int i = 0; i < numItems; i++)
                    {
                        var button = GetNewStyledButton(ItemsSource[i].ToString());
                        button.WidthRequest = ButtonWidth;

                        //button.HeightRequest = 100;
                        stack.Children.Add(button);
                        button.SetBinding(Button.CommandProperty, new Binding("TappedCommand"));
                        button.CommandParameter = ItemsSource[i].ToString();

                        //buttonList.Add(GetNewStyledButton(ItemsSource[i].ToString());
                    }
                    Content = stack;
                }
            }
            else
            {
                StackLayout stack = new StackLayout();
                var errorlabel = new Label { Text = "You have not specified the ButtonsPerRow or ItemSourceProperty" };
                errorlabel.TextColor = Color.Red;
                errorlabel.FontSize = 20.0;

                stack.Children.Add(errorlabel);
                Content = stack;
            }
        }

        public Command TappedCommand
        {
            get { return (Command)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        private Button GetNewStyledButton(string text)
        {
            var button = new Button() { Text = text };
            //style button here
            if (ButtonRadius > 0)
                button.BorderRadius = ButtonRadius;
            else
                button.BorderRadius = 10;

            if (ButtonBackgroundColor != new Color())
                button.BackgroundColor = ButtonBackgroundColor;
            else
                button.BackgroundColor = Color.Silver;

            return button;
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            FormButtons buttons = (FormButtons)bindable;
            buttons.ItemsSource = (IList)newValue;
            buttons.Draw();
        }


    }
}


