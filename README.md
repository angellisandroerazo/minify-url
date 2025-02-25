
# Url Shortening Service

Tool designed to simplify and optimize the way you share links online. It allows you to transform long and complicated URLs into short links, perfect for sharing on social networks, emails or any digital platform.

## Features
- URL shortening service
- URL expansion service

## Getting Started
1. Clone the repository:
   ```bash
   git clone https://github.com/angellisandroerazo/url-shortening-service.git
   ```
2. Navigate to the project directory:
   ```bash
   cd url-shortening-service
   ```

3. Open the project in Visual Studio 2022
   
4. Configure the connection string in the appsettings.json file:
   ```json
    "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=UrlShorteningService;Integrated Security=True;Encrypt=False"
    }
   ```

5. Run the migration script:
   ```bash
   dotnet ef database update
   ```
   
1. Run the application


## Usage

### Create Short URL
Create a new short URL using the methodPOST

```json
POST /shorten
{
  "url": "https://www.example.com/some/long/url"
}
```

Response:

```json
{
  "id": "1",
  "url": "https://www.example.com/some/long/url",
  "shortCode": "abc123",
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:00:00Z"
}
```

### Retrieve Original URL
Retrieve the original URL from a short URL using the methodGET

```json
GET /shorten/abc123
```

Response:
```json
{
  "id": "1",
  "url": "https://www.example.com/some/long/url",
  "shortCode": "abc123",
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:00:00Z"
}
```

### Update Short URL
Update an existing short URL using the methodPUT
```json
PUT /shorten/abc123
{
  "url": "https://www.example.com/some/updated/url"
}
```

Response:
```json
{
  "id": "1",
  "url": "https://www.example.com/some/updated/url",
  "shortCode": "abc123",
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:30:00Z"
}
```

### Delete Short URL
Delete an existing short URL using the methodDELETE
```json
DELETE /shorten/abc123
```

### Get URL Statistics
Get statistics for a short URL using the methodGET
```json	
GET /shorten/abc123/stats
```

Response:
```json
{
  "id": "1",
  "url": "https://www.example.com/some/long/url",
  "shortCode": "abc123",
  "createdAt": "2021-09-01T12:00:00Z",
  "updatedAt": "2021-09-01T12:00:00Z",
  "accessCount": 10
}
```

### Get All Short URLs
Get all short URLs using the methodGET

```json
GET /shorten
```

Response:
```json
[
  {
    "id": "1",
    "url": "https://www.example.com/some/long/url",
    "shortCode": "abc123",
    "createdAt": "2021-09-01T12:00:00Z",
    "updatedAt": "2021-09-01T12:00:00Z"
  },
  {
    "id": "2",
    "url": "https://www.example.com/some/other/long/url",
    "shortCode": "def456",
    "createdAt": "2021-09-01T12:00:00Z",
    "updatedAt": "2021-09-01T12:00:00Z"
  }
  ...
]
```

## Problem Statement

This project addresses a task management problem inspired by the challenges outlined in the [URL Shortening Service](https://roadmap.sh/projects/url-shortening-service).