# Dentistry Web Application

Dentistry is a comprehensive web application designed to streamline dental practice management and enhance patient care. The application follows a vertical slice architectural pattern, which promotes modularity and separation of concerns. It allows for independent development and deployment of individual features or slices of functionality.

![Dentistry Architecture](<>)

## Architecture Overview

The Dentistry web application is built using a combination of server-side technologies. The server-side is developed using the .NET 7 framework.

The application follows the vertical slice architecture, which organizes code by features rather than layers. Each vertical slice represents a self-contained module that incorporates all the necessary components (backend and database) to implement a specific feature or functionality.

### Backend

The backend of Dentistry consists of the following components:

- **API Layer**: This layer provides a RESTful API for client applications to interact with the server. It handles incoming requests, performs authentication and authorization, and delegates business logic to the appropriate vertical slice.
- **Vertical Slices**: Each vertical slice represents a specific feature or functionality of the application, such as appointments, patient records, treatment plans, and billing. Each slice contains its own set of controllers, services, and data access components.
- **Data Access Layer**: This layer is responsible for interacting with the database and performing CRUD operations. It utilizes an ORM (Object-Relational Mapping) framework, such as Entity Framework Core, to simplify database access and management.

## Deployment

Dentistry can be deployed using Docker, which allows for containerized deployment and easy management of the application. The deployment process involves creating a Docker image of the application and running containers based on that image.

To deploy Dentistry using Docker, follow these steps:

1. Install Docker on your deployment server.
1. Build the Docker image by running the following command in the project's root directory:
   ````
   docker build -t dentistry .
   ```
   This command builds the Docker image using the provided Dockerfile in the project.
   ````
1. Run a Docker container based on the built image:
   ```
   docker run -d -p 8080:80 dentistry-app
   ```
   This command starts a Docker container based on the image and maps port 8080 on the host to port 80 inside the container.
1. Access Dentistry by navigating to `http://localhost:8080` in your web browser.

Note: Make sure to configure the necessary environment variables and connection strings for the application to connect to the database and other required services.

## Contributing

Contributions to Dentistry are welcome! If you have any suggestions, bug reports, or feature requests, please feel free to open an issue or submit a pull request on the project's GitHub repository.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
