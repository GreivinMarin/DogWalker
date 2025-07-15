# DogWalker

## About the Application

- Developed using **Visual Studio 2019**
- Built on **.NET Framework 4.8**
- Contains **1 solution** (`DogWalker`) with **4 projects**:
  - `DogWalker.Core`
  - `DogWalker.Infrastructure`
  - `DogWalker.Tests`
  - `DogWalker.UI`

---

## How to Run the Application

1. **Clone the repository** (currently public):  
   https://github.com/GreivinMarin/DogWalker  
2. **Build the solution once only**.  
   > Note: A preloaded SQLite database is included and automatically copied to the `bin` folder during the build process.
3. Navigate to the `bin` folder and **run the generated `.exe` file**.

---

## How to Use the Application

- The application opens with a **main form** that includes a top menu:
  - **Processes**
    - `Walks` → Main process logic
  - **Catalog**
    - `Clients`
    - `Dogs`
    - `Breeds`

- **Walks Form** (Main Logic Form):
  - Contains two tabs: `"Add Walk"` and `"Search Filters"`.
  - By default, the data grid displays records starting from the **first day of the current month**.
  - You can filter results by:
    - Client name
    - Dog name
    - Date range (enabled/disabled manually)
    - Custom date range (note: the database includes data only from **January to June** of this year)
  - To **add a walk**, go to the `"Add Walk"` tab, select a client, a dog, enter the date and duration, then click **Save**.
  - Each record in the grid includes **Edit** and **Delete** buttons for easy modification.

---

## Technical Highlights

- **Portable SQLite database**, ideal for small-scale projects.
- **Relational and normalized data model**:
  - Catalog tables: `Breeds`, `Clients`, and `Dogs`
  - Transactional table: `Walks`
- **Repository Pattern**:
  - Allows decoupling data access from business logic.
  - Facilitates easy database migration with minimal changes.
- **Naming conventions** used for UI controls to improve code readability and event tracking.
- **Unit testing** with xUnit:
  - Includes tests for utility classes and repository logic.
  - The Repository Pattern allows for DB-independent testing.
- **Clean code principles**:
  - Small, focused methods.
  - Minimal logic inside UI event handlers.
- **Asynchronous programming**:
  - Used `async/await` to prevent UI freezing during heavy operations.
  - For older versions of .NET, `BackgroundWorker` can be used as an alternative.
- **Responsive UI**:
  - Utilizes `Anchor` and `Dock` properties for better form resizing behavior.
- **Form behavior**:
  - Catalog forms are **child forms** hosted within the main form.
  - The **Walks form** opens independently, allowing the user to move it to another screen for a more comfortable experience.