# Mobile Store Management System (نظام إدارة متجر هواتف)

A desktop management application built with **C# (.NET Windows Forms)** to streamline and manage retail operations for mobile phone shops, including inventory, customer records, and authentication.

---

## Features

* **User Authentication (`login`):** Secure login interface for staff access control.
* **Dashboard / Main Hub (`Home`):** Centralized navigation linking all store operations.
* **Device Management (`Mobilephone`):** Add, update, catalog, and track mobile stock and specifications.
* **Customer Management (`Customer`):** Maintain client details, purchase history, and contact records.
* **Data Viewing & Filtering (`View`):** Comprehensive tables for viewing records and monitoring store inventory.

---

## Tech Stack

* **Language:** C# (.NET Framework)
* **Application Type:** Windows Forms (WinForms Desktop)
* **IDE:** Microsoft Visual Studio

---

## Project Structure

```text
├── project_mobil.sln       # Visual Studio Solution File
├── img/                    # Icons and graphical UI assets
└── mobil/                  # Main Project Directory
    ├── Forms & UI Logic/   # Customer, Home, login, Mobilephone, View
    ├── Properties/         # Assembly info and project settings
    ├── Resources/          # Embedded app resources
    ├── App.config          # Application configuration
    ├── Program.cs          # Main entry point
    └── mobil.csproj        # C# Project dependencies
