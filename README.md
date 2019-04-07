# SCHEDULES TEST 2019

## Architecture

- GAP.DOMAIN
	- BAL: Business logic layer.
	- DTO: Data transfer objects.
- GAP.DATA 
	- SAL: Data acess layer.
	- Migrations EF.
- GAP.API
	- API: Web API.
- GAP.WEB: Application client.
- GAP.TEST: Unit Test project.	

## TOOLS

- .NET Framework BACKEND : API - DAL - SAL - DTOS
- .NET Core 2.1 FRONTEND : APP-WEB 
- JS - Jquery - CSS - HTML5
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
