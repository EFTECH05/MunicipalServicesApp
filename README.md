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


The Part 1 submission should include:

1. The Word document containing the research.
2. The complete source code.
3. This README file explaining how to compile, run and use the application.
