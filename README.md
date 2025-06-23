## AgriEnergyConnect – Prototype Web Application

## Overview

AgriEnergyConnect is a web application prototype that was created with PostgreSQL and ASP.NET Core MVC. It acts as a link between agricultural and renewable energy workers and farmers. The following are important features:

-Safe user registration and login 
-Access based on roles (for employees and farmers)
- Dashboard and administrative monitoring 
- Product and profile management 
- Scalable framework for future development

## 1. Requirements

Before setting up, make sure you have the necessary tools installed:

-.NET SDK version 8.0 or higher 
- Visual Studio 2022 (with workloads for Web and ASP.NET development)
- The correctly installed and configured version of PostgreSQL
- pgAdmin (preferential) - for database management using a GUI
- To clone the repository, use Git.

## 2. Establishing the Environment for Development

Step 1: 
- git clone <repository-url>
- Download all project files to your local machine


Step 2: Database Configuration
- Open appsettings.json
- Update the PostgreSQL connection string with:
- Host
- Port
- Database Name
- Username
- Password

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

## Changes Made to Part 1:

-	Bullet points added so it is easier to read the document
-	The tone of the report has changed by removing high sounding words
- Definitions that were long quotes has been shortened
-	Overwhelming paragraphs removed
-	Tone of certain paragraphs especially justification paragraphs are more convincing as requested
-	The application of theoretical concepts from the course addresses the AgriEnergy Connect Platform project’s immediate needs and demonstrate an understanding of their broader implications and potential applications as requested. 
-	Bold text used for main headings

## Changes Made to Part 2:

-	ReadMe File has bullet points and is simplified more but contains information needed
-	Code is able to run fine
-	ReadMe File has bold texts
-	Delete buttons work now
-	Login works fine
