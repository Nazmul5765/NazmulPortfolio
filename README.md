# Nazmul Hussain — Developer Portfolio

![CI](https://github.com/Nazmul5765/NazmulPortfolio/actions/workflows/ci.yml/badge.svg)

My personal software developer portfolio, created to showcase my background, technical skills and projects while applying for junior C#/.NET development roles.

**Live website:** [nazmulhussain.co.uk](https://nazmulhussain.co.uk)

The portfolio presents my transition into software development, experience from the Northcoders Enterprise Engineering Bootcamp and detailed case studies of my RecordShop and Calico applications.

## Purpose

I built this portfolio to bring together the work I completed during and after the Northcoders Enterprise Engineering Bootcamp and to provide more detail than I can include on my CV.

Alongside introducing my background and technical skills, the site contains case studies explaining how I approached my projects, the problems I worked through and what I learned from building them.

I am currently seeking a junior software developer role where I can continue developing my C#/.NET skills and contribute as part of a development team.

## Portfolio Highlights

- Responsive dark-themed interface for desktop, tablet and mobile devices
- Separate Home, About, Projects and Contact pages
- Detailed RecordShop and Calico project case studies
- Reusable project-card and skill-badge components
- Responsive navigation with a mobile menu
- Custom catch-all 404 page
- Page titles and descriptive metadata
- Automatic scroll reset when navigating between pages
- Railway-compatible health-check endpoint
- Docker-based production deployment

## Pages

| Route | Purpose |
|---|---|
| `/` | Introduction, skills, featured projects and contact call to action |
| `/about` | Career background, Northcoders experience and development approach |
| `/projects` | Overview of the projects included in the portfolio |
| `/projects/recordshop` | Detailed RecordShop case study |
| `/projects/calico` | Detailed Calico case study |
| `/contact` | LinkedIn, GitHub, email and availability information |
| Any unknown route | Custom page-not-found experience |

## Featured Projects

### RecordShop

RecordShop is my solo Northcoders full-stack project. It is a record shop application with a separate ASP.NET Core Web API and Blazor frontend.

The application allows users to:

- Browse records
- View individual record information
- Search by record ID, title or artist
- Add new records
- Update existing records
- Delete records

The backend uses a layered controller, service and repository architecture with Entity Framework Core and includes automated testing using NUnit, Moq and Shouldly.

The application was originally developed using SQL Server and was later configured to use PostgreSQL with Neon for production deployment. The frontend and backend are deployed as separate Docker services on Railway.

- [Live RecordShop application](https://recordshop.nazmulhussain.co.uk)
- [Backend repository](https://github.com/Nazmul5765/record-shop-api)
- [Frontend repository](https://github.com/Nazmul5765/record-shop-frontend)

### Calico

Calico is a collaborative Northcoders group project combining Lo-Fi music with productivity and task-management tools. Since the bootcamp, I've gone back to it independently — running a full security review, fixing what it found, and deploying it myself.

The project includes:

- Lo-Fi music discovery and playback via the YouTube API
- Task timer and Pomodoro sessions
- User registration and authentication with Supabase
- User profiles
- ASP.NET Core and Blazor frontend/backend development
- Collaborative development using pair programming, daily stand-ups, Trello and Git

The backend uses the same layered controller, service and repository architecture as RecordShop. The frontend and backend are deployed as separate Docker services on Railway, with the backend connecting to an Azure SQL Database in production.

The portfolio includes a detailed case study covering the original group project, my individual contributions, and the independent work I did afterwards.

- [Live Calico application](https://calico.nazmulhussain.co.uk)
- [Backend repository](https://github.com/Nazmul5765/calico-backend)
- [Frontend repository](https://github.com/Nazmul5765/calico-frontend)

## Technologies

The portfolio itself uses:

- C#
- .NET 8
- ASP.NET Core
- Blazor Web App
- Interactive Server rendering
- Razor components
- HTML
- CSS
- Bootstrap
- JavaScript
- Docker
- Railway

The site primarily uses custom CSS, including CSS custom properties, responsive layouts and component-scoped styles. A small JavaScript helper resets the browser scroll position after enhanced Blazor navigation.

Technologies such as Entity Framework Core, SQL Server, PostgreSQL, Azure SQL, NUnit, Supabase and the YouTube API are used within the featured projects rather than being dependencies of the portfolio application itself.

## Project Structure

```text
NazmulPortfolio/
├── Dockerfile
├── global.json
├── NazmulPortfolio.sln
└── NazmulPortfolio/
    ├── Components/
    │   ├── Layout/
    │   │   ├── MainLayout.razor
    │   │   ├── MainLayout.razor.css
    │   │   ├── NavMenu.razor
    │   │   └── NavMenu.razor.css
    │   ├── Pages/
    │   │   ├── Home.razor
    │   │   ├── About.razor
    │   │   ├── Projects.razor
    │   │   ├── RecordShop.razor
    │   │   ├── Calico.razor
    │   │   ├── Contact.razor
    │   │   ├── PageNotFound.razor
    │   │   └── Error.razor
    │   ├── Shared/
    │   │   ├── ProjectCard.razor
    │   │   └── SkillBadge.razor
    │   ├── App.razor
    │   ├── Routes.razor
    │   └── _Imports.razor
    ├── wwwroot/
    │   ├── js/
    │   │   └── site.js
    │   ├── app.css
    │   └── favicon.png
    ├── Program.cs
    └── NazmulPortfolio.csproj
```

The application uses a shared layout for the header, navigation, main content and footer. Individual page and component styles are kept in scoped `.razor.css` files, while shared colours, typography and global rules are defined in `wwwroot/app.css`.

## Running Locally

### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git

### Setup

Clone the repository:

```bash
git clone https://github.com/Nazmul5765/NazmulPortfolio.git
cd NazmulPortfolio
```

Restore the project dependencies:

```bash
dotnet restore
```

Run the application with hot reload:

```bash
dotnet watch --project NazmulPortfolio/NazmulPortfolio.csproj
```

Open the local address displayed in the terminal.

The portfolio does not require a database, API key or other secret configuration.

The health-check endpoint is available at:

```text
/health
```

## Running with Docker

Build the image from the solution directory:

```bash
docker build -t nazmul-portfolio .
```

Run the container locally:

```bash
docker run --rm -p 8080:8080 -e PORT=8080 nazmul-portfolio
```

The portfolio will then be available at:

```text
http://localhost:8080
```

## Deployment

The portfolio is containerised using Docker and deployed on Railway directly from the GitHub repository.

The production setup follows:

```text
GitHub
   ↓
Docker build
   ↓
Railway
   ↓
nazmulhussain.co.uk
```

The application listens on Railway's supplied `PORT` environment variable and exposes a `/health` endpoint used to verify that the application is running correctly.

DNS is managed through Namecheap:

- `nazmulhussain.co.uk` serves the portfolio.
- `www.nazmulhussain.co.uk` redirects to the main domain.
- `recordshop.nazmulhussain.co.uk` serves the RecordShop frontend.

The portfolio and RecordShop were previously hosted on Render. I later moved them to Railway after experiencing cold-start delays when inactive Render services needed to start again, particularly with RecordShop's separately deployed frontend and backend.

## Links

- [Portfolio](https://nazmulhussain.co.uk)
- [RecordShop live application](https://recordshop.nazmulhussain.co.uk)
- [GitHub](https://github.com/Nazmul5765)
- [LinkedIn](https://www.linkedin.com/in/nazmul-hussain/)

## Author

Nazmul Hussain
