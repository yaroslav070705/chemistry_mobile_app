using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace chemistry_app
{
    public class MolarMassPage : ContentPage
    {

        Stopwatch stopwatch = new Stopwatch();

        delegate bool IsLower(char element);
        Label label;
        Entry entry;
        Dictionary<string, List<double>> elements;
        Label test_label = new Label();
        public MolarMassPage()
        {
            StackLayout stacklayout = new StackLayout() { Padding = new Thickness(10 * DeviceDisplay.MainDisplayInfo.Height / 1080) };
            stacklayout.SetDynamicResource(StackLayout.BackgroundColorProperty, "bg_color");
            entry = new Entry() { BackgroundColor = Color.White };
            entry.Completed += Entry_TextCompleted;
            //entry.SetDynamicResource(Entry.TextColorProperty, "bg_color");
            //entry.SetDynamicResource(Entry.BackgroundColorProperty, "text_color");
            elements = (Dictionary<string, List<double>>)App.Current.Properties["elements"];
            label = new Label(); //{ Text = $"{elements["Cl"][0]}" };
            label.SetDynamicResource(Label.TextColorProperty, "text_color");

            stacklayout.Children.Add(entry);
            stacklayout.Children.Add(label);
            stacklayout.Children.Add(test_label);
            Content = stacklayout;
        }

        private void Error( Errors ErrorType, string element = "")
        {
            switch (ErrorType)
            {
                case Errors.OpenedBracket:
                    label.Text = "Есть лишняя или незакрытая скобка";
                    break;
                case Errors.WrongOrder:
                    label.Text = "Неправильный порядок ввода букв";
                    break;
                case Errors.WrongElement:
                    label.Text = "Введен несуществующий элемент";
                    break;
            }
        }
        enum PrefType {
            Digit,
            High,
            Low,
            OpenBracket,
            CloseBracket,
            Start

        }

        enum Errors
        {
            WrongElement,
            WrongOrder,
            OpenedBracket
        }

        private bool ContainsKey(string element)
        {
            return elements.ContainsKey(element);
        }

        private void Entry_TextCompleted(object sender, EventArgs e)
        {
            stopwatch.Start();
            int circBracketCounter = 0;
            string entered_sting = entry.Text;
            IsLower isLower = (char element) => element.Equals(char.ToLower(element)) && char.IsLetter(element);
            double molar_mass = 0;
            string multiplier = "";
            PrefType prefType = PrefType.Start;
            if (entered_sting != null && entered_sting != "")
            {
                {/* int i;
                int j;
               // int molar_mass = 0;
                string total_ratio = "";
                int element_ind = -1;
                List<string> elements_indexes = new List<string>();
                List<string> elements_list = new List<string>();
                for (i = 0; i < entered_sting.Length; i++)
                {
                    if (char.IsDigit(entered_sting[i]))
                    {
                        if(elements_indexes.Count == 0)
                        {
                            total_ratio += entered_sting[i];
                            if(i == entered_sting.Length - 1)
                            {
                                label.Text = "Error";
                                return;
                            }
                        }
                        else
                        {
                            elements_indexes[element_ind] += entered_sting[i];
                        }
                    }

                    else if (!isLower(entered_sting[i]))
                    {
                        elements_list.Add(entered_sting[i].ToString());
                        elements_indexes.Add("");
                        element_ind += 1;
                    }
                    else
                    {
                        if(elements_list.Count > 0 && elements_list[element_ind].Length < 2)
                        {
                            elements_list[element_ind] += entered_sting[i];
                        }
                        else
                        {
                            label.Text = "Error";
                            return;
                        }
                    }
                }
                if(total_ratio == "")
                {
                    total_ratio = "1";
                }
                int ind;
                for (i = 0; i < elements_list.Count; i++) {
                    if (elements.ContainsKey(elements_list[i])) 
                    {
                        if(elements_indexes[i] == "")
                        {
                            ind = 1;
                        }
                        else
                        {
                            ind = int.Parse(elements_indexes[i]);
                        }
                        molar_mass += elements[elements_list[i]][0]*ind;
                    }
                    else
                    {
                        label.Text = "Error";
                        return;
                    }
                }

                label.Text = $"{int.Parse(total_ratio)*molar_mass}";
                stopwatch.Stop();
                //test_label.Text = stopwatch.Elapsed.TotalSeconds.ToString();*/}
                string element = "";
                Stack<double> masses = new Stack<double>();
                char latter = entered_sting[0];
                if(char.IsDigit(latter)||isLower(latter)||latter == ')')
                {
                    Error(Errors.WrongOrder);
                   // Console.WriteLine("E1");
                   // Console.WriteLine(char.IsDigit(latter));
                   // Console.WriteLine(isLower(latter));
                   // Console.WriteLine(latter == ')');
                    return;
                }
                for(int i = 0; i < entered_sting.Length; i++)
                {
                    latter = entered_sting[i];
                   // label.Text = "ZGGOYJHGVLKGHVJBLKHJGBLKBHJL";

                    if (char.IsWhiteSpace(latter)) { }
                    else if(latter == '(')
                    {
                        //label.Text = "1wwef";
                       // Console.WriteLine("sdds");
                        if(element != "")
                        {
                            if (ContainsKey(element))
                            {
                                if(multiplier == "")
                                {
                                    multiplier = "1";
                                }
                                molar_mass += elements[element][0] * int.Parse(multiplier);
                            }
                        }
                        masses.Push(molar_mass);
                        //Console.WriteLine("Push");
                        element = "";
                        multiplier = "";
                        prefType = PrefType.OpenBracket;
                        circBracketCounter++;
                        molar_mass = 0;
                    }
                    else if(latter == ')')
                    {
                        if(circBracketCounter == 0)
                        {
                            Error(Errors.OpenedBracket);
                           // Console.WriteLine("E2");
                            return;
                        }
                        if(element == "" && prefType != PrefType.OpenBracket)
                        {
                            if(multiplier == "")
                            {
                                multiplier = "1";
                            }
                           // Console.WriteLine("pop1");
                            molar_mass *= int.Parse(multiplier);
                            molar_mass += masses.Pop();
                        }
                        else
                        {
                            if (ContainsKey(element))
                            {
                                if(multiplier == "")
                                {
                                    multiplier = "1";
                                }
                                molar_mass += elements[element][0] * int.Parse(multiplier);
                            }
                            else
                            {
                                Error(Errors.WrongElement);
                                return;
                            }
                        }
                        prefType = PrefType.CloseBracket;
                        circBracketCounter--;
                        multiplier = "";
                        element = "";
                    }
                    else if (char.IsDigit(latter))
                    {
                        if(prefType == PrefType.OpenBracket)
                        {
                            Error(Errors.WrongOrder);
                           // test_label.Text = "4";
                           // Console.WriteLine("E3");
                            return;
                        }
                        multiplier += latter;
                        prefType = PrefType.Digit;
                    }
                    else if (isLower(latter))
                    {
                        if(prefType == PrefType.Low || prefType == PrefType.Digit || element =="")
                        {
                            Error(Errors.WrongOrder);
                           // test_label.Text = "5";
                           // Console.WriteLine("E4");
                            return;
                        }
                        element += latter;
                        prefType = PrefType.Low;
                    }
                    else if(isLower(latter) == false)
                    {
                        if(element == "" && prefType!=PrefType.Start && prefType != PrefType.OpenBracket)
                        {
                            if(multiplier == "")
                            {
                                multiplier = "1";
                            }
                           // Console.WriteLine("Pop2");
                            molar_mass *= int.Parse(multiplier);
                            molar_mass += masses.Pop();
                        }
                        else
                        {
                            if (element != "")
                            {
                                if (ContainsKey(element))
                                {
                                    if (multiplier == "")
                                    {
                                        multiplier = "1";
                                    }
                                    molar_mass += elements[element][0] * int.Parse(multiplier);
                                }
                                else
                                {
                                    Error(Errors.WrongElement);
                                 //   Console.WriteLine("E5");
                                    return;
                                }
                            }
                        }
                        element = "" + latter;
                        multiplier = "";
                        prefType = PrefType.High;
                    }
                    if (i == entered_sting.Length - 1)
                    {
                        if(circBracketCounter != 0)
                        {
                            Error(Errors.OpenedBracket);
                           // Console.WriteLine("E6");
                            return;
                        }
                        if (multiplier == "")
                        {
                            multiplier = "1";
                        }
                        if (prefType == PrefType.High || prefType == PrefType.Low)
                        {
                            if (ContainsKey(element))
                            {
                                molar_mass += elements[element][0] * int.Parse(multiplier);
                            }
                            else { 
                                Error(Errors.WrongElement);
                                //Console.WriteLine("E7");
                                return; 
                            }
                        }
                        else if(prefType == PrefType.Digit)
                        {
                            if(element == "")
                            {
                                molar_mass *= int.Parse(multiplier);
                                molar_mass += masses.Pop();
                               // Console.WriteLine("Pop3");
                            }
                            else
                            {
                                if (ContainsKey(element))
                                {
                                    molar_mass += elements[element][0] * int.Parse(multiplier);
                                }
                                else
                                {
                                    Error(Errors.WrongElement);
                                    //Console.WriteLine("E8");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            molar_mass += masses.Pop();
                        }
                    }
                }
                label.Text = molar_mass.ToString(); 
            }
        }
    }
}