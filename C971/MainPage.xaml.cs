using C971.Classes;
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace C971
{
    [DesignTimeVisible(false)]   
   
    public partial class MainPage : ContentPage
    {
        public List<Term> terms = new List<Term>();
        public List<Course> courses = new List<Course>();
        public List<Assessment> assessments = new List<Assessment>();
        public MainPage main;
    
        bool firstTime = true;        


        [Xamarin.Forms.TypeConverter(typeof(Xamarin.Forms.ImageSourceConverter))]
        public Xamarin.Forms.ImageSource Source { get; set; }
        public MainPage()
        {
            InitializeComponent();
            termsListView.ItemTapped += new EventHandler<ItemTappedEventArgs>(ItemTapped);
            main = this;
        }



        protected override void OnAppearing()
        {
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))  //https://docs.microsoft.com/en-us/dotnet/api/microsoft.data.sqlite.sqliteconnection?view=msdata-sqlite-3.1.0
                                                                               //
            
            {
                con.CreateTable<Term>();
                con.CreateTable<Course>();
                con.CreateTable<Assessment>();
                terms = con.Table<Term>().ToList();
                
            }
            if (terms.Any() && firstTime)
            {
                using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                {
                    con.DropTable<Assessment>();
                    con.DropTable<Course>();
                    con.DropTable<Term>();

                    con.CreateTable<Term>();
                    con.CreateTable<Course>();
                    con.CreateTable<Assessment>();

                    CreateStudentData(1);
                }
                firstTime = false;
                runAlerts();
            }
            else if (firstTime)
            {

                CreateStudentData(1);

                firstTime = false;
                runAlerts();
            }
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                terms = con.Table<Term>().ToList();
                termsListView.ItemsSource = terms;
            }

            base.OnAppearing();
        }

        private void runAlerts()      //Will Check  for and alert user if a course starts/ends or an upcoming assessment is due within 7 days.
        {
            foreach (Term t in terms)
            {
                using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
                {
                    var courses = con.Query<Course>($"SELECT * FROM Courses WHERE Term = '{t.Id}'");
                    foreach (Course c in courses)
                    {
                        
                        if ((c.Start - DateTime.Now).TotalDays < 7 && c.Notifications == 1)
                        {
                            CrossLocalNotifications.Current.Show("Course Alert", $"{c.CourseName} starts {c.Start.Date.ToString()}");
                        }
                        
                        if ((c.End - DateTime.Now).TotalDays < 7 && c.Notifications == 1)
                        {
                            CrossLocalNotifications.Current.Show("Course Alert", $"{c.CourseName} ends {c.End.Date.ToString()}");
                        }

                        
                        var assessments = con.Query<Assessment>($"SELECT * FROM Assessments WHERE Course = '{c.Id}'");
                        foreach (Assessment a in assessments)
                        {
                            if ((a.End - DateTime.Now).TotalDays < 7 && a.Notifications == 1)
                            {
                                CrossLocalNotifications.Current.Show("Assessment Alert", $"{a.AssessmentName} sheduled for {a.End.Date.ToString()}");
                            }
                        }

                    }
                }
            }


        }

        private void CreateStudentData(int termNumber)
        {
                                           //Example student term info.
            Term newTerm = new Term();
            newTerm.TermName = "Term  " + termNumber.ToString();
            newTerm.Start = new DateTime(2020, 09, 01);
            newTerm.End = new DateTime(2021, 04, 01);
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.Insert(newTerm);
            }
                                            //Example student course info.
            Course newCourse = new Course();
            newCourse.Term = newTerm.Id;
            newCourse.CourseName = "C202";
            newCourse.CourseStatus = "In Progress";
            newCourse.Start = new DateTime(2020, 09, 01);
            newCourse.End = new DateTime(2020, 10, 01);
            newCourse.InstructorName = "Winston King";
            newCourse.InstructorEmail = "wking26@.edu";
            newCourse.InstructorPhone = "540-555-5555";
            newCourse.Notes = "Getting Started";
            newCourse.Notifications = 1;
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.Insert(newCourse);
            }
                                                                     //Example Objective Assessment.
            Assessment newObjectiveAssessment = new Assessment();
            newObjectiveAssessment.AssessmentName = "C101oa";
            newObjectiveAssessment.Start = new DateTime(2020, 09, 30);
            newObjectiveAssessment.End = new DateTime(2020, 09, 30);
            newObjectiveAssessment.AssessmentType = "Objective";
            newObjectiveAssessment.Course = newCourse.Id;
            newObjectiveAssessment.Notifications = 1;
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.Insert(newObjectiveAssessment);
            }
                                                                     //Example Performance Assessment.
            Assessment newPerformanceAssessment = new Assessment();
            newPerformanceAssessment.AssessmentName = "C101pa";
            newPerformanceAssessment.Start = new DateTime(2020, 09, 30);
            newPerformanceAssessment.End = new DateTime(2020, 09, 30);
            newPerformanceAssessment.AssessmentType = "Performance";
            newPerformanceAssessment.Course = newCourse.Id;
            newPerformanceAssessment.Notifications = 1;
            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.Insert(newPerformanceAssessment);
            }
        }




        async private void btnNewTerm_Clicked(object sender, EventArgs e)   // This button is visible in toolbar, gives option to create new term.
        {
            await Navigation.PushModalAsync(new AddTerm(this));
        }
        async void ItemTapped(object sender, ItemTappedEventArgs e)        //https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.listview.itemtapped?view=xamarin-forms
        {                                                                  //Creates an event when tapped. Sends user to term page to create new term.
            Term term = (Term)e.Item;
            await Navigation.PushAsync(new TermPage(term, main));
        }
    }
}
