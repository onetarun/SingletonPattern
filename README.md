This repository is designed using a layered architecture. It consists of the Domain, Infrastructure, API, and App layers.
<img src="https://www.c-sharpcorner.com/article/three-tier-architecture-in-asp-net-core-6-web-api/Images/Three%20Tier%20Architecture%20in%20Aspnet%20Core%206%20Web%20API.png" />

The Domain layer represents entities and use cases.
The Infrastructure layer represents the implementation and serves as the data access layer for this project.
The API layer contains the API endpoints.
Key Features of This Project:
The database is set up using the Singleton Pattern.
A SqlHelper class has been designed.
The Repository Pattern has been implemented.
A Utility Service has been designed to save images.
Authorization is set up based on Client ID and Client Secret.
API endpoints are written using Controllers.
The App layer makes use of Multipart data.
DataTables are used for data representation.
