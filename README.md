# Contacts
It is sample .Net 7 WebApi with JWT authentication
# How to setup:
1. Create empty database Contacts on (local) MSSQLServer instance and allow integrted security access for current user
2. Open solution in Visual Studio and build it
3. Change startup project to ContactsApi.Database and run it. Ensure console will message 'Success'
4. Change startup project to ContactsApi.Web and run it
5. User email support@yahha.com and pwd 77777 to call Login
6. Use received token to Authorize Swagger page
7. Solution folder contains teslog.saz for Fiddler. It contains request samples
8. Now you can test Add or List methods
