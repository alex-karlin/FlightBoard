# Flight Board
Welcome to the Flight Board repository

## Components
Flight Board is made up of the following components:
1. <del>[Flight Board UI](projects/flight-board-ui)</del>
2. [Flight Board Service](projects/flight-board-service)
3. <del>[Identity Service](projects/identity-service)</del>

&ast; Flight Board UI and Identity Service will be implemented later  

## Building and running

Prerequisites:
1. Ensure Chocolatey is installed
   1. You can check if you have it installed by using `choco -v`
2. Ensure Node.js is installed. Currently tested against 16.16.0 LTS
   1. You can check if you have it installed by using `node --version`
   2. You can install Node.js using:
   ```
   choco install nvm
   nvm install 16.16.0
   nvm use 16.16.0
   ```
   3. `npm install`
   4. `npm run init` - make sure you have a default instance of SQL Server installed locally, or else database migrations will fail and the application won't work properly 


To run Flight Board solution you will only need to execute:
1. `npm run start`

This command start Flight Board Service

## Development in Flight Board

### Flight Board Service
- Open Visual Studio and open the FlightBoard solution
- Attach to the running FlightBoard.Api.exe process for debugging
   
