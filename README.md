# London Stock API

A backend service built using **ASP.NET Core Web API** and **PostgreSQL** that ingests real-time stock trades and exposes current stock prices calculated as the **average trade price**.

This project demonstrates **Clean Architecture**, **Domain-Driven Design**, **SOLID principles**, and a scalable approach to backend system design.

---

## 📌 Problem Statement

The system needs to:

- Receive stock trades in real time
- Persist all trades in a relational database
- Calculate the current value of a stock as the **average price of all its trades**
- Expose APIs to:
  - Get price of a single stock
  - Get prices of all stocks
  - Get prices for a selected list of stocks

---

## 🧱 Architecture Overview

The solution follows **Clean Architecture** with clear separation of concerns:

