# Simple demo for Clean Architecture

This is a solution meant to show a possible maintainable structure. The domain has 2 entities.
As functionality, there is the possibility to add new entities and display the existing ones.

The solution's purpose is to highlight the structure and does not represent a complete solution.

This solution has an API and a React app.

## API
The API is a .NET Core API that follows clean architecture principles.

For data persistence, .NET Core EF (code first approach) is used.

To generate, the database use ```update-database``` command.
Initial migration and some seed data are already in place.

Validation on the server side is done using FluentValidation.


## UI
This solution also has a simple React app that can be used to call the API and interact with it.

Some basic validations are in place, if you want to test the validations on the API side just call the API with Swagger