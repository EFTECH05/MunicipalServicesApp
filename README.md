# Municipal Services Application – Part 1
<img width="1352" height="767" alt="image" src="https://github.com/user-attachments/assets/24e1421f-c4d6-4aac-b5e8-60734bf4cd28" />

## 1. Project Overview

The Municipal Services Application is a C# Windows Forms application developed for the AAPD7112 Portfolio of Evidence.

Part 1 focuses on the **Report Issues** functionality. The application allows citizens to report municipal service delivery problems by entering a location, selecting a category, providing a detailed description, and optionally attaching an image or document.

The application also includes additional account and administrator functionality to support the continued development of the project in later parts.

## 2. Technology Used

- C#
- Windows Forms
- .NET Framework 4.7.2
- Microsoft SQL Server / SQL Server Express
- Visual Studio
- ADO.NET (`System.Data.SqlClient`)

## 3. Main Part 1 Features

### Main Menu

When the application starts, the user is presented with the Municipal Services main menu.
<img width="1357" height="756" alt="image" src="https://github.com/user-attachments/assets/2f99aaee-4823-44e2-9752-be7b1dc39f70" />


Available options:
<img width="1357" height="756" alt="image" src="https://github.com/user-attachments/assets/509b440c-c130-4511-9f9f-e5c99f8426b6" />

1. **Report Issues** – implemented in Part 1.
2. **Local Events and Announcements** – disabled in Part 1 and reserved for Part 2.
3. **Service Request Status** – disabled in Part 1 and reserved for Part 3.

### Report Issues

The Report Issues form provides:
<img width="1206" height="689" alt="image" src="https://github.com/user-attachments/assets/fa0d2357-ba9b-4413-a54a-b5eed0db4e65" />

- Location input
- Issue category selection
- Detailed description using a RichTextBox
- Image/document attachment using OpenFileDialog
- Submit button
- Clear button
- Back to Main Menu button
- ProgressBar engagement feature
- Encouraging progress messages
- Success and error feedback

## 4. User Engagement Strategy

The selected engagement strategy is:

**Progress indicators and encouraging feedback messages.**

The ProgressBar changes as the user completes the reporting form. The application also displays messages such as:

- “Good start! Keep going.”
- “You're making great progress!”
- “Almost there! Just a little more.”
- “Everything is ready. You can submit your issue!”

This was selected because it gives users immediate feedback, makes the reporting process clear, and encourages them to complete the form.

## 5. Data Structure

Reported issues are represented using the `Issue` class.

The application uses:

```text
List<Issue>
```

to store reported issues in memory.

Issues are also stored permanently in the SQL Server `Issues` table.

The `IssueStore` class is responsible for:

- Loading issues from SQL Server
- Adding new issues
- Maintaining the in-memory issue list

## 6. Database Setup

### SQL Server Instance

```text
FRANKLIN\SQLEXPRESS01
```

### Database

```text
MunicipalServicesDB
```

Create the database:

```sql
CREATE DATABASE MunicipalServicesDB;
```

Then create the Accounts table:

```sql
CREATE TABLE Accounts
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    AccountType NVARCHAR(20) NOT NULL
);

ALTER TABLE Accounts
ADD Email NVARCHAR(150) NULL;
```

Create the Issues table:

```sql
CREATE TABLE Issues
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Location NVARCHAR(200) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Attachment NVARCHAR(500) NULL,
    DateReported DATETIME NOT NULL DEFAULT GETDATE()
);
```

## 7. Demo Accounts

The following demo accounts can be inserted for testing:

### Citizen

```sql
INSERT INTO Accounts
(FullName, Username, Password, AccountType)
VALUES
('Demo Citizen', 'citizen', '12345', 'Citizen');
```

### Administrator

```sql
INSERT INTO Accounts
(FullName, Username, Password, AccountType)
VALUES
('System Administrator', 'admin', 'admin123', 'Admin');
```

### Super Administrator

```sql
INSERT INTO Accounts
(FullName, Username, Password, AccountType)
VALUES
('System Super Administrator', 'superadmin', 'SuperAdmin2026', 'SuperAdmin');
```

## 8. Database Connection

The application uses the following SQL Server connection:

```text
Data Source=FRANKLIN\SQLEXPRESS01;
Initial Catalog=MunicipalServicesDB;
Integrated Security=True
```

If the SQL Server instance name is different on another computer, update the connection string in:

- `AccountStore.cs`
- `IssueStore.cs`

## 9. How to Compile

1. Open **Visual Studio**.
2. Open the `MunicipalServicesApp.sln` solution.
3. Make sure the project targets **.NET Framework 4.7.2**.
4. Confirm that the SQL Server database exists.
5. Confirm that the connection string matches the local SQL Server instance.
6. Build the solution using:
   - **Build → Build Solution**
7. Make sure there are no compilation errors.
8. Run the application using:
   - **Debug → Start Without Debugging**

## 10. How to Use the Application

### Citizen Login

Use:

```text
Username: citizen
Password: 12345
```

After login, the Main Menu is displayed.

Select **Report Issues**.

### Reporting an Issue

1. Enter the location.
2. Select an issue category.
3. Enter a detailed description.
4. Optionally select an image or document.
5. Check the progress indicator.
6. Select **Submit**.
7. The application saves the issue to SQL Server.
8. A confirmation message displays the generated Issue ID.

### Administrator Login

Use:

```text
Username: admin
Password: admin123
```

The administrator dashboard provides access to the current issue-management functionality.

### Super Administrator Login

Use:

```text
Username: superadmin
Password: SuperAdmin2026
```

The Super Administrator dashboard provides account-management functionality such as creating administrators and viewing citizens/accounts.

## 11. Attachment Behaviour

The Part 1 attachment feature uses `OpenFileDialog`.

The selected file path is stored with the issue.

The application supports common:

- JPG
- JPEG
- PNG
- GIF
- PDF
- DOC
- DOCX

The file itself is not copied into the database. Therefore, if the original file is moved or deleted from the computer, it may no longer be available when an administrator tries to open it.

## 12. Project Structure

Important files include:

```text
MunicipalServicesApp
│
├── Account.cs
├── AccountStore.cs
├── Issue.cs
├── IssueStore.cs
├── Program.cs
├── LoginForm.cs
├── CitizenSignUpForm.cs
├── MainMenuForm.cs
├── ReportIssueForm.cs
├── AdminDashboardForm.cs
├── SuperAdminDashboardForm.cs
├── CreateAdminForm.cs
├── ViewIssuesForm.cs
├── ViewCitizensForm.cs
└── ViewAccountsForm.cs
```

## 13. Part 1 Scope

Part 1 implements the Report Issues task.

The following features are intentionally reserved for later parts:

- Local Events and Announcements – Part 2
- Service Request Status – Part 3

The application should be kept as the base project for the later PoE parts.

## 14. Testing Checklist

Before submission, test:

- [ ] Application starts without errors.
- [ ] Main Menu appears.
- [ ] Report Issues opens.
- [ ] Location validation works.
- [ ] Category validation works.
- [ ] Description validation works.
- [ ] Attachment dialog opens.
- [ ] ProgressBar updates.
- [ ] Submit saves an issue.
- [ ] Issue ID is generated.
- [ ] Success message appears.
- [ ] Issues can be loaded by the administrator.
- [ ] Clear button works.
- [ ] Back button works.
- [ ] Logout works.
- [ ] Database connection works.

## 15. Part 1 Submission Items


https://github.com/user-attachments/assets/990745d2-8976-423b-8ef9-728a4eab384f


The Part 1 submission 
Municipal Services Application — Part 2

https://www.youtube.com/watch?v=grHwhgtqSAE

1. Project Overview

I developed this Municipal Services Application as part of my Advanced Application Development (AAPD7112) project at Rosebank College.

The purpose of the application is to help citizens interact with municipal services through a simple Windows Forms application. In Part 2, I extended my existing application by implementing a Local Events and Announcements feature that allows users to view upcoming events, search for events, and receive recommendations based on their search activity.

I used C# Windows Forms and Microsoft SQL Server to develop the application and manage its data
2. Technologies Used

C#

.NET Framework

Windows Forms

Microsoft SQL Server

ADO.NET

Visual Studio

Git and GitHub

3. Application Features
   Part 1: Report Issues

I developed the Report Issues feature to allow citizens to report municipal problems. Users can provide a location, select a category, describe the issue, and attach supporting files.

Part 2: Local Events and Announcements

I implemented the Local Events and Announcements feature with the following functionality:


Display upcoming municipal events.

<img width="695" height="174" alt="image" src="https://github.com/user-attachments/assets/15848a2b-799f-4d6d-a3b6-74da8675d197" />

Search for events by category.
<img width="1346" height="734" alt="image" src="https://github.com/user-attachments/assets/958ce0eb-d1a5-4024-8ef3-391a9edcfbf3" />

Filter events using a selected date range.

View event details.

Reset search filters and refresh event data.

View recent searches.

Receive event recommendations based on previously searched categories.

Create, edit, and delete events when using the administrator interface.

Store and retrieve event information from Microsoft SQL Server.

I also implemented collections and data structures to manage events, categories, search history, and recommendations.
Main Menu

I use the Main Menu to provide access to the different sections of the application, including Report Issues and Local Events and Announcements. The Service Request Status feature is reserved for the later stage of the project
4. Data Structures and Algorithms

I implemented different data structures to manage information and support the application's functionality.

Data structure

How I used it

Stack<string>

Stores recent searches so I can retrieve the most recent search history.

Queue<string>

Maintains searches in the order they are processed.

SortedDictionary<DateTime, Queue<Event>>

Organises events by date in a priority-style collection.

Dictionary<int, Event>

Allows me to retrieve events using their IDs.

SortedDictionary<DateTime, List<Event>>

Organises events according to their dates.

HashSet<string>

Stores unique event categories and prevents duplicate category values.

Dictionary<string, int>

Tracks how often users search for each category to support recommendations.

I also implemented a recommendation feature that uses category search activity and event dates to suggest relevant upcoming events.
5. Database

I used Microsoft SQL Server to store and manage event information in the MunicipalServicesDB database, using the dbo.Events table.

My current local connection string is configured for my development environment:

private readonly string connectionString =
    @"Data Source=FRANKLIN\SQLEXPRESS01;" +
    @"Initial Catalog=MunicipalServicesDB;" +
    @"Integrated Security=True";

The connection string must be updated to match the SQL Server instance on another computer.

To run the application on another machine, the required database and table structure must also be created or restored. I recommend including a database creation script in the repository so that the project can be set up more easily.

6. How to Run the Application

Prerequisites

Before running the application, I recommend installing:

Visual Studio with the .NET desktop development workload.

The .NET Framework version targeted by the project.

Microsoft SQL Server and SQL Server Management Studio.

Setup Instructions

Clone or download this repository.

Open the solution file (.sln) in Visual Studio.

Create or restore the MunicipalServicesDB database.

Ensure the dbo.Events table exists and contains the required columns.

Update the database connection string in EventManager.cs to match your SQL Server instance.

Restore any required NuGet packages.

Build the solution and resolve any errors.

Run the application from Visual Studio.

7. How to Use the Application

Launch the application and open the Main Menu.

Select Report Issues to access the issue-reporting feature.

Select Local Events and Announcements to view upcoming events.

Choose a category to filter events.

Enable the date filter and select a start date and end date to narrow the results.

Select Search to display matching events.

Use Reset to clear the filters or Refresh to reload the event data.

Review the recommendations and recent searches displayed on the events page.

If administrator access is enabled, use the available controls to create, edit, or delete events.

8. Email Notifications

I configured the application to support email notifications when new events are created, using Gmail SMTP.

For security, the SMTP email address and application password should be configured through environment variables:

MUNICIPAL_SMTP_EMAIL

MUNICIPAL_SMTP_APP_PASSWORD

These values must be configured on the computer running the application. I do not store email passwords directly in the source code or commit them to GitHub.

9. Project Structure

The project contains the Windows Forms interface, event management logic, database operations, and supporting classes.

Important files include:

MainMenuForm.cs — provides access to the main application sections.

LocalEventsForm.cs — manages the Local Events and Announcements interface.

EventManager.cs — manages event data, database operations, search history, collections, and recommendations.

CreateEventForm.cs — provides the interface for creating events.

EventEditForm.cs — provides the interface for editing events.

The exact file structure may vary depending on the latest version of the project.

10. Testing
<img width="1209" height="500" alt="image" src="https://github.com/user-attachments/assets/82e97bac-2357-486d-a7d9-244f2ea13df8" />

I recommend testing the following functionality before submitting the project:

Build and run the solution successfully.

Navigate between the Main Menu and the available features.

Load events from the database.

Search by category and date range.

Validate incorrect or reversed date ranges.

Reset filters and refresh event data.

Verify that recent searches are recorded correctly.

Confirm that recommendations respond to search activity.

Test event creation, editing, and deletion using administrator access.

Restart the application and confirm that saved event changes remain in the database.

Verify that email notifications work when SMTP settings are configured.

11. Future Development

I will continue developing the Municipal Services Application in the later stages of the project. Planned work includes the Service Request Status feature and additional functionality required for the final project.

12. Repository

GitHub repository: Municipal Services Application

Developer: Franklin Ngangu Simbi

Institution: Rosebank international, cape town SA

Module: Advanced Application Development (AAPD7112)

