# About this project

__Overall Goal__
- 

![Image description](https://github.com/nb-assignment/funda-assignment/blob/master/Funda.Frontend/wwwroot/Images/funda.PNG)

# Architecture explanation

`DoughnutFactory` solution contains below projects:

- `DoughnutFactory.Web`: Angular project with .Net core to show the result in a browser. This project calls the API end points.
- `DoughnutFactory.Api`: .Net core project for API end points. It uses dependency injection to call the services.
- `DoughnutFactory.Services`: .Net core class library which is used for all business logic. It calls the repositories using unit of work
- `DoughnutFactory.Data`: .Net core class library which is used to play with the data. This project contains migrations & repositories which connects with the database using dbcontext.
- `DoughnutFactory.Entities`: .Net core class library which is used to preserve all the models used in the solution including the data models.
- `DoughnutFactory.Tests`: .Net core xUnit project which is used to write the unit test cases for controllers and services.
- `build.dev.yml`: Yml file which can be integrated for CI\CD of the web application, more details below.

__Why xUnit for testing?__

I really like xUnit and have been using it quite some time. I like the way we can mock the service calls, can return the mock data including the await calls. On top of that xUnit runs the tests parallel which saves a lot of time.

# Timeline and thought process for the assignment

__First step__
- When I received the assignment, I first read the requirement 3 times to understand what is required, after reading I wrote down high-level requirement which inclcudes:

1) Backend changes which includes API end points, database operations, services & repositories
2) Front changes which incldues coonecting with apis to get the data, show proper styling for questions & buttons, last but not the least - the decision tree
3) Unit tests for both

__Project structure__

- I first started by creating the project structure which I exaplained above and started adding different layers as it goes.

__API & backend logic__

- Later I finalised the DB structure and started writing api end point which flows through: API -> Service -> UnitOfWork -> Repositories -> Database
- I used unit of work design pattern for better organization of the code and for better transaction
- I tried to use different design patterns to achieve single responsibility, add extensions instead of long methods, dependency injection, properly using interfaces wherever needed, repository pattern etc

__UI in Angular__
- 
- Parallelly I started with the UI in Angular by adding small components like buttons, questions, tree etc and called them on basis of conditions from main home component
- Consumed the API to get the tree nodes to show questions
- Used orgchart npm package to show the data as a tree
- Added support for logging, appconfig, localization etc

__Business logic:__

- Later I added the business logic to make sure proper sturcture of a tree is returned which is built from different tree nodes
- manager service calls build tree method until all nodes are processed and converts them into children

__Data logic:__

- I used a tree structure which has id, question along with positivenode & negativenode
- I seeded the data on basis of the choices given in the assignment

__Unit Tests__

- I added test cases for the controller to make sure correct items are returned, mocked the service responses
- I added test cases for main business logic to make sure it returns correct tree from tree nodes

__Security__

- As I come from a security background, I always like to secure any new web applications I write. As a result, I added some basic steps to secure the app by adding a few security header settings in startup.cs class

__CI\CD__

- To make sure the app would be able to get integrated with the builds in the future, I added .yml file along with some basic steps to build the solution along with creating the artifacts.

__Misc tasks__

- In the end I added Lobster ink logo and some UI improvements. Also, did refactoring wherever needed

# Future scope and TODO

Though I tried to add all required steps for the application, I feel it can be improved if I invest more time in it.

__Areas to improve:__

- To write more test cases for UI and for ts classed in angular

# .Net Core version

.Net Core 3.1

# Angular version

Angular 8

# IDE version

Visual studio 2019

## Nuget restore

Open the solution in VS 2019 and restore the nuget from solution

or

Run below command to build the project from the root folder.

`dotnet restore`

## Build

Open the solution in VS 2019 and build the project 

or

Run below command to build the each project from the root folder.

`dotnet build`

## Run Application

Set `DoughnutFactory.Web` and `DoughnutFactory.Api` as the startup project and run on IIS Express

## Running unit tests

You may use Test -> Test explorer to run the unit tests or run below command from the project `DoughnutFactory.Tests`

`dotnet test`

## Yml file for CI\CD

There is a `.yml` file present under the folder of the project `Funda.Frontend`

It contains some basic steps like

- Trigger branch name(can be changed as per the need)
- Build machine details
- Variable declaration
- Steps like Nuget restore, build solution, copy & publish artifacts

## Further queries

You may reach out to me directly via email.
