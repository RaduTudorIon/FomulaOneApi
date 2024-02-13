# Formula One API

This is an API for managing Formula One drivers and their achievements.

## Project Structure

The project is divided into two main parts:

1. `DataService`: This part of the project is responsible for data handling and database interactions. It includes the `AppDbContext` class for defining the database context and the `GenericRepository` for generic database operations.

2. `FormulaOneApi`: This part of the project is responsible for handling API requests and responses. It includes mapping profiles for converting domain models to response models and vice versa.

## Key Files

- `AppDbContext.cs`: This file defines the database context and the relationships between entities.
- `GenericRepository.cs`: This file provides a generic repository for performing database operations.
- `UnitOfWork.cs`: This file manages the coordination of work across multiple repositories by creating a single database context.
- `DomainToResponse.cs` and `RequestToDomain.cs`: These files define the mapping profiles for converting domain models to response models and vice versa.

## Installation

dotnet build
dotnet run
For checking the database you can use dbeaver and connect to the app.db
