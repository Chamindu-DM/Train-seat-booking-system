﻿using System;
using System.Collections.Generic;
using System.Linq;

class BookSeat
{
    private readonly Routes _routes;

    public BookSeat(Routes routes)
    {
        _routes = routes;
    }

    public void Book()
    {
        Console.WriteLine("\nAvailable Routes:");
        var routesList = _routes.RouteSchedules.Keys.ToList();
        for (int i = 0; i < routesList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {routesList[i]}");
        }

        Console.Write("\nSelect route number: ");
        if (!int.TryParse(Console.ReadLine(), out int routeIndex) ||
            routeIndex < 1 || routeIndex > routesList.Count)
        {
            Console.WriteLine("Invalid route number!");
            return;
        }

        string routeName = routesList[routeIndex - 1];
        var schedules = _routes.RouteSchedules[routeName];

        Console.WriteLine("\nAvailable Schedules:");
        for (int i = 0; i < schedules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {schedules[i].Name} at {schedules[i].Time}");
        }

        Console.Write("\nSelect schedule number: ");
        if (!int.TryParse(Console.ReadLine(), out int scheduleIndex) ||
            scheduleIndex < 1 || scheduleIndex > schedules.Count)
        {
            Console.WriteLine("Invalid schedule!");
            return;
        }

        var selectedSchedule = schedules[scheduleIndex - 1];
        
        // Select class
        Console.WriteLine("\nAvailable Classes:");
        Console.WriteLine("1. First Class (40 seats)");
        Console.WriteLine("2. Second Class (100 seats)");
        Console.WriteLine("3. Third Class (300 seats)");
        Console.Write("\nSelect class: ");
        
        if (!int.TryParse(Console.ReadLine(), out int classChoice) ||
            classChoice < 1 || classChoice > 3)
        {
            Console.WriteLine("Invalid class selection!");
            return;
        }
        
        string seatClass = classChoice switch
        {
            1 => "First Class",
            2 => "Second Class",
            3 => "Third Class",
            _ => "First Class" // Default case
        };
        
        int maxSeats = selectedSchedule.GetTotalSeats(seatClass);

        decimal seatPrice = selectedSchedule.GetAdjustedPrice(seatClass, routeName);
        Console.WriteLine($"\n{seatClass} price per seat: Rs. {seatPrice:F2}");

        Console.Write($"\nHow many seats would you like to book? (1-{maxSeats}): ");
        if (!int.TryParse(Console.ReadLine(), out int seatCount) ||
            seatCount < 1 || seatCount > maxSeats)
        {
            Console.WriteLine("Invalid number of seats!");
            return;
        }

        if (!selectedSchedule.HasEnoughAvailableSeats(seatClass, seatCount))
        {
            Console.WriteLine($"Sorry, only {selectedSchedule.GetAvailableSeatsCount(seatClass)} seats available in {seatClass}!");
            return;
        }

        List<int> seatsToBook = new List<int>();
        DisplaySeatMap(selectedSchedule, seatClass);

        for (int i = 0; i < seatCount; i++)
        {
            Console.Write($"\nEnter seat number {i + 1} of {seatCount} (1-{maxSeats}): ");
            if (!int.TryParse(Console.ReadLine(), out int seatNumber) ||
                seatNumber < 1 || seatNumber > maxSeats)
            {
                Console.WriteLine("Invalid seat number!");
                return;
            }

            if (selectedSchedule.IsSeatBooked(seatClass, seatNumber - 1))
            {
                Console.WriteLine($"Seat {seatNumber} is already booked!");
                return;
            }

            if (seatsToBook.Contains(seatNumber - 1))
            {
                Console.WriteLine($"Seat {seatNumber} is already in your selection!");
                return;
            }

            seatsToBook.Add(seatNumber - 1);
        }

        // Book all selected seats
        foreach (int seatNumber in seatsToBook)
        {
            selectedSchedule.ToggleSeat(seatClass, seatNumber);
        }

        Console.WriteLine($"\nBooking successful! You have booked {seatClass} seats: {string.Join(", ", seatsToBook.Select(x => x + 1))}");

        decimal totalPrice = seatPrice * seatsToBook.Count;
        Console.WriteLine($"Total price: Rs. {totalPrice:F2}");
    }

    public void CancelBooking()
    {
        Console.WriteLine("\nAvailable Routes:");
        var routesList = _routes.RouteSchedules.Keys.ToList();
        for (int i = 0; i < routesList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {routesList[i]}");
        }

        Console.Write("\nSelect route number: ");
        if (!int.TryParse(Console.ReadLine(), out int routeIndex) ||
            routeIndex < 1 || routeIndex > routesList.Count)
        {
            Console.WriteLine("Invalid route number!");
            return;
        }

        string routeName = routesList[routeIndex - 1];
        var schedules = _routes.RouteSchedules[routeName];

        Console.WriteLine("\nAvailable Schedules:");
        for (int i = 0; i < schedules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {schedules[i].Name} at {schedules[i].Time}");
        }

        Console.Write("\nSelect schedule number: ");
        if (!int.TryParse(Console.ReadLine(), out int scheduleIndex) ||
            scheduleIndex < 1 || scheduleIndex > schedules.Count)
        {
            Console.WriteLine("Invalid schedule!");
            return;
        }

        var selectedSchedule = schedules[scheduleIndex - 1];
        
        // Select class
        Console.WriteLine("\nSelect Class for Cancellation:");
        Console.WriteLine("1. First Class");
        Console.WriteLine("2. Second Class");
        Console.WriteLine("3. Third Class");
        Console.Write("\nSelect class: ");
        
        if (!int.TryParse(Console.ReadLine(), out int classChoice) ||
            classChoice < 1 || classChoice > 3)
        {
            Console.WriteLine("Invalid class selection!");
            return;
        }
        
        string seatClass = classChoice switch
        {
            1 => "First Class",
            2 => "Second Class",
            3 => "Third Class",
            _ => "First Class" // Default case
        };
        
        // Show currently booked seats
        var bookedSeats = selectedSchedule.GetBookedSeats(seatClass);
        if (bookedSeats.Count == 0)
        {
            Console.WriteLine($"No booked seats found in {seatClass} for this schedule.");
            return;
        }
        
        Console.WriteLine($"\nCurrently Booked Seats in {seatClass}:");
        DisplaySeatMap(selectedSchedule, seatClass);
        Console.WriteLine($"Booked seat numbers: {string.Join(", ", bookedSeats.Select(x => x + 1))}");
        
        // Ask which seats to cancel
        Console.Write("\nHow many seats would you like to cancel? ");
        if (!int.TryParse(Console.ReadLine(), out int cancelCount) ||
            cancelCount < 1 || cancelCount > bookedSeats.Count)
        {
            Console.WriteLine("Invalid number!");
            return;
        }
        
        List<int> seatsToCancel = new List<int>();
        for (int i = 0; i < cancelCount; i++)
        {
            Console.Write($"\nEnter seat number {i + 1} of {cancelCount} to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int seatNumber) ||
                seatNumber < 1 || seatNumber > selectedSchedule.GetTotalSeats(seatClass))
            {
                Console.WriteLine("Invalid seat number!");
                return;
            }

            if (!selectedSchedule.IsSeatBooked(seatClass, seatNumber - 1))
            {
                Console.WriteLine($"Seat {seatNumber} is not booked!");
                return;
            }

            if (seatsToCancel.Contains(seatNumber - 1))
            {
                Console.WriteLine($"Seat {seatNumber} is already in your cancellation list!");
                return;
            }

            seatsToCancel.Add(seatNumber - 1);
        }
        
        // Calculate refund amount (70% of original price)
        decimal refundAmount = 0;
        foreach (int seat in seatsToCancel)
        {
            refundAmount += selectedSchedule.GetSeatPrice(seatClass) * 0.7m;
        }

        // Cancel the selected seats
        foreach (int seatNumber in seatsToCancel)
        {
            selectedSchedule.ToggleSeat(seatClass, seatNumber);
        }

        Console.WriteLine($"\nCancellation successful! You have cancelled {seatClass} seats: {string.Join(", ", seatsToCancel.Select(x => x + 1))}");
        Console.WriteLine($"Refund amount: Rs. {refundAmount:F2} (70% of original price)");
    }

    private void DisplaySeatMap(TrainSchedule schedule, string seatClass)
    {
        int totalSeats = schedule.GetTotalSeats(seatClass);
        int columns = seatClass switch
        {
            "First Class" => 8,    // 5 rows of 8 seats
            "Second Class" => 10,  // 10 rows of 10 seats
            "Third Class" => 15,   // 20 rows of 15 seats
            _ => 8
        };
        
        Console.WriteLine($"\n{seatClass} Seat Map (O=Available, X=Booked):");
        for (int i = 0; i < totalSeats; i += columns)
        {
            // Add row number for better readability
            Console.Write($"Row {i/columns + 1}: ");
            
            for (int j = 0; j < columns && (i + j) < totalSeats; j++)
            {
                // Show seat number for better user experience
                int seatNumber = i + j + 1;
                string seatDisplay = schedule.IsSeatBooked(seatClass, i + j) ? "X" : "O";
                Console.Write($"{seatNumber:D2}({seatDisplay}) ");
                
                // Add aisle for visual clarity in larger classes
                if (seatClass != "First Class" && j == columns / 2 - 1)
                    Console.Write(" | ");
            }
            Console.WriteLine();
        }
    }
}
