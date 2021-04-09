using C971.Classes;
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
    public partial class AssessmentPage : ContentPage
    {
        public Course _course;
        public MainPage _main;
        //public List<string> pickerStates = new List<string> { "Objective", "Performance" };
        public AssessmentPage(Course course, MainPage main)
        {
            _course = course;
            _main = main;
            InitializeComponent();
            AssessmentsListView.ItemTapped += new EventHandler<ItemTappedEventArgs>(ItemTapped);
            Title = course.CourseName;
        }

        protected override void OnAppearing()
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Assessment>();
                var assessmentsForCourse = con.Query<Assessment>($"SELECT * FROM Assessments WHERE Course = '{_course.Id}'");
                AssessmentsListView.ItemsSource = assessmentsForCourse;
            }
        }


        async void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Assessment assessment = (Assessment)e.Item;
            await Navigation.PushAsync(new EditAssessmentPage(_course, _main, assessment));
        }

        async private void btnAddAssessment_Clicked(object sender, EventArgs e)
        {
           
             if (getAssessmentCount() < 2)     // 2 assessments per course
            {
                await Navigation.PushModalAsync(new AddAssessment(_course,_main));
            }

            else
            {
                await Navigation.PushModalAsync(new AssessmentError());        //assessment error screen if more than 2 are added
            }
        }

        int getAssessmentCount()
        {
            int count = 0;
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                var assessmentCount = con.Query<Assessment>($"SELECT * FROM Assessments WHERE Course = '{_course.Id}'");
                count = assessmentCount.Count;
            }

            return count;
        }
        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}