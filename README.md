
# Customer Management API

This is a simple RESTful API built with **.NET 8** that allows you to manage customer records. The API supports adding new customers and retrieving all customers. Data is stored in a text file (`customers.txt`) using JSON format.

## Getting Started

These instructions will help you set up and run the API on your local machine for development and testing purposes.

### Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio (2022 or later) or Visual Studio Code
- Postman (optional, for testing) or Swagger (automatically included)

### Installing

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/customer-api.git
   cd customer-api
   ```

2. **Open the project** in **Visual Studio** or **Visual Studio Code**.

3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

4. **Build the project**:
   ```bash
   dotnet build
   ```

5. **Run the project**:
   ```bash
   dotnet run
   ```

6. **Access Swagger**:
   Once the project is running, open **Swagger UI** in your browser to test the API:
   ```
   https://localhost:5001/swagger/index.html
   ```

## API Endpoints

### POST /api/customer

- **Description**: Adds a new customer to the list.
- **Request Body** (JSON example):
   ```json
   {
     "firstName": "John",
     "lastName": "Doe",
     "email": "john.doe@example.com",
     "phoneNumber": "123-456-7890"
   }
   ```
- **Response**:
   - `200 OK`: Customer added successfully.
   - `400 Bad Request`: Invalid input (e.g., missing required fields or invalid email).

### GET /api/customer

- **Description**: Retrieves a list of all customers.
- **Response Example**:
   ```json
   [
     {
       "firstName": "John",
       "lastName": "Doe",
       "email": "john.doe@example.com",
       "phoneNumber": "123-456-7890"
     },
     {
       "firstName": "Jane",
       "lastName": "Smith",
       "email": "jane.smith@example.com",
       "phoneNumber": "987-654-3210"
     }
   ]
   ```
- **Response Codes**:
   - `200 OK`: Returns the list of customers.

## Data Storage

The API stores customer data in a text file named `customers.txt`. This file is located in the root directory of the project. All customer data is saved in JSON format.

### Example content of `customers.txt`:
```json
[
  {
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "phoneNumber": "123-456-7890"
  },
  {
    "firstName": "Jane",
    "lastName": "Smith",
    "email": "jane.smith@example.com",
    "phoneNumber": "987-654-3210"
  }
]
```

## Validation and Error Handling

The API includes basic validation and error handling to ensure proper data input and prevent issues with file storage.

### Validation:
- **Email**: The email field is required and must be in a valid format.
- **Required Fields**: `firstName`, `lastName`, and `phoneNumber` are required fields.

### Error Handling:
- The API uses `try-catch` blocks to handle file input/output errors, ensuring the system returns appropriate error messages if something goes wrong.

## Known Issues / Limitations

- **Concurrency**: The current implementation does not handle concurrency issues that may arise from multiple requests to the file at the same time.
- **Scalability**: The API stores customer data in a text file, which may not be efficient for large datasets. A database solution would be more scalable.
- **No Authentication**: This API is currently unsecured and does not require authentication.

## Future Improvements

- **Database Integration**: Replace the text file storage with a database like SQL Server or SQLite to handle larger datasets more efficiently.
- **Unit Tests**: Implement unit tests to ensure each part of the system works correctly.
- **Pagination**: Add pagination for the `GET /api/customer` endpoint to handle large datasets more efficiently.
