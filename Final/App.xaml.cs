﻿namespace Final
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            BindingContext = new MyViewModel();
        }
    }
}
