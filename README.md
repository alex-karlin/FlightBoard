# Flight Board
Flight Board is a web-based application that displays departure flights for a particular airport.

## Components
Flight Board is made up of the following components:
1. [Flight Board UI](projects/flight-board-ui) - public web application that displays flight information
2. [Flight Board Service](projects/flight-board-service) - provides web API that's used by the public web client
3. <del>[Flight Management UI](projects/flight-management-ui)</del> - internal web portal that's used by airlines to update their flight information
4. <del>[Flight Management Service](projects/flight-management-service)</del> - web API for flight management
5. <del>[Identity Service](projects/identity-service)</del> - universal authentication service that implements OIDC protocol and supports SSO
5. <del>[Caching Service](projects/caching-service)</del> - distributed cache that is used to deal with heavy traffic to the public flight board

&ast; Due to the scope of work Flight Management UI, Flight Management Service, Identity Service and Caching Service are out of scope of this exercise, but may be implemented later (subject to requirement priorities).  

## Building and running
Prerequisites:
1. Ensure Chocolatey is installed
   1. You can check if you have it installed by using `choco -v`
2. Make sure you have a default instance of SQL Server installed locally, or else database migrations triggered by the `install` script will fail and the application won't work properly
3. Ensure Node.js is installed. Currently, tested against 16.16.0 LTS
   1. You can check if you have it installed by using `node --version`
   2. You can install Node.js using:
   ```
   choco install nvm
   nvm install 16.16.0
   nvm use 16.16.0
   ```
   
To initialize the Flight Board projects you will need to run the following scripts:
   1. `npm install`
   2. `npm run init` - this script does the following:
      1. installs .NET Core SDK
      2. restores NuGet packages
      3. installs EF tools for automatic migrations
      4. applies database migrations to the default SQL Instance 
         1. If you use a named instance or use custom credentials you can update the connection string in [appsettings.json](projects/flight-board-service/Api/appsettings.json) file 


To run Flight Board solution you will only need to execute:
1. `npm run start` - this command start both, the client and the service

## Development in Flight Board

### Flight Board Client
For the purpose of this exercise WebStorm was used, but feel free to use your IDE of choice to develop the client.

Prettier is used to keep the code formatting consistent, so you may need to use a prettier plugin for this to work (consult with your IDE documentation). 

### Flight Board Service
Visual Studio 2022 and .NET 6 are required to develop [FlightBoardService](projects/flight-board-service/FlightBoardService.sln) solution.
To debug the service you'll need to do the following:
1. Open Visual Studio and open the FlightBoard solution
2. Attach to the running Api.exe process
Alternatively you can run the application from Visual Studio in debug mode.

If you prefer Package Manager Console to apply migrations you can use the following command:
```
Update-Database
```
To add new migrations you can use the following command:
```
Add-Migration InitialCreate
```
   
