# LAB-3-DatabaseWithEF

Lab 3 project - completed by Sofie+Gerda

To make sure that everything works as it should, you should first download a back-up database file and install that database on (localdb)\\MSSQLLocalDB server.
This way the database will be created with all the test data that is needed to be able to test the program.

Efter you have installed the database, check that the connection string matches (connection string can be found in appsettings.json and even in BokHandelContext).
BokHandelContext and models were created through Scaffolding (reverse engeneering the database).

If everyhting matches then there should be no problem to run the program directly. There is already a super easy user inteferance to quikly test all the methods that are there. To make sure that the the test goes smoothy, when promptet to enter a book name or shop ID, it has to be entered as it appears on the console as th user interferance does not contain error handling features
