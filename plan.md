Certainly! Here's the updated Markdown file incorporating the use of the TMDB API key and ensuring proper attribution:

### Plan Overview

1. **Setup Development Environment**
2. **Database Setup: SQLite**
3. **Movie Class and Repository**
4. **IMDB Query Implementation Using TMDB API Key**
5. **REST API with Web Service**
6. **Web Application for Interaction**
7. **Testing with NUnit and Swagger**

---

## Step-by-Step Plan

#### 1. Setup Development Environment

- **Install .NET SDK**: Ensure you have the latest version of .NET SDK installed on your machine.
- **Set Up IDE**: Use Visual Studio Code or any other C# development environment of your choice.

---

## 2. Database Setup: SQLite

- **Add SQLite Dependency**: In your `project.json` (or `.csproj`) file, add the following dependency:
  ```json
  "dependencies": {
    "Microsoft.EntityFrameworkCore.Sqlite": "6.0.1",
    "Microsoft.EntityFrameworkCore.Design": "6.0.1"
  }
  ```
- **Create DbContext and Model**: Define a `MovieContext` class that inherits from `DbContext` and create a `Movie` entity with properties for title, genre, release date, IMDb link, and TMDB movie ID.
- **Migrate Database**: Run the following commands to generate migrations and update the database:
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```

---

## 3. Movie Class and Repository

- **Movie Class**: Create a `Movie` class with properties for title, genre, release date, IMDb link, and TMDB movie ID.
- **Repository Interface**: Define an interface for the repository (`IMovieRepository`) with methods to add, get, and query movies.
- **Repository Implementation**: Implement the repository using SQLite. Use Entity Framework Core's LINQ queries or raw SQL queries as needed.

---

## 4. IMDB Query Implementation Using TMDB API Key

- **Sign Up for TMDB API Key**: Obtain a TMDB API key from [https://developers.themoviedb.org/docs/getting-started](https://developers.themoviedb.org/docs/getting-started).
- **Use TMDB API to Fetch Data**: Use the TMDB API to fetch movie details based on the IMDb link. Ensure you handle potential errors and edge cases.
- **Store Data**: Store the fetched data in the database, including the TMDB movie ID.

---

## 5. REST API with Web Service

- **Set Up ASP.NET Core**: Create a new ASP.NET Core project and set up a web service.
- **Define Controllers**: Define controllers for handling HTTP requests, such as `MoviesController` to handle GET and POST requests for movie queries.
- **Implement Endpoint Logic**: Implement the logic to query IMDb using the TMDB API and store the results in the database using your repository.

---

## 6. Web Application for Interaction

- **Create a Frontend Interface**: Develop a simple web application interface to interact with the REST API. You can use frameworks like ASP.NET Core MVC or Blazor.
- **Integrate API Calls**: Use JavaScript or C# to make HTTP requests to the REST API and display results.

---

## 7. Testing with NUnit and Swagger

- **Set Up NUnit Test Project**: Create a new NUnit test project in your solution.
- **Define Tests in `MediaCatalog.Tests.cs`**:
  ```csharp
  using MediaCatalog.Data;
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class MovieRepositoryTests
  {
      private readonly MovieContext _context;

      [SetUp]
      public void Setup()
      {
          var options = new DbContextOptionsBuilder<MovieContext>()
              .UseSqlite(":memory:") // Use in-memory database for testing
              .Options;
          _context = new MovieContext(options);
          _context.Database.EnsureCreated();
      }

      [TearDown]
      public void TearDown()
      {
          _context.Database.EnsureDeleted();
      }

      [Test]
      public async Task AddMovieAsync_ShouldStoreInDatabase()
      {
          var movieToAdd = new Movie
          {
              Title = "The Matrix",
              Genre = "Science Fiction",
              ReleaseDate = new DateTime(1999, 3, 1),
              ImdbLink = "https://www.imdb.com/title/tt0133005/",
              TmdbMovieId = "tt0133005" // Add TMDB movie ID
          };

          await _context.Movies.AddAsync(movieToAdd);
          await _context.SaveChangesAsync();

          var result = await _context.Movies.FindAsync(movieToAdd.Title);
          Assert.NotNull(result);
      }
  }
  ```

---

### Testing Solution Using NUnit

1. **Create Test Project**:
   - Right-click on your solution, select "Add" > "New Project", choose "NUnit Test Project".
   - Name it `MediaCatalog.Tests`.

2. **Define Tests in `MediaCatalog.Tests.cs`**:
   ```csharp
   using MediaCatalog.Data;
   using NUnit.Framework;
   using System;

   [TestFixture]
   public class MovieRepositoryTests
   {
       private readonly MovieContext _context;

       [SetUp]
       public void Setup()
       {
           var options = new DbContextOptionsBuilder<MovieContext>()
               .UseSqlite(":memory:") // Use in-memory database for testing
               .Options;
           _context = new MovieContext(options);
           _context.Database.EnsureCreated();
       }

       [TearDown]
       public void TearDown()
       {
           _context.Database.EnsureDeleted();
       }

       [Test]
       public async Task AddMovieAsync_ShouldStoreInDatabase()
       {
           var movieToAdd = new Movie
           {
               Title = "The Matrix",
               Genre = "Science Fiction",
               ReleaseDate = new DateTime(1999, 3, 1),
               ImdbLink = "https://www.imdb.com/title/tt0133005/",
               TmdbMovieId = "tt0133005" // Add TMDB movie ID
           };

           await _context.Movies.AddAsync(movieToAdd);
           await _context.SaveChangesAsync();

           var result = await _context.Movies.FindAsync(movieToAdd.Title);
           Assert.NotNull(result);
       }
   }
   ```

---

### Expected Progress

- **After Step 1**: You should have a basic development environment set up with Visual Studio Code and the necessary dependencies.
- **After Step 2**: Your SQLite database should be created, and you can query it using Entity Framework Core.
- **After Step 3**: The `Movie` class and repository should be implemented to handle movie data storage.
- **After Step 4**: You should have a working IMDB query implementation using the TMDB API and store the results in the database.
- **After Step 5**: Your REST API should be functional, with endpoints for querying movies.
- **After Step 6**: You can create a simple web application interface that interacts with the REST API.
- **After Step 7**: You should have NUnit tests and Swagger documentation set up to test your application.

### Additional Notes

- **TMDB API Key**: Ensure you handle the TMDB API key securely. If using environment variables or configuration files, ensure they are not exposed in source control.
- **Attribution**: When developing and distributing your MediaCatalog application online, make sure to include proper attribution for any third-party APIs used, such as the TMDB API.

By following this plan, you can develop your MediaCatalog application incrementally while ensuring proper attribution for using the TMDB API.