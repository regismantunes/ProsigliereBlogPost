# ProsigliereBlogPost
A coding challenge requested by Prosigliere

ProsigliereBlogPost is a RESTful API built with ASP.NET Core and SQLite database. It is a simple blogging platform. The core functionality of this platform includes managing blog posts and their associated comments.

## Table of Contents
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
  - [GET /api/posts](#get-apiposts)
  - [POST /api/posts](#post-apiposts)
  - [GET /api/posts/{id}](#get-apipostsid)
  - [POST /api/posts/{id}/comments](#post-apipostsidcomments)
- [Data Models](#data-models)
  - [BlogPost](#blogpost)
  - [Comment](#comment)
- [Next Steps](#next-steps)

## Getting Started

Follow these instructions to get the API running on your local machine.

### Prerequisites

Ensure you have the following installed:

* [.NET SDK](https://dotnet.microsoft.com/download) (version 9.0)
* [Git](https://git-scm.com/) (for cloning the repository)
* (Optional) A REST client like [Postman](https://www.postman.com/) or [Insomnia](https://insomnia.rest/) to interact with the API.

### Installation

1.  Clone the repository to your local machine:
    ```bash
    git clone <YOUR_GITHUB_REPOSITORY_URL>
    cd <YOUR_REPOSITORY_NAME>
    ```

### Configuration

1.  The application uses SQLite, and the database file is typically created in the project directory (e.g., `blogpost.db`). You might have configuration settings in your `appsettings.json` file.

### Running the Application

1.  Navigate to the project directory in your terminal.
2.  Run the following command to build and run the application:
    ```bash
    dotnet run
    ```
3.  The API will typically start on a default port (usually `http://localhost:5xxx`). Check the console output for the exact URL.

## API Endpoints

Here's a description of the implemented API endpoints:

### `GET /api/posts`

* **Description:** Retrieves a list of all blog posts. Each post includes its title and the number of associated comments.
* **Response Format:**
    ```json
    [
      {
        "id": 1,
        "title": "First Blog Post",
        "commentCount": 2
      },
      {
        "id": 2,
        "title": "Another Interesting Post",
        "commentCount": 0
      }
      // ... more posts
    ]
    ```

### `POST /api/posts`

* **Description:** Creates a new blog post.
* **Request Body (JSON):**
    ```json
    {
      "title": "My New Blog Post",
      "content": "This is the content of my new blog post."
    }
    ```
* **Response (JSON) on Success (e.g., HTTP 201 Created):**
    ```json
    {
      "id": 3,
      "title": "My New Blog Post",
      "content": "This is the content of my new blog post."
    }
    ```

### `GET /api/posts/{id}`

* **Description:** Retrieves a specific blog post by its ID, including its title, content, and a list of associated comments.
* **Path Parameter:**
    * `{id}`: The unique identifier of the blog post.
* **Response Format:**
    ```json
    {
      "id": 1,
      "title": "First Blog Post",
      "content": "This is the content of the first blog post.",
      "comments": [
        {
          "id": 1,
		  "author": "Luke Skywalker",
          "content": "Great post!"
        },
        {
          "id": 2,
		  "author": "Leia Organa",
          "content": "I agree."
        }
        // ... more comments
      ]
    }
    ```
* **Response on Not Found (e.g., HTTP 404 Not Found):**
    ```json
    {
      "error": "Not Found"
    }
    ```

### `POST /api/posts/{id}/comments`

* **Description:** Adds a new comment to a specific blog post.
* **Path Parameter:**
    * `{id}`: The unique identifier of the blog post to add the comment to.
* **Request Body (JSON):**
    ```json
    {
	  "author": "Darth Maul",
      "content": "This is a new comment."
    }
    ```
* **Response (JSON) on Success (e.g., HTTP 201 Created):**
    ```json
    {
      "id": 3,
	  "author": "Darth Maul",
      "content": "This is a new comment."
    }
    ```
* **Response on Post Not Found (e.g., HTTP 404 Not Found):**
    ```json
    {
      "error": "Not Found"
    }
    ```

## Data Models

### BlogPost

* `Id`: (Integer, Primary Key) - Unique identifier for the blog post.
* `Title`: (String) - The title of the blog post.
* `Content`: (String) - The main content of the blog post.
* `CommentsCount` (Integer) - The count of comments for this post.
* `Comments`: (List of Comment objects) - A collection of comments associated with this post.

### Comment

* `Id`: (Integer, Primary Key) - Unique identifier for the comment.
* `Author`: (String) - The name of the comment author.
* `Content`: (String) - The content of the comment.
* `BlogPostId`: (Integer, Foreign Key referencing BlogPost.Id) - The ID of the blog post this comment belongs to.

## Next Steps

Given more time, here are some features and improvements I would implement:

* **User Authentication and Authorization:** Implement user accounts using ASP.NET Core Identity, allowing authenticated users to create, edit, and delete their own blog posts and comments. Introduce roles and policies for different levels of access.
* **Data Validation:** Implement robust data validation using Fluent Validation to ensure data integrity and provide informative error responses.
* **Pagination:** For the `/api/posts` endpoint, implement pagination to handle a large number of blog posts efficiently.
* **Filtering and Sorting:** Allow users to filter blog posts based on criteria (e.g., date, keywords).
* **Unit and Integration Testing:** Write comprehensive unit tests and integration tests to ensure the reliability and correctness of the API.
* **Rate Limiting:** Implement rate limiting middleware to protect the API from abuse.
* **Search Functionality:** Add the ability to search for blog posts using full-text search capabilities if needed.

---

Thank you for reviewing my submission!