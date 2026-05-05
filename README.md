# Lexicon FlowControl OOP

A small C# console application for practicing flow control, enums, classes, methods, validation, and basic object-oriented structure.

The application is based on a menu where the user can choose between different exercises:

- Calculate ticket price based on age
- Calculate total ticket price for a group
- Repeat a text ten times
- Print the third word from a sentence
- Quit the application

## Purpose

The purpose of this project is to refactor a basic flow-control console application into a more object-oriented structure.

The project practices:

- `enum` usage for menu choices and ticket price types
- Classes for separate responsibilities
- Constructor validation
- Method extraction
- Basic exception handling
- Console input and output
- Arrays and loops
- String handling

## Project structure

```text
FlowControl-oop/
├── Enums/
│   ├── MenuChoice.cs
│   └── TicketPriceType.cs
├── Services/
│   ├── TextRepeater.cs
│   ├── ThirdWordExtractor.cs
│   ├── Ticket.cs
│   └── TicketPriceCalculator.cs
├── Program.cs
├── .gitattributes
└── .gitignore


## Code style

The project uses a simple folder structure:

- `Enums` contains enum types
- `Services` contains classes with application logic
- `Records` is reserved for simple data objects if needed
- `Program.cs` handles the console menu and user interaction

## Notes
This is a learning project for practicing C# fundamentals and basic OOP.

