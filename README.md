# Acekreme_v1

AceKreme_v1 is a full-stack ASP.NET Core MVC built to manage customer orders and products for a retail business.
It includes full CRUD functionality, authentication with ASP.NET Identity, and integrated PayPal checkout for secure online payments.
________________________________________
Project Overview
AceKreme_v1 is designed as a business management system where administrators can manage:
Customers — track and manage customer profiles
Products — add, edit, or remove products from inventory
 Orders — process, update, and track orders
Customer Orders — view and manage the many-to-many relationship between customers and orders
Payments — handle online transactions via PayPal Gateway
________________________________________
Core Architecture
Layer	Description
Controllers	Handles HTTP requests for Customers, Products, Orders, and Checkout
Models	Defines data entities and relationships (Customer, Product, Order, CustomerOrder)
ViewModels / DTOs	Used for page rendering and API data transfer
Services & Interfaces	Contains business logic and repository-style service abstraction
Data Layer	ApplicationDbContext configured with Identity 
Views	Razor pages for CRUD operations and PayPal checkout
________________________________________ Key Features
 Full CRUD for Customers, Products, and Orders
 ASP.NET Identity for login/register/logout
 Integrated PayPal payment processing
 REST-style WebAPI endpoints with Swagger documentation
 Auto-migration and SQL Server persistence
________________________________________
 Tech Stack
Backend: ASP.NET 
Frontend: Razor Pages
Database: SQL Server 
Authentication: ASP.NET Identity
API Docs: Swagger / OpenAPI
Payment Gateway: PayPal Checkout SDK

AceKreme_v1/

├── Controllers/
── HomeController.cs
── ProductController.cs
── CustomerController.cs
── OrderController.cs
── CustomerOrderController.cs
── CheckoutController.cs
│
├── Models/
── Customer.cs
── Product.cs
── Order.cs
── CustomerOrder.cs
│   └── PayPalSettings.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Services/
── Interfaces/
── ICustomerService.cs
── IProductService.cs
── IOrderService.cs
              └── ICustomerOrderService.cs
│   └── Implementations/
── CustomerService.cs
── ProductService.cs
── OrderService.cs
── CustomerOrderService.cs
│
├── Views/
── Home/
── CustomerPage/
── ProductPage/
── OrderPage/
── Shared/
── Checkout/
│
       ── appsettings.json
       ── Program.cs
└── README.md
