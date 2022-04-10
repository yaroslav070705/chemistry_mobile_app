using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using chemistry_app;
using Xamarin.Forms.Core;

namespace chemistry_app
{
    public class MolarMassPage : ContentPage
    {
        Label outputLabel = new Label();
        Label molarMassLabel = new Label();
        Entry entry = new Entry() { BackgroundColor = Color.White };
        ScrollView scrollView = new ScrollView();
        Grid grid = new Grid();
        Grid numGrid = new Grid();
        Editor editor;
        Button resetButton = new Button() { Text = "Сбросить" };
        StackLayout stacklayout = new StackLayout() { Padding = new Thickness(10 * DeviceDisplay.MainDisplayInfo.Height / 1080) };
        Dictionary<string, List<double>> elements;
        Label test_label = new Label();
        FlexLayout flexLayout = new FlexLayout();
        SwipeGestureRecognizer swipeGestureRecognizer = new SwipeGestureRecognizer();
        //MyEntry elementBarEntry = new MyEntry() {IsSpellCheckEnabled = false };
        Label elementBarEntry = new Label();
        FormattedString eleentFormattedString = new FormattedString();
        Button countButton = new Button();
        Button closeCircleBracketButton = new Button();
        Button openCircleBracketButton = new Button();
        Button closeSquareBracketButton = new Button();
        Button openSquareBracketButton = new Button();
        Button removeButton = new Button();

        int mollarMass;
        bool errors = false;
        int openedCircleBracketsCount = 0;
        int openedSquareBracketsCount = 0;
        Type prefType;
        int index = 0;
        Stack<Type> buttonsStack = new Stack<Type>();
        List<string[]> elementString = new List<string[]>();
        public MolarMassPage()
        {
            //  editor = new Editor() { BackgroundColor = Color.White };
            //entry.Completed += Entry_TextCompleted;
            //entry.SetDynamicResource(Entry.TextColorProperty, "bg_color");
            //entry.SetDynamicResource(Entry.BackgroundColorProperty, "text_color");
            //  elementsBarLabel.SetDynamicResource(Label.TextColorProperty, "text_color");
            elementBarEntry.SetDynamicResource(Entry.TextColorProperty, "text_color");
            stacklayout.SetDynamicResource(StackLayout.BackgroundColorProperty, "bg_color");
            molarMassLabel.SetDynamicResource(Label.TextColorProperty, "text_color");
            elements = (Dictionary<string, List<double>>)App.Current.Properties["elements"];
            
            molarMassLabel.Text = "Молярная масса:";
            outputLabel.SetDynamicResource(Label.TextColorProperty, "text_color");
            outputLabel.Text = "0";
            test_label.Text = "";
            test_label.TextColor = Color.Red;


            MySwipeDirection swipeDirection = MySwipeDirection.Left;
            swipeGestureRecognizer.Direction = SwipeDirection.Left;
            swipeGestureRecognizer.Swiped += (object sender, SwipedEventArgs e) =>  Swipe(ref swipeDirection);

            countButton.Text = "Посчитать";
            countButton.Clicked += (Object sender, System.EventArgs e) => 
            {
                CountMolarMassButtonFunc();
            };

            removeButton.Text = "<-";
            removeButton.Clicked += (sender, e) => RemoveButtonFunc();

            int row = 0;
            int column = 0;
            mollarMass = 0;
            resetButton.Clicked += ResetButtonFunc;
            prefType = Type.Empty;

            for(int i = 0; i < 10; i++)
            {
                Button but = new Button { Text = i.ToString() };
                but.Clicked += (object sender, System.EventArgs e) => {
                    NumButtonFunc(int.Parse(but.Text), ref prefType);
                };
                but.Clicked += (sender, e) => CheckErrors();
                numGrid.Children.Add(but, column, row);
                if (column < 2) {
                    column++; 
                }

                else
                {
                    column = 0;
                    row++;
                }
            }

            closeCircleBracketButton.Clicked += (Object sender, EventArgs e) => BracketButtonFunc(")", "CloseCircleBracket");
            closeCircleBracketButton.Text = ")";
            closeSquareBracketButton.Clicked += (Object sender, EventArgs e) => BracketButtonFunc("]", "CloseSquareBracket");
            closeSquareBracketButton.Text = "]";
            openCircleBracketButton.Clicked += (Object sender, EventArgs e) => BracketButtonFunc("(", "OpenCircleBracket");
            openCircleBracketButton.Text = "(";
            openSquareBracketButton.Clicked += (Object sender, EventArgs e) => BracketButtonFunc("[", "OpenSquareBracket");
            openSquareBracketButton.Text = "[";
            
            row = 0;
            column = 0;

            foreach (string str in elements.Keys)
            {
                Button but = new Button { Text = str };
                but.Clicked += (sender, e) =>
                {
                    ElementButtonFunc(but.Text);
                };
                but.Clicked += (sender, e) => CheckErrors();

                grid.Children.Add(but, column, row);
                if(column < 4) { column++; }
                else {
                    column = 0;
                    row++;
                }
            }

            //  elementBarEntry.TextChanged += (sender,e) => CheckErrors();
            elementBarEntry.FormattedText = eleentFormattedString;

            numGrid.Children.Add(removeButton, 2, 3);
            numGrid.Children.Add(closeCircleBracketButton,1,4);
            numGrid.Children.Add(closeSquareBracketButton,1,5);
            numGrid.Children.Add(openCircleBracketButton,0,4);
            numGrid.Children.Add(openSquareBracketButton,0,5);
            flexLayout.Children.Add(molarMassLabel);
            flexLayout.Children.Add(outputLabel);
            scrollView.GestureRecognizers.Add(swipeGestureRecognizer);
            scrollView.Content = grid;
            stacklayout.GestureRecognizers.Add(swipeGestureRecognizer);
            stacklayout.Children.Add(elementBarEntry);
            stacklayout.Children.Add(countButton);
            stacklayout.Children.Add(resetButton);
            stacklayout.Children.Add(flexLayout);
            stacklayout.Children.Add(test_label);
            stacklayout.Children.Add(scrollView);
            Content = stacklayout;
        }

        private void Swipe(ref MySwipeDirection swipeDirection) {
            if(swipeDirection == MySwipeDirection.Left)
            {
                swipeGestureRecognizer.Direction = SwipeDirection.Right;
                scrollView.Content = numGrid;
                swipeDirection = MySwipeDirection.Right;
            }
            else
            {
                swipeGestureRecognizer.Direction = SwipeDirection.Left;
                scrollView.Content=grid;
                swipeDirection = MySwipeDirection.Left;
            }
        }

        private void CountMolarMass()
        {
            Stack<int> massStack = new Stack<int>();
            mollarMass = 0;
            foreach(string[] mas in elementString)
            {
                if (mas[0] == "element")
                {
                    mollarMass += (int)elements[mas[1]][0] * int.Parse(mas[2]);
                    Console.WriteLine($"index = {elementString[elementString.Count - 1][2]}");
                }
                else if(mas[0] == "OpenCircleBracket" || mas[0] == "OpenSquareBracket")
                {
                    massStack.Push(mollarMass);
                    mollarMass = 0;
                }
                else if(mas[0]=="CloseSquareBracket" || mas[0] == "CloseCircleBracket")
                {
                    mollarMass *= int.Parse(mas[2]);
                    mollarMass += massStack.Pop(); 
                }
            }
            outputLabel.Text = mollarMass.ToString();
        }

        private void NumButtonFunc(int num, ref Type prefType)
        {
            buttonsStack.Push(Type.Num);
            if (elementString.Count == 0)
            {
                ShowError("Введите элемент!!");
            }
            else
            {
                prefType = Type.Num;
                index = index * 10 + num;

                eleentFormattedString.Spans.Add(new Span()
                {
                    Text = num.ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
                });
                // elementBarEntry.Text += num.ToString();
            }
        }

        private void ElementButtonFunc(string element)
        {
            buttonsStack.Push(Type.Element);
            if (prefType == Type.Num)
            {
                elementString[elementString.Count - 1][2] = index.ToString();
                index = 0;
            }
            elementString.Add(new string[] { "element", element, "1" });
            prefType = Type.Element;

            eleentFormattedString.Spans.Add(new Span()
            {
                Text = element,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label))
            });
            //elementBarEntry.Text += element;
            //test_label.Text = "";
        }

        private void CountMolarMassButtonFunc()
        {
            if (errors == false)
            {


                if (prefType == Type.Num)
                {
                    elementString[elementString.Count() - 1][2] = index.ToString();
                }

                if (elementString.Count() != 0)
                {
                    CountMolarMass();
                }
                else
                {
                    outputLabel.Text = "0";
                    ShowError("Введите элемент");
                }
            }
        }

        private void BracketButtonFunc(string text,string breacketType)
        {
            buttonsStack.Push(Type.Bracket);
            if (prefType == Type.Num)
            {
                elementString[elementString.Count-1][2] = index.ToString();
                index = 0;
            }
            elementString.Add(new string[] { breacketType, text,"1"});
            prefType = Type.Bracket;

            eleentFormattedString.Spans.Add(new Span()
            {
                Text = text,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label))
            });
            // elementBarEntry.Text += text;
        }

        private void ResetButtonFunc(object sender, EventArgs e)
        {
            test_label.Text = "";
            prefType = Type.Empty;
            elementString.Clear();
            mollarMass = 0;
            outputLabel.Text = "0";
            elementBarEntry.Text = "";
            index = 0;
        }

        private void RemoveButtonFunc()
        {
           if(eleentFormattedString.Spans.Count != 0)
            {
                Type buttonType = buttonsStack.Pop();
                string[] mas = elementString[elementString.Count - 1];
                int length = 1;
                if (buttonType == Type.Element)
                {
                    Console.WriteLine($"elementString el num = {elementString.Count}");
                    elementString.RemoveAt(elementString.Count - 1);
                    Console.WriteLine($"elementString el num = {elementString.Count}");
                    length = mas[1].Length;
                }
                else if(buttonType == Type.Num)
                {
                    if(buttonsStack.Peek() == Type.Num)
                    {
                        Console.WriteLine($"index = {mas[2]}");
                        Console.WriteLine($"index = {elementString[elementString.Count - 1][2]}");
                        mas[2] = (int.Parse(mas[2]) / 10).ToString();
                        Console.WriteLine($"index = {mas[2]}");
                        Console.WriteLine($"index = {elementString[elementString.Count - 1][2]}");
                    }

                    else
                    {
                        mas[2] = "1";
                    }
                }
                else if(prefType == Type.Bracket)
                {
                    elementString.RemoveAt(elementString.Count - 1);
                }
                //elementBarEntry.Text = elementBarEntry.Text.Substring(0, elementBarEntry.Text.Length - length);
                eleentFormattedString.Spans.RemoveAt(eleentFormattedString.Spans.Count-1);
            }
        }
        
        private void CheckErrors()
        {
            int openedSquareBracketsCount = 0;
            int openedCircleBracketsCount = 0;
            errors = false;
            BracketType? prefBracketType = null;
            
            foreach (string[] mas in elementString)
            {
                switch (mas[0])
                {
                    case "OpenCircleBracket":
                        prefBracketType = BracketType.OpenCircleBrack;
                        openedCircleBracketsCount++;
                        break;
                    case "CloseCircleBracket":
                        if(prefBracketType == BracketType.OpenSquareBrack)
                        {
                            errors = true;
                        }
                        prefBracketType = BracketType.CloseCircleBrack;
                        openedCircleBracketsCount--;
                        break;
                    case "OpenSquareBracket":
                        prefBracketType = BracketType.OpenSquareBrack;
                        openedSquareBracketsCount++;
                        break;
                    case "CloseSquareBracket":
                        if (prefBracketType == BracketType.OpenCircleBrack)
                        {
                            errors = true;
                        }
                        prefBracketType = BracketType.CloseSquareBrack;
                        openedSquareBracketsCount--;
                        break;
                }

                if (errors)
                {
                    ShowError("Постановка скобок не верна");
                    return;
                }
            }
            if(openedCircleBracketsCount != 0 || openedSquareBracketsCount != 0)
            {
                errors = true;
                ShowError("Скобка не закрыта");
                return;
            }
            HideErrors();
        }

        void ShowError(string error)
        {
            test_label.Text = error;
        }
        void HideErrors()
        {
            test_label.Text = "";
        }
        enum MySwipeDirection
        {
            Left,
            Right
        }

        enum Type {
            Element,
            Num,
            Empty,
            Bracket
        }

        enum BracketType
        {
            OpenCircleBrack,
            CloseCircleBrack,
            OpenSquareBrack,
            CloseSquareBrack
        }

    }
}