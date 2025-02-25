# MinifyURL

![GitHub stars](https://img.shields.io/github/stars/angellisandroerazo/minify-url)
![GitHub Forks](https://img.shields.io/github/forks/angellisandroerazo/minify-url)
![GitHub PRs](https://img.shields.io/github/issues-pr/angellisandroerazo/minify-url)
![GitHub issues](https://img.shields.io/github/issues/angellisandroerazo/minify-url)
![GitHub Contributors](https://img.shields.io/github/contributors/angellisandroerazo/minify-url)

![web](./lib/img/minify-url.png)

Visit the [website](https://github.com/angellisandroerazo/minify-url).


Tool to shorten URLs and generate short links. Allows to create a shortened link making it easy to share.

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