using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace chemistry_app
{
    public partial class App : Application
    {
        public App()
        {
            Dictionary<string, List<double>> elements = new Dictionary<string, List<double>>();
            elements.Add("H",new List<double> { 1 });
            elements.Add("He", new List<double> { 4 });
            elements.Add("Li", new List<double> { 7, 530 });
            elements.Add("Be", new List<double> { 9 });
            elements.Add("B", new List<double> { 11, 3330 });
            elements.Add("C", new List<double> { 12 });
            elements.Add("N", new List<double> { 14, 1.25 });
            elements.Add("O", new List<double> { 16 });
            elements.Add("F", new List<double> { 19 });
            elements.Add("Ne", new List<double> { 20 });
            elements.Add("Na", new List<double> { 23 });
            elements.Add("Mg", new List<double> { 24, 1740 });
            elements.Add("Al", new List<double> { 27,2700 });
            elements.Add("Si", new List<double> { 28, 2420 });
            elements.Add("P", new List<double> { 31 });
            elements.Add("S", new List<double> { 32 });
            elements.Add("Cl", new List<double> { 35,5 });
            elements.Add("Ar", new List<double> { 40 });
            elements.Add("K", new List<double> { 39, 870 });
            elements.Add("Ca", new List<double> { 40, 1550 });
            elements.Add("Sc", new List<double> { 45 });
            elements.Add("Ti", new List<double> { 48 });
            elements.Add("V", new List<double> { 51, 5960 });
            elements.Add("Cr", new List<double> { 52 });
            elements.Add("Mn", new List<double> { 55 });
            elements.Add("Fe", new List<double> { 56, 7870 });
            elements.Add("Co", new List<double> { 59, 8710 });
            elements.Add("Ni", new List<double> { 59 });
            elements.Add("Cu", new List<double> { 64 });
            elements.Add("Zn", new List<double> { 65 });
            elements.Add("Ga", new List<double> { 70 });
            elements.Add("Ge", new List<double> { 73, 5460 });
            elements.Add("As", new List<double> { 75 });
            elements.Add("Se", new List<double> { 79 });
            elements.Add("Br", new List<double> { 80 });
            elements.Add("Kr", new List<double> { 84 });
            elements.Add("Rb", new List<double> { 85 });
            elements.Add("Sr", new List<double> { 88 });
            elements.Add("Y", new List<double> { 89 });
            elements.Add("Zr", new List<double> { 91 });
            elements.Add("Nb", new List<double> { 93 });
            elements.Add("Mo", new List<double> { 96 });
            elements.Add("Tc", new List<double> { 99 });
            elements.Add("Ru", new List<double> { 101 });
            elements.Add("Rh", new List<double> { 103 });
            elements.Add("Pd", new List<double> { 106 });
            elements.Add("Ag", new List<double> { 108 });
            elements.Add("Cd", new List<double> { 112, 8650 });
            elements.Add("In", new List<double> { 115, 7280 });
            elements.Add("Sn", new List<double> { 119 });
            elements.Add("Sb", new List<double> { 122 });
            elements.Add("Te", new List<double> { 128 });
            elements.Add("I", new List<double> { 127, 4940 });
            elements.Add("Xe", new List<double> { 131 });
            elements.Add("Cs", new List<double> { 133 });
            elements.Add("Ba", new List<double> { 137, 3780 });
            elements.Add("La", new List<double> { 139 });
            elements.Add("Ce", new List<double> { 140 });
            elements.Add("Pr", new List<double> { 141 });
            elements.Add("Nd", new List<double> { 144 });
            elements.Add("Pm", new List<double> { 147 });
            elements.Add("Sm", new List<double> { 150 });
            elements.Add("Eu", new List<double> { 152, 3220 });
            elements.Add("Gd", new List<double> { 157 });
            elements.Add("Tb", new List<double> { 159 });
            elements.Add("Dy", new List<double> { 163 });
            elements.Add("Ho", new List<double> { 165 });
            elements.Add("Er", new List<double> { 167 });
            elements.Add("Tm", new List<double> { 169 });
            elements.Add("Yb", new List<double> { 173 });
            elements.Add("Lu", new List<double> { 175 });
            elements.Add("Hf", new List<double> { 178 });
            elements.Add("Ta", new List<double> { 181 });
            elements.Add("W", new List<double> { 184, 18900 });
            elements.Add("Re", new List<double> { 186 });
            elements.Add("Os", new List<double> { 190 });
            elements.Add("Ir", new List<double> { 192, 22400 });
            elements.Add("Pt", new List<double> { 195 });
            elements.Add("Au", new List<double> { 197, 19300 });
            elements.Add("Hg", new List<double> { 201 });
            elements.Add("Tl", new List<double> { 204 });
            elements.Add("Pb", new List<double> { 207 });
            elements.Add("Bi", new List<double> { 209, 9750 });
            elements.Add("Po", new List<double> { 209 });
            elements.Add("At", new List<double> { 210 });
            elements.Add("Rn", new List<double> { 222 });
            elements.Add("Fr", new List<double> { 223 });
            elements.Add("Ra", new List<double> { 226 });
            elements.Add("Ac", new List<double> { 227 });
            elements.Add("Th", new List<double> { 232 });
            elements.Add("Pa", new List<double> { 231 });
            elements.Add("U", new List<double> { 238 });
            elements.Add("Np", new List<double> { 237 });
            elements.Add("Pu", new List<double> { 244 });
            elements.Add("Am", new List<double> { 243 });
            elements.Add("Cm", new List<double> { 247 });
            elements.Add("Bk", new List<double> { 247 });
            elements.Add("Cf", new List<double> { 251 });
            elements.Add("Es", new List<double> { 252 });
            elements.Add("Fm", new List<double> { 257 });
            elements.Add("Md", new List<double> { 258 });
            elements.Add("No", new List<double> { 259 });
            elements.Add("Lr", new List<double> { 266 });
            elements.Add("Rf", new List<double> { 267 });
            elements.Add("Db", new List<double> { 268 });
            elements.Add("Sg", new List<double> { 269 });
            elements.Add("Bh", new List<double> { 270 });
            elements.Add("Hs", new List<double> { 277 });
            elements.Add("Mt", new List<double> { 278 });
            elements.Add("Ds", new List<double> { 281 });
            elements.Add("Rg", new List<double> { 282 });
            elements.Add("Cn", new List<double> { 285 });
            elements.Add("Nh", new List<double> { 286 });
            elements.Add("Fl", new List<double> { 289 });
            elements.Add("Mc", new List<double> { 290 });
            elements.Add("L", new List<double> { 293 });
            elements.Add("Ts", new List<double> { 294});
            elements.Add("Og", new List<double> { 294 });
            App.Current.Properties.Add("elements",elements);
            ResourceDictionary diction = new ResourceDictionary();
            diction.Add("bg_color", Color.White);
            diction.Add("text_color", Color.Black);
            diction.Add("button_pic", "change_theme_button_icon2");
            Application.Current.Resources = diction;
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
