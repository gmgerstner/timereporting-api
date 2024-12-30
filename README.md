# Time Reporting API

The Time Reporting API records time spent on individual tasks and can be used with any timesheet system. This code is the server-side (API) logic.

This code is written in C# and SQL with Visual Studio.

## Requirements

- To install, you will need a Windows Server running IIS.


## Installation

### User Interface

- First set up the UI in ISS (see https://github.com/gmgerstner/timereporting-ui)

### Database

- Make sure the database server has the database called TimeReporting
- Right-click the project GMG.TimeReporting.Database
- Select Publish and check the fields:
  - Target database
  - Database name
  - Publish script name
- Click Publish
- Give permission to the Application Pool to read and write to the database
- Add the neccesary entry to the security application for logging in (steps not included here)

### API Code

- Create a folder for the API code. Recommended: Call it something similar to the UI's folder with _api appended.
- In IIS, right-click the site for the UI and select Add Application.
- Enter the following:
  - Alias: api
  - Physical path to where the .NET code will be installed.
- Update path in the file: timereporting-api\GMG.TimeReporting.WebApi\Properties\PublishProfiles\FolderProfile.pubxml
- Deploy the built code to the api folder.
	- Right-click the GMG.TimeReporting.WebApi project and select Publish
	- Click the Publish button