# SCHEDULES TEST 2019

- .NET Framework BACKEND : API - DAL - SAL - DTOS
- .NET Core 2.1 FRONTEND : APP-WEB 
- EntityFramework
- AutoFac
- Microsoft SQL Server

## How to run

1. Execute DB migrations:
- Open Package Manager Console.
- Select the default GAP.DATA/Migrations as default project.
- run the command:-
					enable-migrations –EnableAutomaticMigration:$true
					
					update-database -verbose -force

2. Set up GAP.API/API & GAP.WEB/APP on Multi start projects.

Run.
