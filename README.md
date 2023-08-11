# Schedular API
Schedular API is a .NET 7 web API application that provides scheduling functionality to its users. This API allows users to create, view, update, and delete schedules for various tasks. The API also provides authentication and authorization features to ensure that only authorized users can access or modify schedules.

Getting Started
To get started with this API, you need to set up the development environment first. Follow these steps to set up the development environment:

## Prerequisites
- .NET 7 SDK
- Visual Studio 2022 or later

## Installation
- Clone the repository to your local machine.
- Open the solution file SchedularAPI.sln in Visual Studio.
- Build the solution to restore the NuGet packages.
- Run the API by pressing F5 or clicking the "Run" button in the toolbar.

## Usage
The API provides the following endpoints for scheduling:

##Authentication
`POST /api/auth/register`: Register a new user.<br/>
`POST /api/auth/login`: Login an existing user.<br/>

## Schedules
`GET /api/schedules`: Get all schedules.<br/>
`GET /api/schedules/{id}`: Get a schedule by ID.<br/>
`POST /api/schedules`: Create a new schedule.<br/>
`PUT /api/schedules/{id}`: Update an existing schedule by ID.<br/>
`DELETE /api/schedules/{id}`: Delete a schedule by ID.<br/>

## Security
The API uses JWT (JSON Web Token) authentication to secure the endpoints. JWT is a widely used standard for securing APIs and web applications. The API generates a JWT token upon successful login, which is then used to authenticate subsequent requests.

The API also provides role-based authorization to ensure that only authorized users can access or modify schedules. The API supports two roles:

* Admin: Has full access to all endpoints.
* User: Has access to read and modify their own schedules only.

## Testing
The API includes unit tests to ensure that the functionality of the API works as expected. You can run the unit tests by following these steps:

Open the Test Explorer window in Visual Studio.
Click the "Run All" button to run all tests.

## Deployment
The API can be deployed to various cloud providers such as Azure, AWS, or Google Cloud. The API can also be deployed to a self-hosted server using IIS (Internet Information Services) or Kestrel.

## Contributing
Contributions are welcome! If you find a bug or would like to add a feature, please create a pull request.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
