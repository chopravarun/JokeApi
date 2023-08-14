# JokeApi

## Run Application 
```http
1. Clone the application
2. navigate inside JokeApi project from terminal 
3. run "dotnet run --project JokeApi-Rest"
```

## API Reference

#### Random joke

```http
GET /Joke
```

#### Search Joke without pagination

```http
GET /Joke/s/{term}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `term`      | `string` | **Required** text which should be present in joke |

#### Search Joke with offset and page size

```http
GET /Joke/s/{term}/p/{page}/l/{limit}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `term`      | `string` | **Required** text which should be present in joke |
| `page`      | `int` | page number which needs to be fetched |
| `limit`      | `int` | number of jokes needs to be fetched in one page |

#### Swagger Url
```http
http://localhost:5243/swagger/index.html
```

