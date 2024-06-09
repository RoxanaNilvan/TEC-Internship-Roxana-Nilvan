
# Prerequisites:

1. Install Visual Studio 2022 Community:
</br> https://visualstudio.microsoft.com/vs/community/
</br>Make sure that during the installation process, you check ASP .NET and web development and .NET desktop development:
![Capture456](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/ea4fe745-5fb9-4846-b976-3ece3f117db6)
(Note: if you already have VS Community installed, make sure you install .NET Core 8 SDK in order for the project to run)


2. Install SQLite/ SQL server Compact Toolbox, after the installation of Visual Studio 2022 Community:
https://marketplace.visualstudio.com/items?itemName=ErikEJ.SQLServerCompactSQLiteToolbox <br>
(make sure the visual studio is not running before installation)

3. Create your own github repository, download the source code and open the project in Visual Studio. We'd like you to name your repository TEC-Internship-[FirstName]-[LastName]

 # Setup & Intro


1. Load the database from the repository:
![Untitled2](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/60ce2d2f-f90b-4b59-978c-72b4267e180a)
![Untitled5](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/e815f9d1-915b-4a95-8d04-a20e2f254591)
![Untitled6](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/9bbe9b14-73d7-4391-ba85-25c7d04ea8e1)


2. Change to run on multiple startup projects:
![Untitled4565](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/8a766183-0504-4738-ac64-3fceb34f3016)

3. Once you run the applications, you will notice that 2 tabs will open:
![Untitled90](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/1fa4879d-8ded-4a1a-b36b-ffc35dc49669)

One represents the Api app, and the other is the Web App.

4. If you for example, click on the person tab, you will get an exception:
![Untitled91](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/233d05f2-54bd-4b68-ae9b-84569a8d66b0)
In order to fix this, you will have to do a few things:<br>
5.a. Change the path of the database with your own, in APIDbContext.cs: <br>
![Capture92](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/74cbff47-7219-4f5a-a279-fa471c66faab)

5.b. Change the port in the Controller's of the Web App: <br>
![Capture000](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/ebdcc827-c7e9-49c1-b560-bfebb633146d)

6. Now after you saved your changes and run the apps, once you clicked on the Person button in the web app, you should be able to see some people that have been fetched from the database, and their data to be displayed:
![Capture45](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/92f7ea2a-9abe-46ac-a4a2-918fcffbc7ba)

<br>
Neat! <br>

Now, before you get started it would be:

## Nice to read
https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database <br>
https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio <br>
https://learn.microsoft.com/en-us/visualstudio/debugger/debugger-feature-tour?view=vs-2022 <br>

and finally, let's do some fixes!

# Tasks:
Database diagram: <br>
![Capture5465465](https://github.com/AgrostemmaGithago/TEC-Internship/assets/129935966/a95a3f3f-9ee6-42c6-bf8c-cf67ffb5741b)



1. As a User I want to be able to delete a Person
2. As a User I need to be able to update a Person's Information
3. As a User I need to be able to create a new Person in the database
4. As a User I need to be able to add a new Salary
5. As a User I want to be able to edit/add new person's details

	Implementation: 
	- create PersonDetail Model according to the database diagram
	- add the PersonDetails database set to the APIDbContext
	- create a new migration using Package Manager Console <br>
	read: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli#create-your-first-migration <br>
	Troubleshoot: <br>
	ERROR: "dotnet : Could not execute because the specified command or file was not found." Please run "dotnet tool install --global dotnet-ef --version 8.*" <br>
	ERROR: "No project was found. Change the current working directory or use the --project option". Please change the path to the ApiApp -  run "cd .\[_]\ApiApp" <br>
	- modify the View so I could update/add a Person's Details from the web app (Birthday and PersonCity)

6. As a User I want to be able to delete a Department <br>
7. As a developer I want to not change the port of the api in all of the Web Controllers <br>
   Details:  Ctrl + Shit + F in the entire solution and search for "HINT"
<br><br>
Are you bored yet? get a lot of points by: <br>
8. Adding Authentication to the app, you can implement as you please, but to give you some ideas: <br>
    	- create a Login View with admin username and password input fields. could be a popup or create the login in the Header of the app. <br>
    	- create an Admin Table with user information <br>
    	- I should not be able to do any of the RESTful api calls on person, persondetails, salary or department tables unless I am logged in <br>

9. Having too much time on your hands? Do any kind of improvements you wish. Just let us know via e-mail once you send the link with your repository what improvements you've done.
    
     
