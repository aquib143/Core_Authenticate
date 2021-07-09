# Core_Authenticate example without using identity

In this project i have shown how to create login and registration form using asp.net core with real-time example. 
And also how to use session  asp.net  core. We used the "Dotnet core database first approach" for crud operation.

Explanation Step By Step...

Step 1. Create user details table in sql server database.

Step 2. Create new asp.net core mvc project in visual studio in the name of Dbfirstapp.

Step 3. Create the class for ecommerceContext.cs, Userdetails.cs, LoginViewModel.cs, RegistrationViewModel.cs in Model folder.

Step 4. Configure connection string in appsetting.json file

Step 5. Add Dbcontext service, Session in a startup.cs file configure service function.

Step 6. Create controller for AccountController, HomeController in controller folder.

Step 7. This time to create UI(view) for login and registration. Right click the AccountController index function and create view for login, 
        registration function for registration view. Remember that in this function homecontroller.



NOTE :- In this project i am using SQL Server for the database. Data script is also available in Repositories.
