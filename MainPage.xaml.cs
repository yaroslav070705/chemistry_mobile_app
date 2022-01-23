using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace chemistry_app
{
    public partial class MainPage : ContentPage
    {
        Label deb_label;
    public MainPage(){
            /*ResourceDictionary diction = new ResourceDictionary();
            diction.Add("bg_color", Color.White);
            diction.Add("text_color", Color.Black);
            diction.Add("button_pic", "change_theme_button_icon2");
            Resources = diction;*/
            StackLayout stacklayout = new StackLayout() { Padding = new Thickness(10 * DeviceDisplay.MainDisplayInfo.Height / 1080),
                                                          Spacing = 100};//{ Margin = new Thickness(10 * DeviceDisplay.MainDisplayInfo.Height / 1080)};
            stacklayout.SetDynamicResource(StackLayout.BackgroundColorProperty, "bg_color");
            Button molar_mass_button = new Button()
            {
                Text = "Молярная масса",
                //BackgroundColor = (Color)Resources["bg_color"],
                //TextColor = (Color)Resources["text_color"],
                BorderWidth = 5 * DeviceDisplay.MainDisplayInfo.Width / 1080,
                //BorderColor = (Color)Resources["text_color"],
                WidthRequest = 300 * DeviceDisplay.MainDisplayInfo.Width / 1080,
                HeightRequest = 30 * DeviceDisplay.MainDisplayInfo.Height / 1080,
                HorizontalOptions = LayoutOptions.Center
            };
            molar_mass_button.SetDynamicResource(Button.BackgroundColorProperty, "bg_color");
            molar_mass_button.SetDynamicResource(Button.TextColorProperty, "text_color");
            molar_mass_button.SetDynamicResource(Button.BorderColorProperty, "text_color");
            Button density_button = new Button()
            {
                Text = "Плотность вещества",
                //BackgroundColor = (Color)Resources["bg_color"],
                //TextColor = (Color)Resources["text_color"],
                BorderWidth = 5 * DeviceDisplay.MainDisplayInfo.Width / 1080,
                //BorderColor = (Color)Resources["text_color"],
                WidthRequest = 300 * DeviceDisplay.MainDisplayInfo.Width / 1080,
                HeightRequest = 30 * DeviceDisplay.MainDisplayInfo.Height / 1080,
                HorizontalOptions = LayoutOptions.Center
            };
            density_button.SetDynamicResource(Button.BackgroundColorProperty, "bg_color");
            density_button.SetDynamicResource(Button.TextColorProperty, "text_color");
            density_button.SetDynamicResource(Button.BorderColorProperty, "text_color");
            ImageButton change_theme_button = new ImageButton()
            {
               // Source = "change_theme_button_icon",
                Aspect = Aspect.Fill,
                //BackgroundColor = (Color)Resources["bg_color"],
                //TextColor = (Color)Resources["text_color"],
                BorderWidth = 5 * DeviceDisplay.MainDisplayInfo.Width / 1080,
                //BorderColor = (Color)Resources["text_color"],
                WidthRequest = 75 * DeviceDisplay.MainDisplayInfo.Width / 1080,
                HeightRequest = 36 * DeviceDisplay.MainDisplayInfo.Height / 1080,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                IsEnabled = true
            };
            change_theme_button.SetDynamicResource(ImageButton.BorderColorProperty, "text_color");
            change_theme_button.SetDynamicResource(ImageButton.SourceProperty, "button_pic");
            deb_label = new Label();
            change_theme_button.Clicked += change_theme_button_func;
            molar_mass_button.Clicked += molar_mass_button_clicked_func;
            density_button.Clicked += density_button_clicked_func;
            stacklayout.Children.Add(molar_mass_button);
            stacklayout.Children.Add(density_button);
            stacklayout.Children.Add(change_theme_button);
            stacklayout.Children.Add(deb_label);
            Content = stacklayout;
           
        }
        
        private async void molar_mass_button_clicked_func(object sender, System.EventArgs e){
            //Button button = (Button)sender;
            //button.Text = "НАЖАЛ))";
            await Navigation.PushAsync(new MolarMassPage());
        }
        private async void density_button_clicked_func(object sender, System.EventArgs e)
        {
            //Button button = (Button)sender;
            //button.Text = "НАЖАЛ))";
            await Navigation.PushAsync(new DensityPage());
        }
        private void change_theme_button_func(object sender, System.EventArgs e){
            if ((Color)Application.Current.Resources["bg_color"] == Color.White && (Color)Application.Current.Resources["text_color"] == Color.Black){
                Application.Current.Resources["bg_color"] = Color.Black;
                Application.Current.Resources["text_color"] = Color.White;
                deb_label.Text = "is";
                Application.Current.Resources["button_pic"] = "change_theme_button_icon";
            }
            else{
                Application.Current.Resources["bg_color"] = Color.White;
                Application.Current.Resources["text_color"] = Color.Black;
                deb_label.Text = "else";
                Application.Current.Resources["button_pic"] = "change_theme_button_icon2";
            }
        }
    }
}
