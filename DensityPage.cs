using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace chemistry_app
{
    public class DensityPage : ContentPage
    {
        delegate bool IsLower(char element);
        Entry entry;
        Label label;
        Dictionary<string, List<int>> elements;
        public DensityPage()
        {
            StackLayout stacklayout = new StackLayout() { Padding = new Thickness(10 * DeviceDisplay.MainDisplayInfo.Height / 1080) };
            stacklayout.SetDynamicResource(StackLayout.BackgroundColorProperty, "bg_color");
            entry = new Entry() { BackgroundColor = Color.White };
            entry.Completed += Entry_TextCompleted;
            label = new Label(); //{ Text = $"{elements["Cl"][0]}" };
            label.SetDynamicResource(Label.TextColorProperty, "text_color");
            elements = (Dictionary<string, List<int>>)App.Current.Properties["elements"];
            stacklayout.Children.Add(entry);
            stacklayout.Children.Add(label);
            Content = stacklayout;
        }

        private void Entry_TextCompleted(object sender, EventArgs e)
        {
            string entered_sting = entry.Text;
            string ent_element = "";
            IsLower isLower = (char element) => element.Equals(char.ToLower(element));
            if (entered_sting != null && entered_sting != "")
            {
                for(int  i = 0; i < entered_sting.Length; i++)
                {
                    var letter = entered_sting[i];
                    if(char.IsDigit(letter) || (isLower(letter)  && ent_element.Length == 0)){
                        label.Text = "Error";
                        return;
                    }
                    if (!isLower(letter))
                    {
                        if(ent_element.Length == 0)
                        {
                            ent_element += letter;
                        }
                        else
                        {
                            label.Text = "Error";
                            return;
                        }
                    }
                    else
                    {
                        if (ent_element.Length > 2)
                        {
                            label.Text = "Errpr";
                            return;
                        }
                        else
                        {
                            ent_element += letter;
                        }
                    }
                }
            }
            if (elements.ContainsKey(ent_element))
            {
                label.Text = $"{elements[ent_element][1]}";
            }
            else
            {
                label.Text = "Error";
            }
        }
    }
}