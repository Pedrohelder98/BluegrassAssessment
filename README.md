# Overview

BluegrassAssessment is a .NET-based web application developed with ASP.NET MVC and Umbraco CMS, designed to manage and present structured content.
The application provides flexibility through modular components, making it easy to manage different types of pages, such as Contact Us and General Content pages.

## Features

Content Management with Umbraco: This project uses Umbraco CMS for content management, enabling dynamic, content-driven pages without hardcoding.
MVC Architecture: Implements the Model-View-Controller pattern to separate business logic from user interface components.
Reusable UI Components: Includes modular components like Hero sections, Social Media links, and rich text sections to standardize and simplify content creation.


## Project Structure

Controllers: Define request handling and page routing for different content pages.
Models: Represent application data, like page-specific models and components.
Views: Contain the HTML templates and partial views for rendering components.
Services: Encapsulate data mapping and business logic to keep controllers clean and maintainable.


## Setup Instructions

### Clone the Repository:

Clone the repository to your local machine using:
'git clone https://github.com/Pedrohelder98/BluegrassAssessment.git'

Navigate to the Project Directory:
'cd BluegrassAssessment'

Restore Dependencies:
'dotnet restore'

Build the Solution:
'dotnet build'

Run the Application:
'dotnet run'

Once running, the application should be accessible at https://localhost:44394.


## Configuration
This project uses configuration files to manage different settings:

appsettings.json: Contains general application configurations like logging, database connections.
appsettings.Development.json: Includes development-specific configurations and overrides for local testing.

Update these configuration files as necessary, especially if you are deploying to a production environment.

## Usage

Launching the App: Access the application on https://localhost:44394/ after running the dotnet run command.

Interacting with Pages: Navigate to different pages to see how content from Umbraco CMS is displayed dynamically.

Content Management via Umbraco:
Open the Umbraco CMS dashboard on https://localhost:44394/umbraco.
Manage content for existing pages or create new pages.
Changes made in Umbraco will reflect in real-time on the associated pages.

### Umbraco Credentials
Use the following credentials to log in to the Umbraco CMS:
 - Username: admin@admin.com
 - Password: adminPassword1234

#### Umbraco Content Structure
The Umbraco CMS is pre-configured with the following content structure:

 - Site: The main node that contains settings for header and footer sctions across all pages.
 - Contact Us and General Content: Two pages with same structure: "Page Header" and "Main Content" properties, but have diferent templates.
	- "Page Header": Block Grid data type that its possible to add "Hero" and "HeroCta" components.
	- "Main Content": Block Grid data type that its possible to add "Rte" component.

## Technologies Used
.NET 8: The core framework used for development.
ASP.NET MVC: Provides a structured, scalable application architecture.
Umbraco CMS: A CMS that allows for easy content management and integration.
SQLite: A lightweight database used for data storage (found in umbraco/Data/Umbraco.sqlite.db).

## Folder Structure

The key folders in this project are:

### Controllers (/Controllers) 
Handles routing and business logic for pages.

 - ContactUsPageController.cs: Manages the Contact Us page interactions.
 - GeneralContentPageController.cs: Manages general content pages.

### Models (/Models) 
Defines data models and structures.

 - Components: Contains reusable component models, such as HeroComponent, HeroCtaComponent, RteComponent and SocialMediaComponent.
 - Umbraco: Models related to Umbraco documentTypes, including page-specific models and header or footer settings for all the website pages.

### Views (/Views): Contains HTML views rendered on the client.

 - Layout.cshtml: Defines the base layout for all pages.
 - contactUsPage.cshtml, generalContentPage.cshtml: Define page-specific layouts.
 - Partials: Contains reusable partial views, such as Header, Footer, and component views for modular design.

### Services (/Services): Includes logic for mapping and data handling.

 - MappingComponents.cs: Service for managing page and components mapping.

### umbraco/Data 
Stores the SQLite database used by Umbraco for data management.
