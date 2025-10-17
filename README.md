# 🏢 GetChatty Ltd. — Kiosk Employee Portal

**GetChatty Ltd. Kiosk Employee Portal** is a **demo application** showcasing **modern access control**, **single sign-on (SSO)**, and **secure identity management** using **PingIdentity’s PingOne platform**.
Built with **.NET 8 Blazor WebAssembly**, the app demonstrates how enterprise-grade identity can be seamlessly integrated into a **single-page application (SPA)** or **mobile-style experience** using **OAuth 2.0 Authorization Code Flow with PKCE**.

---

## 🚀 Overview

This project was created to demonstrate:

* **SSO integration** with [PingOne](https://www.pingidentity.com/en/platform/pingone.html) for centralized authentication.
* **OAuth 2.0 Authorization Code Flow with PKCE** for secure token exchange in public clients.
* **Role-based access control (RBAC)** to manage user privileges (e.g., Employee, Manager, Admin).
* **Responsive kiosk-style UI** built with **Bootstrap 5** and **Blazor WebAssembly** for SPA-like performance.
* **Extensibility** for integration with APIs, group membership management, and user provisioning demos.

---

## 🧠 Key Features

* 🔐 **PingOne SSO** — Integrated identity with PingOne’s OpenID Connect endpoints.
* 🔑 **OAuth 2.0 w/ PKCE** — Secure flow designed for SPAs to prevent code interception.
* 👤 **User Management** — Displays authenticated user info and claims (name, email, groups, etc.).
* 🧾 **Access Control Demo** — Conditional UI elements based on PingOne group membership.
* 📱 **Kiosk-Ready Design** — Responsive layout for touch displays and employee self-service use cases.
* 🌐 **.NET 8 Blazor WASM** — Client-side rendering with fast load times and modern .NET development tools.

---

## 🧩 Architecture

```
+--------------------------+
|   Blazor WebAssembly UI  |
|   (.NET 8 SPA)           |
|      ↓                   |
|  OAuth2 / OIDC           |
|  Auth Code + PKCE        |
+-----------↑--------------+
            |
+-----------+--------------+
|   PingOne Platform       |
|   (Identity Provider)    |
|   - Authorization Server |
|   - Token Endpoint       |
|   - User Info API        |
+--------------------------+
```

* **Frontend:** Blazor WebAssembly SPA
* **Auth Flow:** OAuth 2.0 Authorization Code Grant (PKCE)
* **Identity Provider:** PingOne
* **Backend:** (Optional) ASP.NET Core Web API for resource protection and token validation

---

## ⚙️ Configuration

### 1. PingOne Setup

1. Log in to your **PingOne admin console**.
2. Register a new **Application**:

   * **Type:** Single Page Application (SPA)
   * **Grant Type:** Authorization Code with PKCE
   * **Redirect URI:** `https://localhost:5001/authentication/login-callback`
   * **Sign-Out Redirect URI:** `https://localhost:5001/`
3. Copy the following values:

   * **Environment ID**
   * **Client ID**
   * **Issuer URL**
   * **Token Endpoint**

### 2. App Settings

In `wwwroot/appsettings.json` (or `appsettings.Development.json`):

```json
{
    "OpenIdConnect": {
        "Authority": "https://auth.pingone.com/{EnvironmentId}/as",
        "ClientId": "{ClientId}",
        "ResponseType": "code",
        "DefaultScopes": [
        "openid",
        "profile"
        ]
    }
}
```

---

## 🧪 Running Locally

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* A PingOne developer account
* (Optional) Visual Studio 2022 or VS Code

### Steps

```bash
# 1. Clone the repo
git clone https://github.com/getchatty-ltd/kiosk-employee-portal.git
cd kiosk-employee-portal

# 2. Restore dependencies
dotnet restore

# 3. Run the project
dotnet run

# 4. Open in your browser
https://localhost:5001
```

---

## 🔍 Demo Use Cases

* **Employee Login:** Demonstrates PingOne-hosted login and redirect.
* **Access Control View:** Shows user’s group memberships and permissions.
* **Kiosk Portal UI:** Visual example of how identity-driven UX works in a corporate kiosk setting.

---

## 📦 Technologies Used

| Category | Technology                        |
| -------- | --------------------------------- |
| Frontend | Blazor WebAssembly (.NET 8)       |
| Auth     | PingOne (OAuth 2.0 + OIDC + PKCE) |
| UI       | Bootstrap 5                       |
| Hosting  | ASP.NET Core                      |
| Language | C#                                |
| Tools    | Visual Studio / VS Code           |

---

## 🔒 Security Considerations

* Implements **Authorization Code + PKCE** flow to protect against authorization code interception.
* Tokens are stored **in-memory**, not local storage, minimizing XSS risk.
* Redirect URIs are strictly validated in PingOne configuration.
* Logout uses `end_session_endpoint` for secure sign-out propagation.

---

## 🧰 Future Enhancements

* 🔁 Integration with PingOne Directory for dynamic user provisioning.
* 🧩 API gateway protection using OAuth 2.0 bearer tokens.
* 📊 Role-based dashboards using group claims.
* 💬 Integration with PingOne DaVinci for adaptive access or MFA.

---

## 👨‍💻 Author

**Developed by:** GetChatty Ltd.
**Engineer:** Bobby L.
**Tech Stack:** .NET 8, Blazor WebAssembly, PingOne Identity Platform

---