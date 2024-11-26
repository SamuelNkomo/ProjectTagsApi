# **ProjectTagsAPI**

The **ProjectTagsAPI** is a RESTful API that allows users to manage `Projects` and `Tags`. Each tag can optionally be associated with a project, with the `tagName` uniquely identifying a tag.



## **Features**
- Create and read`Projects`.
- Create and read `Tags`.
- Optional association of `Tags` with `Projects`.
- Proper error handling and validation.



## **Deployment**

The API is deployed and publicly accessible at:  
**[https://projecttagsapi-ddh2gpemf3dhe0c4.canadacentral-01.azurewebsites.net/api](https://projecttagsapi-ddh2gpemf3dhe0c4.canadacentral-01.azurewebsites.net/api)**

Use the base URL to access the endpoints (e.g., `https://projecttagsapi-ddh2gpemf3dhe0c4.canadacentral-01.azurewebsites.net/api/projects`).


## **Prerequisites**
Before running the API locally, ensure you have the following installed:
- [.NET 8.0 or later](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/)



## **Setup Instructions**

### **1. Clone the Repository**
```bash
git clone https://github.com/SamuelNkomo/ProjectTagsApi.git
cd ProjectTagsAPI
```

### **2. Configure Database**
Update the `appsettings.json` file with your database connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=ProjectTagsDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### **3. Apply Migrations**
Run the following commands to create the database and tables:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### **4. Run the API**
Start the API using:
```bash
dotnet run
```
The API will be available at `https://localhost:5001/api`.



## **API Endpoints**

### **Projects**

| Method | Endpoint          | Description                     | Request Body                            |
|--------|-------------------|---------------------------------|-----------------------------------------|
| `GET`  | `/projects`        | Get all projects               | N/A                                     |
| `GET`  | `/projects/{name}` | Get a project by name          | N/A                                     |
| `POST` | `/projects`        | Create or update a project     | `{ "projectName": "ProjectA" }`         |

### **Tags**

| Method | Endpoint         | Description                      | Request Body                                    |
|--------|------------------|----------------------------------|------------------------------------------------|
| `GET`  | `/tags`           | Get all tags                    | N/A                                            |
| `GET`  | `/tags/{name}`    | Get a tag by name               | N/A                                            |
| `POST` | `/tags`           | Create or update a tag          | `{ "tagName": "Tag1", "cuttingTime": 12.50 }` |



## **Models**

### **ProjectData**
| Property      | Type   | Description            |
|---------------|--------|------------------------|
| `projectName` | string | Unique name of project |

### **TagData**
| Property      | Type    | Description                     |
|---------------|---------|---------------------------------|
| `tagName`     | string  | Unique name of the tag          |
| `cuttingTime` | decimal | Time spent on the tag (in hours)|



## **Error Handling**
Standardized error responses:
- **400 Bad Request:** Invalid request (e.g., missing fields).
- **404 Not Found:** Resource not found (e.g., invalid `projectName` or `tagName`).
- **500 Internal Server Error:** For unexpected issues.

**Example:**
```json
{
  "error": "Project with name 'ProjectX' not found."
}
```



## **Tech Stack**
- **Framework:** ASP.NET Core
- **Database:** SQL Server with Entity Framework Core
- **Language:** C#
- **Hosting Platform:** Azure App Services



## **Future Enhancements**
- Add authentication for secure access.
- Pagination for `GET` endpoints with large datasets.
- Advanced filtering and sorting for `Tags` and `Projects`.



## **License**
This project is licensed under the MIT License.


## **Contributing**
Contributions are welcome! Please create a pull request or raise an issue for enhancements or bugs.

