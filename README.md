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
Municipal Services Application — Part 2 YouTube video here 

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

<img width="1063" height="302" alt="image" src="https://github.com/user-attachments/assets/e65b7880-1e39-49e1-aeb1-68a96ade72b3" />
<img width="680" height="278" alt="image" src="https://github.com/user-attachments/assets/e73c06c2-7d71-4d11-bed8-69e11e2f8cbc" />

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

<img width="671" height="158" alt="image" src="https://github.com/user-attachments/assets/51eb1c6e-bf28-4722-b16d-45d159812165" />

<img width="979" height="361" alt="image" src="https://github.com/user-attachments/assets/223ca4d6-b6c2-4ea6-a6a8-e65a8815ba32" />


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

Municipal Services Application – Part 3
# 🇿🇦 Municipal Services Application – Part 3

## Advanced Application Development (AAPD7112)

**Portfolio of Evidence – Task 3: Final Implementation**

A C# Windows Forms desktop application developed to improve municipal service management in South Africa. This final stage focuses on service request tracking, advanced data structures, algorithms, database integration and application testing.

---

## 👨‍💻 Developer Information

| Detail | Information |
|---|---|
| Developer | Franklin Ngangu Simbi |
| Institution | Rosebank College – The IIE |
| Qualification | Advanced Diploma in Application Development |
| Module | Advanced Application Development |
| Module Code | AAPD7112 |
| Project | Municipal Services Application |
| POE Section | Part 3 – Final Implementation |

---

## 📌 Project Overview

The Municipal Services Application is a Windows desktop application developed using C# and Windows Forms.

The purpose of this project is to help manage municipal services and make it easier to organise and track service-related information.

Part 3 focuses on the final implementation of the application by introducing advanced data structures and algorithms to improve how information is organised, searched, prioritised and managed.

The application builds on the previous development stages, including reporting municipal issues and managing local events.

---

## 🎥 Application Demonstration

Watch the full demonstration of the Municipal Services Application:

[![Municipal Services Application Demo](https://img.youtube.com/vi/LgZvm3tG780/maxresdefault.jpg)](https://youtu.be/LgZvm3tG780)

▶️ **[Watch the Municipal Services Application Demo on YouTube](https://youtu.be/LgZvm3tG780)**

The video demonstrates the desktop application and its features.

---

## 🚀 Main Features

### 1. Municipal Service Request Management

- Create and manage municipal service requests.
- Track service request information.
- Generate unique service request reference numbers.
- Manage request statuses.
- Assign priorities to service requests.
- Record service request history.
- Support municipal service request management.

### 2. Priority Management

The application uses a Min-Heap to organise service requests according to priority.

This allows higher-priority requests to be retrieved before lower-priority requests.

### 3. Service Request History

The application supports tracking changes made to service requests.

This helps maintain information about request progress and status updates.

### 4. Municipal Event Management

- Create and manage municipal events.
- Store event information.
- Organise upcoming municipal activities.
- Manage event-related information.

---

## 🌳 Advanced Data Structures and Algorithms

One of the main requirements of Part 3 is the implementation of advanced data structures and algorithms.

The project includes the following:

| Data Structure / Algorithm | Description |
|---|---|
| Trees | Organise information using connected nodes. |
| Binary Trees | Allow each node to have up to two children. |
| Binary Search Trees | Organise values to support searching. |
| AVL Trees | Maintain balance during insertion and deletion. |
| Red-Black Trees | Use colour rules to maintain balance. |
| Min-Heap | Organise information according to priority. |
| Graphs | Represent connections between municipal departments. |
| Breadth-First Search (BFS) | Visits connected nodes level by level. |
| Depth-First Search (DFS) | Explores graph connections before backtracking. |
| Minimum Spanning Tree (MST) | Finds a minimum-cost connection between connected points. |

These implementations demonstrate how different data structures and algorithms can solve practical programming problems.

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| C# | Main programming language |
| Windows Forms | Desktop graphical user interface |
| .NET Framework 4.7.2 | Application development |
| Microsoft SQL Server Express | Database management |
| ADO.NET | Database connectivity |
| Microsoft Azure SQL Database | Cloud database hosting |
| Visual Studio | Development environment |
| Git | Version control |
| GitHub | Source-code hosting |

---

## 🗄️ Database Implementation

The application uses Microsoft SQL Server for database management.

ADO.NET is used to connect the C# application to the database and perform database operations.

The database stores application information and supports the management of municipal service requests and other records.

The project also includes work on migrating the Municipal Services database to Microsoft Azure SQL Database.

### Database Features

- Store municipal service request information.
- Retrieve and manage application records.
- Track service request statuses.
- Store service request history.
- Support database operations through SQL Server.

---

## ☁️ Microsoft Azure Integration

Microsoft Azure was used to explore cloud database hosting.
<img width="1365" height="726" alt="image" src="https://github.com/user-attachments/assets/b32734b5-fa48-4227-a3ee-9bae78d505ec" />

The Municipal Services database was migrated to Azure SQL Database.

This demonstrates how a desktop application can connect to a database hosted in the cloud rather than relying only on a local database server.

---

## 🧪 Testing and Quality Assurance

Testing was performed to verify the functionality of the application and identify possible errors.

The testing process included:
<img width="1073" height="307" alt="TEST12" src="https://github.com/user-attachments/assets/d7c7c94f-696b-480f-bd7d-ce4328e42d0f" />
<img width="1361" height="480" alt="paspasds2" src="https://github.com/user-attachments/assets/e99f94bf-3606-4741-a64c-117322be60e7" />

- Unit testing.
- Application build verification.
- Database connectivity checks.
- Service request functionality testing.
- Data structure testing.
- Heap and priority management testing.
- Graph operations and algorithm testing.

Testing helped improve the reliability and quality of the final application.

---

## ⚙️ Installation and Setup

### Requirements

- Windows operating system.
- Microsoft Visual Studio.
- .NET Framework 4.7.2 development support.
- Microsoft SQL Server Express or access to the configured Azure SQL Database.
- Git (optional).

### Installation Steps

**1. Clone the repository**

```bash
git clone YOUR_GITHUB_REPOSITORY_URL
```

**2. Open the project**

Open the solution file (`.sln`) using Microsoft Visual Studio.

**3. Configure the database**

Configure the database connection string according to your SQL Server environment.

**4. Restore dependencies**

Allow Visual Studio to restore the required NuGet packages.

**5. Build the application**

In Visual Studio, select:

`Build → Build Solution`

**6. Run the application**

Press `F5` or click Start in Visual Studio.

---


## 🎯 Learning Outcomes

Through this project, I gained practical experience in:

- Developing desktop applications using C# Windows Forms.
- Connecting applications to Microsoft SQL Server.
- Using ADO.NET for database operations.
- Implementing advanced data structures.
- Working with Binary Search Trees, AVL Trees and Red-Black Trees.
- Using Heaps for priority management.
- Implementing graph traversal algorithms.
- Understanding Minimum Spanning Trees.
- Performing unit testing and debugging.
- Working with Microsoft Azure SQL Database.
- Managing source code using Git and GitHub.

---

## 📚 Academic Information

**Institution:** Rosebank College – The IIE

**Qualification:** Advanced Diploma in Application Development

**Module:** Advanced Application Development

**Module Code:** AAPD7112

**Assessment:** Portfolio of Evidence – Part 3

**Project:** Municipal Services Application for South Africa

---

## 👨‍💻 Author

**Franklin Ngangu Simbi**

- GitHub: [EFTECH05](https://github.com/EFTECH05)
- Portfolio: [Franklin Ngangu Portfolio](https://eftech05.github.io/franklin-portfolio/)

---

## 📄 License

This project was developed for academic purposes as part of the Advanced Application Development (AAPD7112) Portfolio of Evidence.



12. Repository

GitHub repository: Municipal Services Application

Developer: Franklin Ngangu Simbi

Institution: Rosebank international, cape town SA

Module: Advanced Application Development (AAPD7112)

