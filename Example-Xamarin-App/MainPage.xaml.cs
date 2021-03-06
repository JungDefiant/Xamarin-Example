﻿using System;
using System.IO;
using Xamarin.Forms;

namespace Example_Xamarin_App
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);

            await Navigation.PushAsync(new NameEntryPage());
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }

        async void OnDiceRollButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DiceRollerPage());
        }
    }
}
