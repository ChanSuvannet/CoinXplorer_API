
# 🪙 CoinXplorer API

**CoinXplorer** is an open-source ecosystem delivering **real-time cryptocurrency data** through a scalable **C# API** and a modern **Flutter mobile application**.

---

## 🛠️ CoinXplorer\_API (Backend)

CoinXplorer\_API is a RESTful API built with **C# (.NET Core)** that provides live and historical cryptocurrency data.

### 🚀 Features

* 🔄 Real-time coin prices
* 📊 Market cap, volume, and ranking
* ⏳ Historical data support
* ⚙️ RESTful endpoints

---

### 📦 Prerequisites

* [.NET 9 SDK or later](https://dotnet.microsoft.com/download)

---

### ⚙️ Setup Instructions

```bash
# Clone the repository
git clone https://github.com/ChanSuvannet/CoinXplorer_API.git
cd CoinXplorer_API

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the project
dotnet run
```
---

### 📡 API Endpoints

| Method | Endpoint          | Description                      |
| ------ | ----------------- | -------------------------------- |
| GET    | `/api/coins/live` | Get real-time data for all coins |
| GET    | `/api/coins/{id}` | Get details for a specific coin  |

> Replace `localhost` with your machine’s IP or `10.0.2.2` for Android emulator when testing with Flutter.

---

* [CoinXplorer Flutter](https://github.com/ChanSuvannet/CoinXplorer)
