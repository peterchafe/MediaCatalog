# MediaCatalog

MediaCatalog is a personal web application designed to store and query movie information from IMDb using the TMDB API. The app aims to provide a simple interface for managing your movie collection and provides a RESTful API for interaction.

## Purpose

The purpose of MediaCatalog is to:

1. **Store Movie Information**: Collect and store movie details including title, genre, release date, IMDb link, and TMDB movie ID.
2. **Query IMDb Data**: Use the TMDB API to fetch detailed information about movies based on the IMDb link.
3. **RESTful API**: Provide a REST API for interacting with the database using HTTP requests (GET, POST).
4. **User Interface**: Develop a simple web application interface to interact with the REST API.

## Table of Contents

- [Setup](#setup)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
  - [Querying Movies](#querying-movies)
  - [Adding Movies](#adding-movies)
- [Testing](#testing)
  - [Running Tests](#running-tests)
- [Contributing](#contributing)
- [License](#license)

## Setup

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio Code or any other C# development environment
- A TMDB API key (sign up at [https://developers.themoviedb.org/docs/getting-started](https://developers.themoviedb.org/docs/getting-started))

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/MediaCatalog.git
   cd MediaCatalog
   ```

2. **Install Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Create Configuration File**:
   - Create a new file named `appsettings.json` in the root directory of the project.
   - Add your TMDB API key to the configuration file:
     ```json
     {
       "TMDBApiKey": "your_tmdb_api_key_here"
     }
     ```

## Usage

### Querying Movies

To query movies, you can use the following endpoint:

```
GET /api/movies?imdbLink=<IMDbLink>
```

Replace `<IMDbLink>` with the IMDb link of the movie you want to query. For example:
```
GET /api/movies?imdbLink=https://www.imdb.com/title/tt0133005/
```

### Adding Movies

To add a new movie, send a POST request to the following endpoint:

```
POST /api/movies
```

In the request body, include the following JSON:
```json
{
  "title": "The Matrix",
  "genre": "Science Fiction",
  "releaseDate": "1999-03-1",
  "imdbLink": "https://www.imdb.com/title/tt0133005/"
}
```

## Testing

### Running Tests

To run the tests, use the following command:

```bash
dotnet test
```

This will execute all the tests defined in the `MediaCatalog.Tests` project using NUnit.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes and push to your branch.
4. Submit a pull request with a clear description of your changes.

## License

MediaCatalog is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
