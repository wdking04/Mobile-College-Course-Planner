﻿using C971.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTermPage : ContentPage
    {
        public Term _term;
        public MainPage _main;
        public EditTermPage(Term term, MainPage main)
        {
            _term = term;
            _main = main;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            txtTermName.Text = _term.TermName;
            dpStartDate.Date = _term.Start.Date;
            dpEndDate.Date = _term.End.Date;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if(ValidateUserInput())
            {

                _term.TermName = txtTermName.Text;
                _term.Start = dpStartDate.Date;
                _term.End = dpEndDate.Date;
                using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                {
                    con.Update(_term);
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                await Navigation.PushModalAsync(new InputError());
            }

        }
        private bool ValidateUserInput()
        {
            bool valid = true;

            if (txtTermName.Text == null ||
                dpStartDate.Date == null ||
                dpEndDate.Date == null ||
                dpEndDate.Date < dpStartDate.Date
                )

            {
                return false;
            }
            return valid;
        }

        private void btnExit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}