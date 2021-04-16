# Mobile-College-Course-Planner App
Mobile College Course Planner/ Scheduler/ Project tracker

Mobile Application Development
A multiple-screen mobile application for WGU students to track their terms, courses associated with each term, and assessment(s) associated with each course. The application will allow students to enter, edit, and delete term, course, and assessment data. It should provide summary and detailed views of courses for each term and provide alerts/notifications for upcoming performance and objective assessments. This application will use a SQLite database.

SREENSHOTS:
![mobileplannerhomescreen](https://user-images.githubusercontent.com/54335750/114235759-a33b3f80-994e-11eb-9c40-cf0cf1638862.png)

![mobileplanneraddcoursepng](https://user-images.githubusercontent.com/54335750/114235827-c108a480-994e-11eb-84d8-5f8f00e8c255.png)

![mobileplannercourseedit](https://user-images.githubusercontent.com/54335750/114235833-c4039500-994e-11eb-8ed2-813004b0e6c3.png)

![mobileplannerassesmentedit](https://user-images.githubusercontent.com/54335750/114235856-c960df80-994e-11eb-80b3-c9a1d72a87a8.png)

![mobileplanneralert](https://user-images.githubusercontent.com/54335750/114235865-cbc33980-994e-11eb-822f-6314be451c49.png)

![mobileplannertermscreen](https://user-images.githubusercontent.com/54335750/114235884-d087ed80-994e-11eb-9bd2-8c271f730184.png)

Input

Each of the following needs to be input into the application:

• terms, including the following:

    the term title (e.g., Term 1, Term 2)

    the start date

    the end date

• courses, including the following:

    the course title

    the start date

    the anticipated end date

    the status (e.g., in progress, completed, dropped, plan to take)

    the course mentor name(s), phone number(s), and email address(es)

• objective and performance assessments associated with each course

• the ability to add optional notes for each course

• the ability to set alerts or notifications for the start and end date of each course

• the ability to set alerts for goal dates for each objective and performance assessment

Output

Each of the following needs to be displayed by the application on a separate screen:

• the navigation panel

• a list of terms

• a detailed view of each term, including the following:

    the title (e.g., Term 1, Term 2)

    the start date

    the end date

• a list of courses for each term

• a detailed view of each course, including the following:

    the course title

    the start date

    the anticipated end date

    assessments

• a list of performance and objective assessments for a selected course

• a detailed view of each objective and performance assessment, including the following:

    the due date for a selected course

    notes for the selected course

    sharing features (e.g., email, SMS)

Requirements:

Note: Submit your performance assessment by including all Android project files, APK, and signed apk files in one zipped.zip file.

Note: For your convenience an optional checklist is attached to help guide you through this performance assessment.

A. Create an Android (version 4.0 or higher) mobile application with the following functional requirements:

    Include the following information for each term:

• the term title (e.g., Term 1, Term 2)

• the start date

• the end date

    Include features that allow the user to add as many terms as needed.

    Implement validation so that a term cannot be deleted if courses are assigned to it.

    Include features that allow the user to do the following for each term:

a. add as many courses as needed

b. display a list of courses associated with each term

c. display a detailed view of each term, which includes the following information:

• the term title (e.g., Term 1, Term 2)

• the start date

• the end date

    Include the following details for each course:

• the course title

• the start date

• the anticipated end date

• the status (e.g., in progress, completed, dropped, plan to take)

• the course mentor name(s), phone number(s), and e-mail address(es)

    Include features that allow the user to do the following for each course:

a. add as many assessments as needed

b. add optional notes

c. enter, edit, and delete course information

d. display optional notes

e. display a detailed view of the course, including the due date

f. set alerts for the start and end date

g. share notes via a sharing feature (e.g., e-mail, SMS)

    Include features that allow the user to do the following for each assessment:

a. add performance and/or objective assessments for each course, including the titles and due dates of the assessments

b. enter, edit, and delete assessment information

c. set alerts for goal dates

B. Design at least the following seven screen layouts, including appropriate GUI elements for each screen:

• a home screen

• a list of terms

• a list of courses

• a list of assessments

• a detailed course view

• a detailed term view

• a detailed assessment view

Note: You are required to design the seven screens listed in part B but are not limited to only seven.

C. Create a scheduler and progress tracking application in your mobile application from part A.

Note: This can be the implementation of part A.

    Include the following implementation requirements:

• an arrayList

• an intent class

• navigation capability between multiple screens using activity

• at least three activities

• events (e.g., a click event)

• the ability to work in portrait and landscape layout

• interactive capability (e.g., the ability to accept and act upon user input)

• a database to store and retrieve application data

• an application title and an icon

• the use of at least two different methods to save data (e.g., SharedPreference, SQLite)

• notifications or alerts

• the use of both declarative and programmatic methods to create a user interface

Note: Your application should work at least on Android 4.0 (API level 14).

    Include at least the following interface requirements:

• seven screens

• the ability to scroll vertically

• an action bar

• a menu

• an imageview

• two layouts

• input controls

• buttons

D. Create a storyboard that includes each of the menus and screens from part B to demonstrate application flow.

E. Provide screenshots to demonstrate that you have created a deployment package.
