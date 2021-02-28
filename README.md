# Movie Store
This project is a .Net Core Web application where the user can login and register into an Application, view and manage movies from the database, retrieve data from the API. 
- Asp.Net Core MVC was used.
- Asp.Net Core Web Api was used.
- Development was made according to OOP and SOLID principles.
- Entity Framework was used for object-relational mapping.
- Language Integrated Query (LINQ) was used while querying the database.
- Dependency Injection was used.
- N-Tier architecture was used
- Generic Repository Pattern is used as a design pattern.
- UnitOfWork was used for CRUD operations in repository pattern.
- Asp.Net.Core Identity Library is used for User operations.
## Installation Prerequisites
  - Microsoft Visual Studio
  - .NET 5.0
  - Microsoft SQL Server Management Studio
## Installation
  - Download from Github and open with Visual Studio
  - Open Package Manager Console in Visual Studio
  - Type the following command: update-database 
- Run
  
## Architecture of the Project
N-Tier Architecture was used. There are 4 layers in the project.
- MovieStore.Business Layer (Business Logic)
Business layer acts as an interface between the presentation layer and the data-access layer. All business logic like calculations, Crud operations that call repositories are written under the services classes in the business logic layer. It has to refer data layer and common layer. 
- MovieStore.Core (Infrastructure) 
This is the infrastructure of our projects therefore, data transfer objects that carry data between the layers and interfaces of classes for using dependency injection are defined. Because it is not a correct approach to send the data read from the database directly to the business and use methods of the class in other classes using without dependency injection.
- MovieStore.Data Layer (Data Access)
This layer provides simplified access to our database therefore, database-related classes are defined here. DbContext, Repositories, Mappings, Seeds, UnitOfWork files were used for database-related logic. It has to refer common layer.
- MovieStore.Web Layer (Presentation)
This is the presentation layer where the classic MVC pattern is located. Controllers receive data from services in the business Layer and send the incoming data to the views with Data Transfer Objects. So it has to refer business and common layers.

## Data Flow
- Presentation (MovieStore.Web) -> Business (MovieStore.Business) -> Data Access (MovieStore.Data) --> Database
- Presentation (MovieStore.Web) <- Business (MovieStore.Business) <- Data Access (MovieStore.Data) <-- Database

- Controllers (Presentation Layer) ->  Services (Business Logic Layer) -> Repositories (Data Access Layer) -> Database Context (Database)
- Controllers (Presentation Layer) <-  Services (Business Logic Layer) <- Repositories (Data Access Layer) <- Database Context (Database)

## Database Design
Entity Framework Core was used to create the database. 
Entities were defined in classes within the MovieStore.Core.Models folder in the Core layer.
Entity Mappings were defined in classes within the MovieStore.Data.Mapping folde in the Data layer.
Their configuration were defined MovieStore.Data.DataAccess folder in the MovieStoreDbContext file.
### Entities
- Movie
- Genre
- MovieGenre (Association Table)
- User

### Entity Relationships
- User 1-n Movie
- User 1-n Genre
- Movie 1-n MovieGenre (to provide Movie n-n Genre)
- Genre 1-n MovieGenre (to provide Genre n-n Movie)
### Database Diagram
![alt text](https://i.imgur.com/5z1N9ph.png)
## Generic Repository Pattern
Generic Repository pattern was used for preventing repetition when defining Crud methods in repositories. We don't need to define the same methods for our all classes.
- Repository-> MovieStore.Data.Repositories
- IRepositoy-> MovieStore.Core.Repositories
### Unit of Work in the Repository Pattern
Unit of Work was provided a single transaction that involves multiple operations of insert/update/delete in the database. For example, if you need to add two data to the database at once, it will add them at the same time rather than sequentially.
- UnitOfWork->MovieStore.Data.UnitOfWork
- IUnitOfWork->Moviestore.Core.UnitOfWork

## Controllers
### Account Controller
AspNetCore.Identity was integrated for account actions like login and register.
- Account/Login-> Login 
- Account/Register-> Register
- Account/Logout-> Logout
### Api Controller
It was created to search and insert movies from http://omdbapi.com with RestSharp Api. 
- Api/SearchMovie-> to search movies from the Api
- Api/AddMovieFromApi-> to insert movies from the Api.
### Movie Controller
It was created to insert, update, delete and list movies.
- Movie/NewMovie-> to create a new movie
- Movie/UpdateMovie-> to update a movie
- Movie/DeleteMovie-> to delete a movie
- Movie/MovieList-> to list all movies from the database
### Genre Controller
It was created to insert, update, delete and list genres.
- Genre/NewGenre-> to create a new genre
- Genre/UpdateGenre-> to update a genre
- Genre/DeleteGenre-> to delete a genre
- Genre/GenreList-> to list all genres from the database
## Services
Are located in MovieStore.Business.Services
### ApiService
- MovieSearch> to search movies from the Api
- AddMovieFromApi-> to insert Movies from the Api into the Database
- AddMovieGenreFromApi-> to insert MovieGenres from the Api into the Database
### MovieService
- AddMovie-> to insert Movies into the Database
- AddMovieGenre-> to insert MovieGenres into the Database
- UpdateMovie-> to update Movies into the Database
- UpdateMovieGenre-> to insert MovieGenres into the Database
- DeleteMovie-> to delete Movies
- GetMovie-> to get a Movie from the Database by Id
- GetMovieWithGenres-> to get a Movie with its Genres from the Database by Id
- GetAllMovies-> to get all Movies from the Database
- GetAllMoviesWithGenres-> to get all Movies with their Genres from the Database
- GetMovieGenreByMovieId-> to get a MovieGenre from the Database by MovieId
### GenreService
- AddGenre-> to insert Genres into the Database
- UpdateGenre-> to update Genres into the Database
- DeleteGenre-> to delete Movies
- GetGenre-> to get a Genre from the Database by Id
- GetGenreByGenreName-> to get a Genre from the Database by GenreName 
- GetAllGenres-> to get all Genres from the Database
- GetGenreList-> to get all Genres from the Database with SelectListItem format
- GetMovieGenreByGenreId-> to get a MovieGenre from the Database by GenreId
### GenreService
- GetUser-> to get Current User 
