# Identity-Sample
The project is use identity for authorization
# User Service

The `UserService` class is a part of the BookStore application and provides functionality for managing users. It uses the `UserManager<ApplicationUser>` class from the `Microsoft.AspNetCore.Identity` namespace for user-related operations.

## Dependencies

- `Microsoft.AspNetCore.Identity`: This namespace provides the `UserManager<TUser>` class for managing users.
- `Microsoft.EntityFrameworkCore`: This namespace is used for working with Entity Framework Core and accessing the user database.

## Constructor

The `UserService` class has a constructor that accepts an instance of the `UserManager<ApplicationUser>` class. The `UserManager` is used to perform user-related operations such as creating, retrieving, updating, and deleting users.

```csharp
public UserService(UserManager<ApplicationUser> userManager)
{
    _userManager = userManager;
}
```

## CreateAsync Method

The `CreateAsync` method is used to create a new user. It takes a `CreateUserDto` object as a parameter, which contains the user's information such as username, email, password, etc. The method performs the following steps:

1. Creates a new `ApplicationUser` instance and sets its properties based on the provided `CreateUserDto`.
1. Performs validation checks on the user object and password.
1. Calls `_userManager.CreateAsync` to create the user using the `UserManager`.
1. Calls `_userManager.AddToRoleAsync` to assign the "User" role to the newly created user.
1. Collects any errors that occur during the creation process and converts them into `ValidationError` objects.

## GetAllAsync Method

The `GetAllAsync` method retrieves all users from the database and returns a list of `GetAllUserDto` objects. It performs the following steps:

1. Retrieves a list of `ApplicationUser` objects using `_userManager.Users.ToListAsync`.
1. Checks if there are any users found. If not, adds a `ValidationError` indicating that no registered users exist.
1. Maps the `ApplicationUser` objects to `GetAllUserDto` objects and adds them to the `usersDto` list.
1. Returns a tuple containing the list of user DTOs and any validation errors.

## GetUserById Method

The `GetUserById` method retrieves a specific user by their ID and returns a `GetUserDto` object. It performs the following steps:

1. Validates the provided user ID.
1. Calls `_userManager.FindByIdAsync` to retrieve the user by their ID.
1. Checks if the user is found. If not, adds a `ValidationError` indicating that the user is null.
1. Maps the user properties to a `GetUserDto` object.
1. Returns a tuple containing the user DTO and any validation errors.

## RemoveById Method

The `RemoveById` method removes a user based on their ID. It takes a `RemoveUserDto` object as a parameter, which contains the user ID. The method performs the following steps:

1. Validates the provided `RemoveUserDto` object and user ID.
1. Calls `_userManager.FindByIdAsync` to retrieve the user by their ID.
1. Checks if the user is found. If found, calls `_userManager.DeleteAsync` to delete the user.
1. Collects any errors that occur during the deletion process and converts them into `ValidationError` objects.

## EditById Method

The `EditById` method updates a user's information based on their ID. It takes an `EditUserDto` object as a parameter, which contains the updated user information. The method performs the following steps:

1. Validates the provided `EditUserDto` object and user ID.
1. Calls `_userManager.FindByIdAsync` to retrieve the user by their ID.
1. Checks if the user is found. If found, updates the user properties based on the provided `EditUserDto`.
1. Calls `_userManager.UpdateAsync` to persist the changes to the user.
1. Collects any errors that occur during the update process and converts them into `ValidationError` objects.

______________________________________________________________________

This `UserService` class provides a set of methods for creating, retrieving, updating, and deleting users using the `UserManager` class. It also performs validation checks and converts any errors into `ValidationError` objects for easier handling.
