# CookBook Hub API Documentation

## Base URL
```
http://localhost:5000/api
```

## Authentication
Currently no authentication required (planned for future release)

---

## Recipes

### Get All Recipes
```http
GET /api/recipes
```

**Response**: `200 OK`
```json
[
  {
    "id": "guid",
    "title": "Classic Spaghetti Carbonara",
    "description": "Authentic Italian pasta...",
    "prepTimeMinutes": 10,
    "cookTimeMinutes": 20,
    "servings": 4,
    "difficulty": "Easy",
    "categoryName": "Italian",
    "userName": "chef_mario",
    "averageRating": 4.8,
    "reviewCount": 124
  }
]
```

### Get Recipe by ID
```http
GET /api/recipes/{id}
```

### Get Recipes by Category
```http
GET /api/recipes/category/{categoryId}
```

### Get Recipes by User
```http
GET /api/recipes/user/{userId}
```

### Search Recipes
```http
GET /api/recipes/search?q=pasta
```

### Create Recipe
```http
POST /api/recipes
```

**Request Body**:
```json
{
  "title": "My Recipe",
  "description": "Description",
  "instructions": "Step by step...",
  "prepTimeMinutes": 15,
  "cookTimeMinutes": 30,
  "servings": 4,
  "difficulty": 1,
  "imageUrl": "https://...",
  "categoryId": "guid",
  "userId": "guid",
  "ingredients": [
    {
      "name": "Pasta",
      "quantity": 400,
      "unit": "g",
      "notes": "",
      "displayOrder": 1
    }
  ]
}
```

**Response**: `201 Created`

### Update Recipe
```http
PUT /api/recipes/{id}
```

### Delete Recipe
```http
DELETE /api/recipes/{id}
```

---

## Categories

### Get All Categories
```http
GET /api/categories
```

### Get Category by ID
```http
GET /api/categories/{id}
```

### Create Category
```http
POST /api/categories
```

**Request Body**:
```json
{
  "name": "Italian",
  "description": "Classic Italian cuisine",
  "iconUrl": "🍝"
}
```

---

## Users

### Get All Users
```http
GET /api/users
```

### Get User by ID
```http
GET /api/users/{id}
```

### Get User by Username
```http
GET /api/users/username/{username}
```

### Create User
```http
POST /api/users
```

**Request Body**:
```json
{
  "username": "chef_mario",
  "email": "mario@example.com",
  "fullName": "Mario Rossi",
  "bio": "Italian chef",
  "avatarUrl": ""
}
```

---

## Reviews

### Get Reviews by Recipe
```http
GET /api/reviews/recipe/{recipeId}
```

### Create Review
```http
POST /api/reviews
```

**Request Body**:
```json
{
  "recipeId": "guid",
  "userId": "guid",
  "rating": 5,
  "comment": "Delicious!"
}
```

**Validation**:
- Rating: 1-5
- One review per user per recipe

---

## Error Responses

### 400 Bad Request
```json
{
  "errors": {
    "Title": ["Title is required"]
  }
}
```

### 404 Not Found
```json
{
  "message": "Recipe not found"
}
```

### 500 Internal Server Error
```json
{
  "message": "An error occurred"
}
```
