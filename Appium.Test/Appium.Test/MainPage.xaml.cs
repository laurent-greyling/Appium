using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Appium.Test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var label = new Label
            {
                Text = "This is the MainPage",
                FontFamily = "Arial",
                FontSize = 20,
                AutomationId = "MainPage"                
            };

            var button = new Button
            {
                Text = "Next",
                BackgroundColor = Color.Transparent,
                BorderColor = Color.LightGray,
                BorderWidth = 1,
                AutomationId = "NextButton"
            };

            var entry = new Entry
            {
                AutomationId = "entryBox"
            };

            button.Clicked += (sender, e) => 
            {
                if (!entry.Text.Contains("Text entered"))
                {
                    entry.Text = $"Text entered {entry.Text}";
                    return;
                }

                entry.Text = entry.Text.Replace("Text entered ","");
            };

            Content = new ContentView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        label,
                        button,
                        entry
                    }
                }
            };
        }
    }
}
