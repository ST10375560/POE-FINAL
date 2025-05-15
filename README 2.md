## AgriEnergyConnect – Prototype Web Application

## Overview

ASP.NET Core MVC was used to create the prototype web application AgriEnergyConnect, which uses PostgreSQL as its database. The platform's purpose is to act as a link between farmers and workers in the renewable energy and agriculture industries. Secure user registration, login, profile administration, product handling, and administrative supervision are among its features. The setup procedure, development guidelines, system features, and user role obligations are all described in this README.

## 1. Needs

Make sure the necessary tools and applications are installed on your computer before you begin:

Version 8.0 of the.NET SDK or later
Workloads for web development and ASP.NET with Visual Studio 2022 or later
Make that PostgreSQL is set up and installed correctly.
Not required: For managing graphical databases, use pgAdmin.
Git (for cloning the repository and version control)

## 2. Establishing the Environment for Development

Clone the repository in step one.
Clone the repository from where it is hosted (e.g., GitHub) to access the project files. By doing this, all required files will be downloaded to your local computer.

Step 2: Database Configuration
To configure the database connection string, open the application configuration file and enter the host, port, database name, username, and password for your PostgreSQL server.

Step 3: Implement migrations and make database updates
Work with Entity Framework Core migrations in your development environment to build the required database structure. The models specified in the application will be used to automatically generate the necessary tables and relationships.

## 3. Constructing the Prototype and Operating It

Making use of Visual Studio
Launch Visual Studio and open the solution file.
Assign the starter project to the web application.
To restore all dependencies, build the project.
Use the integrated Kestrel or IIS Express server to run the application.
The program will start using a localhost URL in your usual browser.

Making Use of the Command Line
Go to the directory for the project.
Use the.NET CLI to build the project.
When you run the project, a localhost URL will allow you to view it in your browser.

## 4. Functionalities of the System

The following essential components are present in the AgriEnergyConnect prototype:

Safe user verification via registration and login
Access control for farmers and employees depending on roles
Farmer dashboard with tools for viewing and updating personal data
Features allowing farmers to add, change, and examine their products when managing them
Viewing and monitoring all registered farmers and their products through an employee dashboard
Access based on sessions to preserve user status and activity
Displaying alerts and error messages to improve user experience
Support for document uploads, claim filing, and approval workflow in the future

## 5. Roles for Users

Farmers:

Farmers can create an account, log in, and access their own dashboard.
able to include new farm items with pertinent information
can change or remove their current offerings.
A planned feature that allows users to submit claims and see their status
may change the details in their profile

Employees:

A dashboard for administration is accessible to employees.
able to see a list of all farmers who have registered
capable of maintaining product listings and farmer profiles
The ability to examine and accept farmer claims (planned feature)
has access to enhanced permissions that ordinary users do not have.

## 6. Organisation of the Project

The program is divided into distinct folders for data management, views, models, and controllers. The views offer the user interface, the controllers oversee logic and routing, the data folder manages database context and migrations, and the models specify the data's structure. A specific public directory contains static files like CSS and JavaScript.

## 7. Technology Employed

Several contemporary technologies are used in the project, including:

ASP.NET Core MVC for the structuring of web applications
Core for object-relational mapping in Entity Framework
The system for managing relational databases is PostgreSQL.
Rendering dynamic web content with Razor Pages
Using Bootstrap to create responsive designs
User state control using session handling
Git for tracking versions and managing sources

## In conclusion,

The goal of the foundational platform AgriEnergyConnect is to showcase important features in the agricultural-energy space. PostgreSQL integration, a clear structure, and a role-based access system provide a scalable foundation for further growth. Technical users may expand the application's capabilities through clean, modular code, while non-technical users can easily traverse the application thanks to its user-friendly interface.

Future iterations are anticipated to include more features like enhanced claim processing, HR role administration, document storage, and reporting capabilities.
