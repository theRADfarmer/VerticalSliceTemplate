## Implementing a Feature in the Pages/ Folder

To implement a new feature, create a dedicated folder under `Pages/` (e.g., `Pages/Orders`). Inside this folder, follow these conventions:

- **UI Layer:** Add Razor Page files (e.g., `Create.cshtml`, `Edit.cshtml`, `Index.cshtml`) to define the user interface for each operation.
- **Handler Class:** Add a handler class for each page (e.g., `CreateOrderHandler.cs`). This class processes HTTP requests, handles form submissions, and manages page logic.
- **Model Class:** Add a model class (e.g., `CreateOrder.cs`) to represent the data structure for the feature, including properties and validation attributes.

This approach keeps all code related to a specific feature together, making it easier to maintain and extend. Each feature folder is self-contained, with its UI, logic, and data model clearly separated but closely related.

**How it works:**
1. The Razor Page binds user input to the model class.
2. The PageModel sends the model as a request to MediatR.
3. The handler class processes the request, performs any necessary actions (such as saving to the database), and returns a result.

This structure keeps all code related to a specific feature together, making it easy to understand, maintain, and extend. Refer to the `Pages/Products/` folder for a practical example.