# StudentClinic - Backend
WebAPI for StudentClinic\
Repository with the frontend can be found here [StudentClinic-Vue](https://github.com/kacperrymkiewicz/StudentClinic-Vue)

## Stack
- .NET Core 6 WebAPI
- Entity Framework
- Swagger
- AutoMapper
- JWT

## Core features
- REST architecture
- JWT based authentication
- Slot based appointments

## Setup
Get the code by either cloning this repository using git

```
git clone https://github.com/kacperrymkiewicz/StudentClinic-WebApi.git
```

```
dotnet ef database update
```

#### Compiles and hot-reloads for development
```
dotnet watch run
```

#### Production
```
dotnet publish -r linux-x64 --no-self-contained
```

![SWAGGER IMG](/docs/screen-swagger.png)