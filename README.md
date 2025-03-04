# Train Seat Booking System

A console-based application for booking train seats on Sri Lankan railway routes.

## Overview

This application simulates a train booking system for Sri Lanka Railways, allowing users to view schedules, book seats on specific trains, and view booked seats sorted using different algorithms.

## Features

- **View Train Schedules**: Browse available routes and their corresponding train schedules
- **Book Seats**: Select a route, schedule, and specific seats for booking
- **View Booked Seats**: See all booked seats sorted using different algorithms:
  - Bubble Sort
  - Selection Sort
  - Merge Sort

## Routes Available

The system includes the following major routes:
- Colombo-Kandy
- Colombo-Galle
- Colombo-Jaffna
- Colombo-Batticaloa
- Colombo-Badulla

## How to Run

1. Clone the repository
2. Open the solution in Visual Studio
3. Build the solution
4. Run the application using F5 or by running the executable from the Debug folder

## Project Structure

- [`Program.cs`](TrainSystem_1/Program.cs): Entry point of the application
- [`TrainSystem.cs`](TrainSystem_1/TrainSystem.cs): Main system class with menu interface
- [`Routes.cs`](TrainSystem_1/Routes.cs): Defines all available train routes and schedules
- [`TrainSchedule.cs`](TrainSystem_1/TrainSchedule.cs): Manages individual train schedules and seat availability
- [`BookSeat.cs`](TrainSystem_1/BookSeat.cs): Handles the seat booking functionality
- [`ViewSchedule.cs`](TrainSystem_1/ViewSchedule.cs): Displays all available train schedules
- [`ViewBookedSeats.cs`](TrainSystem_1/ViewBookedSeats.cs): Shows booked seats with sorting options
- [`SortingAlgorithms.cs`](TrainSystem_1/SortingAlgorithms.cs): Implements different sorting algorithms

## Requirements

- .NET 8.0 or higher

## License

This project is for educational purposes only.