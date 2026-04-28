## **OfficeFlow** – Enterprise-Grade Coworking Management System
OfficeFlow is a robust backend API designed to manage coworking spaces, desk reservations, and office analytics. It is a high-performance system built with **.NET 9/10** and **PostgreSQL**, focusing on scalability and data integrity.

### Aim 
This project was developed as a hands-on consolidation of knowledge from the Microsoft Backend Development Course. The goal was to move beyond basic CRUD operations and implement "Separation of Concerns" using **Clean Architecture**, while tackling complex backend challenges like concurrency and database optimization.

### Key features
* **Advanced Reservation Engine:** Handles desk bookings with built-in conflict resolution.
* **Database-Level Analytics:** Uses PostgreSQL **Views** for real-time occupancy and history tracking.
* **Data Lifecycle Management:** Automated archiving of old records via **Stored Procedures**.
* **Robust Security:** Integrated custom middleware for global exception handling and consistent API responses.
* **Flexible Schema:** Utilizes `jsonb` for dynamic data like office opening hours.

### Challenges
* **Race Conditions:** Handling simultaneous booking attempts for the same desk.
    * **Solution:** Implemented **Optimistic Concurrency** and **Manual Transactions** with a **Serializable Isolation Level** to ensure the "check-then-insert" logic is strictly atomic.
* **Complex Query Performance:** Calculating real-time occupancy across multiple tables was resource-intensive.
    * **Solution:** Offloaded logic to the database by creating optimized **SQL Views** (`v_OfficeOccupancy`), reducing the overhead on the .NET application.

### Setup or usage instructions
1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/Szafter12/OfficeFlow.git](https://github.com/Szafter12/OfficeFlow.git)
    ```
2.  **Database Setup:**
    * Ensure PostgreSQL is installed and running.
    * Update the connection string in `appsettings.json`.
3.  **Run Migrations:**
    ```bash
    dotnet ef database update
    ```
4.  **Launch the API:**
    ```bash
    dotnet run
    ```
    
### Technical concepts
* **Clean Architecture:** Clear separation between Controllers, Services, and Domain Models.
* **Entity Framework Core:** Advanced Fluent API configurations and Migrations.
* **PostgreSQL Optimization:** Advanced use of Views, Stored Procedures (PL/pgSQL), and JSONB.
* **Dependency Injection:** Promoting testability and loosely coupled components.
* **Async/Await:** Non-blocking asynchronous patterns throughout the entire stack.

### Images/Video demos
![Database Diagram](DB_diagram.png)
