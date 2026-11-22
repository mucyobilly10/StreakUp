# 🚀 StreakUp: Personal Habit Tracker

👨‍💻 **Student Name:** Mucyo Billy  
🆔 **Student ID:** 26853  
📚 **Course:** DotNet  
📅 **Date:** 19 November 2026  
📄 **Document Version:** 1.0  

---

## 📖 1. Introduction
StreakUp is a Windows desktop application that helps users build good routines by recording daily habits, marking them as done, and viewing streaks and progress. It strictly follows the **MVC architecture** and uses **ADO.NET** to communicate with a **MariaDB** database.

## 🛠️ 2. Technology Stack
- 💻 **Language:** C#
- 🖥️ **Framework:** .NET Windows Forms (WinForms)
- 🏗️ **Architecture:** MVC (Model-View-Controller)
- 🗄️ **Database:** MariaDB (via XAMPP)
- 🔌 **Data Access:** ADO.NET (MySqlConnector)
- 🔐 **Security:** BCrypt for password hashing

## ✨ 3. Key Features Implemented
- 🔐 **User Accounts:** Secure Registration and Login (Passwords are hashed using BCrypt, never stored as plain text).
- 📅 **Habit Management:** Add, Edit, Delete, and Archive/Restore habits without losing history.
- ✅ **Daily Logging:** Mark habits as Done/Undo for today or past dates (up to 7 days back).
- 📊 **Streaks & Progress:** Calculates Current Streak, Longest Streak, and Weekly Progress %.
- 🔍 **Search & Filter:** Search habits by name and filter by Active/Archived status.
- ⏰ **Reminders:** Visual reminders on the dashboard for habits due soon.

## 📸 4. Application Screenshots

### 🔑 Login Screen

<img width="831" height="441" alt="LoginPage" src="https://github.com/user-attachments/assets/0e41a834-385e-4340-8106-b79500b49c44" />


### 🏠 Main Dashboard

<img width="840" height="467" alt="dashboard2" src="https://github.com/user-attachments/assets/62d57a1f-946f-4a4e-abb2-392d07f7bd53" />


### 📈 Streaks and Weekly Progress
<img width="844" height="493" alt="Streak Progress" src="https://github.com/user-attachments/assets/a431abba-203b-4a08-a8a6-c0e2d4f8dfe8" />


## 🏃‍♂️ 5. How to Run the Project

### 📋 Prerequisites
- Visual Studio 2022 (with .NET Desktop Development workload).
- XAMPP installed (Apache and MySQL services running).

### 💾 Database Setup
1. Start **Apache** and **MySQL** in the XAMPP Control Panel.
2. Open phpMyAdmin (`http://localhost/phpmyadmin`).
3. Create a new database named `streakup_db`.
4. Import the SQL script located in the `Database/streakup_db.sql` file to create the tables (`users`, `habits`, `habit_logs`).

### ▶️ Running the App
1. Open `StreakUp.sln` in Visual Studio.
2. Ensure the connection string in `AppConfig.cs` matches your XAMPP setup (default: `Server=127.0.0.1;Port=3306;Database=streakup_db;User ID=root;Password=;`).
3. Press **F5** to run the application.

## 🗂️ 6. Project Structure (MVC)
- 📁 **Models:** Contains entity classes (`User`, `Habit`, `HabitLog`) and Repositories (ADO.NET SQL logic).
- 🎛️ **Controllers:** Contains business logic, validation, and coordinates between Views and Repositories.
- 🖼️ **Views:** Contains the Windows Forms (UI) and event handlers.
