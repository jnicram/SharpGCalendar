# Sharp GCalendar
Simple calendar like Google calendar written in C#

## Basic flow
![alt tag](https://github.com/jnicram/SharpGCalendar/blob/master/doc/main_diagram.png)

## Technology stack
- backend
 - ASP.NET MVC WebApi
 - LiteDB (NoSql DB)
 - Ensure.That
 - Unity
 - NUnit
- frontend
 - AngularJs

## Project structure
- SharpGCalendar.Web – UI layer. The AngularJS web application.
- SharpGCalendar.Domain - Represents application’s domain model.
- SharpGCalendar.Repository - Executions DB operations (e.g create, update, delete, find).
- SharpGCalendar.Service - Services layer. The Business logic responsible for operating on entity.
- SharpGCalendar.Api - Provides REST for events management.
- SharpGCalendar.Tests - Unit tests with usage of NUnit framework.

## TODO
- add support for storing events per user
- add support for different types of calendar
- add REST requests in the frontend side
- add UI for events creation (frontend side)

## References
- Martin Fowler, Recurring Events for Calendars, http://martinfowler.com/apsupp/recurring.pdf
