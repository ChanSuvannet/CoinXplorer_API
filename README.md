
# 🪙 CoinXplorer

**CoinXplorer** is an open-source ecosystem delivering **real-time cryptocurrency data** through a scalable **C# (.NET Core) RESTful API** and a modern **Flutter mobile application**. Stay updated with live coin prices, market stats, and more!
<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-purple?logo=dotnet" />
  <img src="https://img.shields.io/badge/CoinGecko-API-blue?logo=coingecko" />
  <img src="https://img.shields.io/badge/Swashbuckle-6.5.0-green?logo=swagger" />
  <img src="https://img.shields.io/badge/License-MIT-green.svg" />
</p>

## 🛠️ CoinXplorer_API (Backend)

**CoinXplorer_API** is a high-performance RESTful API built with **C# (.NET Core)** to provide real-time and historical cryptocurrency data, leveraging external services like CoinGecko for accurate market insights.

### 🚀 Features

- 🔄 **Real-Time Coin Prices**: Fetch live prices for cryptocurrencies in USD.
- 📊 **Market Insights**: Access market cap, volume, and ranking for coins.
- ⏳ **Historical Data Support**: Planned support for historical price trends.
- ⚙️ **RESTful Endpoints**: Clean, intuitive API routes for easy integration.
- 🌐 **Real-Time Updates**: SignalR-powered hub for live coin data broadcasts.
- 🔒 **CORS Support**: Flexible cross-origin requests for web and mobile clients.

---

### 📦 Prerequisites

- [.NET 9 SDK or later](https://dotnet.microsoft.com/download)
- A stable internet connection for API calls to external services (e.g., CoinGecko)
- A Flutter setup for testing with the [CoinXplorer Flutter app](https://github.com/ChanSuvannet/CoinXplorer)

---

### ⚙️ Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/ChanSuvannet/CoinXplorer_API.git
   cd CoinXplorer_API
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the Project**
   ```bash
   dotnet build
   ```

4. **Run the Project**
   ```bash
   dotnet run
   ```
   - The API will start on `https://localhost:5174` (or a port specified in your configuration).
   - In development, Swagger UI is available at `/swagger` for API exploration.

5. **Test with Flutter or Tools**
   - Replace `localhost` with your machine’s IP or `10.0.2.2` when testing with an Android emulator.
   - Use tools like Postman or curl to interact with the API.

---

### 📡 API Endpoints

| Method | Endpoint          | Description                        |
| ------ | ----------------- | ---------------------------------- |
| GET    | `/api/coins/live` | Fetch real-time data for all coins |
| GET    | `/api/coins/{id}` | Get details for a specific coin    |
| GET    | `/api/coins/ping` | Check if the coin route is alive   |

- **Base URL**: `https://localhost:5174` (default in development)
- **Note**: The `/api/coins/live` endpoint retrieves data from CoinGecko’s `/coins/markets?vs_currency=usd` endpoint, returning coin details like price, market cap, and volume in USD.

---

### 🌐 Real-Time Updates with SignalR

- **Hub Endpoint**: `/coinhub`
- The API uses SignalR to broadcast live coin data updates via the `CoinBroadcastService` background service.
- Connect to the `/coinhub` endpoint from your client (e.g., Flutter app) to receive real-time updates.