
# Car Price API and Front-End

This project consists of two main components:

- **Front-End**: A Vue 3 application built with Vite for fast development and building.
- **Back-End**: A .NET 8 API that provides endpoints to calculate car prices and apply various fees.
- **Unit Tests**: A set of unit tests for the back-end API.
```

## Prerequisites

### Back-End
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet) (for the API and unit tests)
- Visual Studio or any IDE that supports .NET development (like Visual Studio Code with C# extensions)
- A compatible database (optional, based on your back-end requirements)

### Front-End
- [Node.js](https://nodejs.org/) (with npm or yarn)
- [Vite](https://vitejs.dev/) (for front-end development and build)

## Setting Up the Project

1. Clone the repository:
   ```bash
   git clone <repo-url>
   cd car-price-api/backend
   ```

2. Restore the .NET dependencies:
   ```bash
   dotnet restore
   ```

3. Run the back-end API:
   ```bash
   dotnet run
   ```
### 2. Front-End Setup

1. Navigate to the front-end directory:
   ```bash
   cd car-price-api/frontend
   ```
2. Install front-end dependencies:
   ```bash
   npm install
   # or
   yarn install
   ```

3. Start the development server:
   ```bash
   npm run dev
   # or
   yarn dev
   ```

The front-end will be available at `http://localhost:5172` and the back-end at `https://localhost:44308` (if you use a different port, please change the .env variable).

Please use the VS to run the CarPriceAPI, it should open a Swagger with all the API information. Also use the Test Explorer to run the tests.