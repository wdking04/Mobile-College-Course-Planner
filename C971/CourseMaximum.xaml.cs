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
    public partial class CourseMaximum : ContentPage            // A maximum of 6 coursed per term allowed
    {
        public CourseMaximum()
        {
            InitializeComponent();
        }

        private async void btnOK_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}