# Record Idea

**Description:**

The **Record Idea** project was created for people who have many ideas and don’t know where to record them for future reference. The project allows for the creation and categorization of ideas, making it easier to manage and organize your inspirations.

## Technologies and Patterns

The project uses the following technologies and patterns:

- **MongoDB:** NoSQL database used to store categories and ideas.
- **.NET:** Framework used for application development.
- **Swagger:** Tool for API documentation and testing.

**Patterns:**

- **Result Pattern:** Used to return results and error messages consistently.
- **Repository Pattern:** Implemented to encapsulate data access and promote separation of concerns.
- **CQRS (Command Query Responsibility Segregation):** Applied to separate read and write operations, improving scalability and maintainability of the application.

## Installation

To get started with the project, you need to install some dependencies and set up MongoDB:

1. Install the following dependencies:
    - `MongoDB.Driver`
    - `MediatR.Extensions.Microsoft.DependencyInjection`
2. Install and configure MongoDB on your machine.

## Usage

1. **Run the project:** Execute the command `dotnet watch run` to start the server. This will open a Swagger page in your browser.

2. **Register a category:**
    - Access the category registration endpoint on Swagger.
    - In the request body of the POST category registration, the `id` property will be auto-filled if there are no existing records. It is recommended to create the ID via MongoDB.
    - Provide the name and description of the category.

3. **Register an idea:**
    - Access the idea registration endpoint on Swagger.
    - In the request body, the `ID` field functions similarly to the category ID and can be left blank.
    - Fill in the title and description of the idea.
    - Enter the ID of the corresponding category already created. The category name will be registered automatically.
    - The creation date and time will be generated automatically.

## Future Implementations

The following features are planned for future development:

- **User Class Creation:** Implement a user class for managing new user registrations.
- **User Authentication:** Add functionality for user authentication to secure access to the application.
- **Frontend Application:** Develop a frontend for user interaction with the application, enhancing usability and providing a user-friendly interface.

## Contribution

If you want to contribute to the project, follow these steps:

1. Fork the repository.
2. Create a branch for your changes (`git checkout -b my-new-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push the branch to the remote repository (`git push origin my-new-feature`).
5. Open a Pull Request on GitHub.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
