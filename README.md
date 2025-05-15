## VerticalSliceTemplate

**A clean and modular ASP.NET Core Razor Pages template implementing Vertical Slice Architecture.**

This template provides a structured starting point for building Razor Pages applications using the Vertical Slice Architecture pattern. Each feature is self-contained, promoting separation of concerns and enhancing maintainability.

---

## What is Vertical Slice Architecture?

Vertical Slice Architecture organizes code by features rather than technical layers. Each "slice" encapsulates all aspects of a specific feature, including the UI, business logic, and data access. This approach contrasts with traditional architectures that segregate an application into horizontal layers.

**Key Benefits:**

* **Feature-Centric Organization:** Code is grouped by feature, making it easier to navigate and modify.
* **Enhanced Maintainability:** Changes in one feature are less likely to impact others.
* **Improved Testability:** Each slice can be tested in isolation.
* **Simplified Onboarding:** New developers can focus on one feature at a time.

For more insights, refer to [Jimmy Bogard's article on Vertical Slice Architecture](https://www.jimmybogard.com/vertical-slice-architecture/).

---

## Project Structure

In other Vertical Slice Architecture templates, each feature is placed into a `Features/` folder. In Razor Pages, however, this causes a routing issue because of Razor Pages' routing conventions. In order to fix this issue, I decided to have each feature folder put in the `Pages/` folder to avoid weird workarounds.

```
VerticalSliceTemplate/
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   └── Product.cs
├── Pages/
│   ├── Home/
│   │   └── Index.cshtml
|   │       └── Index.cshtml.cs
│   ├── Products/
│   │   ├── Create.cshtml
│   │   │   └── Create.cshtml.cs
│   │   ├── CreateProduct.cs
│   │   ├── CreateProductHandler.cs
│   │   ├── Edit.cshtml
│   │   │   └── Edit.cshtml.cs
│   │   ├── EditProduct.cs
│   │   ├── EditProductHandler.cs
│   │   ├── Delete.cshtml
│   │   │   └── Delete.cshtml.cs
│   │   ├── DeleteProduct.cs
│   │   ├── DeleteProductHandler.cs
│   │   └── Index.cshtml
│   |       └── Index.cshtml.cs
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   ├── css/
│   └── js/
├── appsettings.json
└── Program.cs
```

* **Data/**: Houses application data contexts.
* **Models/**: Contains application business logic.
* **Pages/**: Each folder within this directory represents a feature except the `Shared/` Folder.
* **Pages/Shared/**: Contains shared layout and partial views.
* **wwwroot/**: Static files like CSS and JavaScript.
* **Program.cs**: Application entry point and configuration.

---
## Notes

### Database
This template uses an in-memory database to make things simple. Setting up a SQL Server or SQLite database is beyond the scope of this template. If you want to use these or any other EF Core-supported database, please consult the [EF Core Documentation](https://learn.microsoft.com/en-us/ef/) or [ChatGPT](https://chatgpt.com)

---

## Getting Started

### Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

### Running the Application

1. **Create the repository:**

   * Click the `Use this template/Create a new repository` button at the top of the page.
   * Fill out the necessary information and click `Create repository`.
   * Clone your new repository:
   
   ```bash
   git clone https://github.com/[YourUserName]/[YourRepoName].git
   cd VerticalSliceTemplate
   ```

2. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

3. **Run the application:**

   ```bash
   dotnet run
   ```
   You'll need to open your web browser and navigate to `https://localhost:[portnumber]` (Port Number can be found in `launchsettings.json`.

   _or_

   Open the .sln file with Visual Studio and click `Run` or hit `F5`.
   The application will automatically open in your web browser.

---

## Adapting the Template

* Use the existing `Product/` feature folder as a guide to develop your features and delete it when you're done.
* Define your business logic and entities in `Models/`.
* See the README.md in the `Pages/` directory for further guidance on implementing features.

---

## Additional Resources

* [Vertical Slice Architecture by Jimmy Bogard](https://www.jimmybogard.com/vertical-slice-architecture/)
* [Contoso University Sample Application](https://github.com/jbogard/ContosoUniversityDotNetCore-Pages)
* [Vertical Slice Architecture in ASP.NET Core - Code Maze](https://code-maze.com/vertical-slice-architecture-aspnet-core/)
* [Exploring an Example Vertical Slice Architecture in ASP.NET Core](https://www.codeproject.com/Articles/5373971/Exploring-an-Example-Vertical-Slice-Architecture-i)
