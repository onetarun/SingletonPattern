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

#What is Singleton Design pattern<br/>
The Singleton Design Pattern is a creational pattern in software design that ensures a class has only one instance and provides a global access point to it. This is useful when exactly one object is needed to coordinate actions across a system, such as database connections, logging, configuration settings, etc.

#Key Features of the Singleton Pattern <br/>
 --Single Instance: Ensures only one instance of the class exists.<br/>
 --Global Access Point: The instance is accessible from anywhere in the application.<br/>
 --Lazy Initialization (Optional): The instance is created only when it is needed.<br/>
 --Thread Safety (Optional): Ensures safe usage in multi-threaded environments.<br/>
