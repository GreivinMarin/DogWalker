About the application
   - Created with visual studio 2019
   - .NET Framework 4.8
   - 1 Solution (DogWalker), 4 projects (DogWalker.Core, DogWalker.Infastructure, DogWalker.Test and DogWalker.UI)

To run the application 
   - Please clone the repository (it is public for now): https://github.com/GreivinMarin/DogWalker
   - Build the application once only. (There is an initial pre loaded database that is replaced on every build on the bin folder)
   - Run the .exe file from the generated bin folder.

To Use the application   
   - There is a main form with a menu.
        - Processes -> Walks (Main process logic)
        - Catalog -> Clients
                  -> Dogs
                  -> Breeds
   - Walks Form: This is the main logic form, where you'll find all the requirements requested in the PDF, 
        - There are 2 tabs ("Add Walk" and "Search Filters") 
        - By default the grid shows the records from the first day of the current month, but you can search by client name, dog name enable or disable the date ranges and of course set new dates to search records from other dates (the pre-loaded db has infomartion from Jan to Jun this year only.)
        - To insert new records change to the tab "Add Walk" select a client, dog, date and type the duration and click save.
        - To Edit or delete you'll find the respective buttons for each record inside the grid.
     

Some important technical details
   - Portable database (SQLite) handy for this kind of small projects
   - Relational and Normalized db tables-> I created the catalog table for Breed, Dogs and Clients and finally the Walk table where the information is stored
   - Use of Repository Pattern so we can decouple the Database from the application, If we want to migrate to other db the change will be minimun.
   - Naming standard for the controls -> usefull to easy understand and find the different events. 
   - Unit Testing: Used xUnit to add tests for a helper and a Repository, the advantage of the Repository Pattern be able to decouple them from the actual DB and be able to test them.
   - Trying to keep methods small, less code as possible in the events methods.
   - Use of async methods when there is a load of data to prevent UI freezes (since I used Framework 4.8 I was able to used Async for 3.5 and older versions we can use backgroundWorker)
   - Use of anchor and docking to keep the forms Responsive.
   - The Catalog forms are child forms, inside the Main form, but the Walk Form is independant so the user can move it to other screen or so to work more confortable.
 