# Parking Lot Management System API

A RESTful Parking Lot Management System built with **ASP.NET Core Web API**, **Entity Framework Core**, **MySQL**, and **JWT Authentication**.

The API manages a multi-floor parking facility where vehicles can enter, receive a parking ticket, occupy a suitable parking spot, and later exit after the parking fee is calculated.

---

# Features

- Park a vehicle
- Automatically assign an available parking spot
- Issue parking tickets
- Exit vehicles
- Calculate parking fee
- View active parked vehicles
- Retrieve ticket details
- JWT Authentication
- Global Exception Handling
- Request Logging
- Entity Framework Core with MySQL
- Clean Layered Architecture

---

# Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- MySQL
- Pomelo EF Core Provider
- JWT Authentication
- LINQ
- Dependency Injection
- Swagger

---

# Project Structure

```
ParkingLotAPI
│
├── Controllers
├── Data
├── DTOs
├── Entities
├── Exceptions
├── Interfaces
├── Mapping
├── Middleware
├── Services
├── Program.cs
└── appsettings.json
```

---

# Architecture

```
Client
   │
   ▼
Controllers
   │
   ▼
Services
   │
   ▼
Entity Framework Core
   │
   ▼
MySQL Database
```

---

# Entity Relationship

```
ParkingLot
    │
    └── Floors
            │
            └── ParkingSpots
                    │
                    └── ParkingTickets
                              │
                              └── Vehicle
```

---

# OOP Concepts Used

## Abstract Classes

### Vehicle

- Car
- Motorcycle
- Truck

### ParkingSpot

- CompactSpot
- LargeSpot
- HandicappedSpot

---

## Inheritance

Vehicle and ParkingSpot use inheritance to model different types.

---

## Polymorphism

Each parking spot determines whether a vehicle can park using:

```csharp
CanFit(Vehicle vehicle)
```

Fee calculation also uses polymorphism through the `IFeeStrategy` interface.

---

## Encapsulation

Parking spots expose methods:

- Occupy()
- Free()

The occupied state cannot be modified directly.

---

## Interface

Fee calculation is implemented using:

```
IFeeStrategy
```

Implementations

- HourlyFeeStrategy
- DailyFeeStrategy
- FlatFeeStrategy

---

# Design Patterns

- Strategy Pattern (Fee Calculation)
- Dependency Injection
- Repository functionality provided by Entity Framework Core

---

# Database

Tables

- ParkingLots
- Floors
- ParkingSpots
- Vehicles
- ParkingTickets

Relationships

- ParkingLot → Floors
- Floor → ParkingSpots
- Vehicle → ParkingTickets
- ParkingSpot → ParkingTickets

---

# API Endpoints

| Method | Endpoint | Description | Authentication |
|---------|----------|-------------|---------------|
| POST | /api/auth/login | Login and get JWT | No |
| POST | /api/parking/park | Park a vehicle | Yes |
| PUT | /api/parking/exit/{ticketId} | Exit vehicle | Yes |
| GET | /api/parking/active | View active vehicles | No |
| GET | /api/parking/ticket/{ticketId} | Get ticket details | No |

---

# Authentication

Protected endpoints require a JWT Bearer Token.

Example

```
Authorization: Bearer YOUR_TOKEN
```

---

# Request Flow

## Park Vehicle

```
Client

↓

ParkingController

↓

ParkingService

↓

Find Available Spot

↓

Create Vehicle

↓

Create Parking Ticket

↓

Save to Database

↓

Return Ticket
```

---

## Exit Vehicle

```
Client

↓

ParkingController

↓

ParkingService

↓

Find Ticket

↓

Calculate Fee

↓

Free Parking Spot

↓

Close Ticket

↓

Save Changes

↓

Return Updated Ticket
```

---

# Error Handling

The project uses:

- Custom Exceptions
- Global Exception Middleware
- ProblemDetails responses

Example

```json
{
  "status":404,
  "title":"TicketNotFoundException",
  "detail":"Ticket not found."
}
```

---

# Logging

Every request logs:

- HTTP Method
- URL
- Status Code
- Execution Time

---

# DTOs

The API never exposes Entity classes directly.

Separate DTOs are used for:

- Requests
- Responses

A static mapper converts Entities into DTOs.

---

# Dependency Injection

Services are registered through ASP.NET Core DI.

Example

```csharp
builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddScoped<IFeeStrategy, HourlyFeeStrategy>();
```

---

# Setup

## Clone

```bash
git clone https://github.com/yourusername/ParkingLotAPI.git
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Update Database

```bash
dotnet ef database update
```

---

## Run

```bash
dotnet run
```

Swagger

```
https://localhost:5001/swagger
```

---

# Future Improvements

- Vehicle Factory Pattern
- Reservation System
- Multiple Parking Lots
- Admin Dashboard
- Role-Based Authorization
- Payment Gateway Integration
- Parking History
- Unit Tests
- Docker Support

---

# Learning Outcomes

This project demonstrates:

- Object-Oriented Programming
- SOLID Principles
- ASP.NET Core Web API
- Entity Framework Core
- MySQL Integration
- JWT Authentication
- Middleware
- Exception Handling
- LINQ
- Async Programming
- DTO Pattern
- Dependency Injection
- Layered Architecture
