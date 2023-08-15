Theme: Use Azure APIM to host multiple API products for multiple API consumers

Objectives:
- How to monetize (charge customers) API?
- How to protect backends?
- How to secure APIs?
- How to use products, subscriptions, quota and rate limits?
- How to add / remove customers without affecting other customers? No downtime

---

Case Study:

Products:
- Simple Calculator
- Scientific Calculator
- Financial Calculator

API:
- Add two numbers
- Multiple two numbers
- Calculate simple interest
- Calculate compound interest
- Calculate Sin(x)
- Calculate Log(x)

---

Tech-Stack:
- C#
- C# VS Code Extension
- Azure Function App
- Azure Function VS Code Extension
- Azure Function Core Tools for local development
-- winget install Microsoft.Azure.FunctionsCoreTools
- Azure API Management
- Azure DevOps
- Azure Resource Manager
- Locust performance tests

---

CI/CD:

CI: Build + UT + Artifact (Default=No)
CD: CI (Artifact = Yes) + Provision + Deploy
Destroy: Destroy specified env
Load: CD + Locust

---

Open Points:
- Function level authorization