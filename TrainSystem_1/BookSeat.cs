using System;
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

        Console.Write("\nHow many seats would you like to book? ");
        if (!int.TryParse(Console.ReadLine(), out int seatCount) ||
            seatCount < 1 || seatCount > 40)
        {
            Console.WriteLine("Invalid number of seats!");
            return;
        }

        if (!selectedSchedule.HasEnoughAvailableSeats(seatCount))
        {
            Console.WriteLine($"Sorry, only {selectedSchedule.GetAvailableSeatsCount()} seats available!");
            return;
        }

        List<int> seatsToBook = new List<int>();
        DisplaySeatMap(selectedSchedule);

        for (int i = 0; i < seatCount; i++)
        {
            Console.Write($"\nEnter seat number {i + 1} of {seatCount} (1-40): ");
            if (!int.TryParse(Console.ReadLine(), out int seatNumber) ||
                seatNumber < 1 || seatNumber > 40)
            {
                Console.WriteLine("Invalid seat number!");
                return;
            }

            if (selectedSchedule.IsSeatBooked(seatNumber - 1))
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
            selectedSchedule.ToggleSeat(seatNumber);
        }

        Console.WriteLine($"\nBooking successful! You have booked seats: {string.Join(", ", seatsToBook.Select(x => x + 1))}");
    }

    private void DisplaySeatMap(TrainSchedule schedule)
    {
        Console.WriteLine("\nSeat Map (O=Available, X=Booked):");
        for (int i = 0; i < 40; i += 8)
        {
            for (int j = 0; j < 8 && (i + j) < 40; j++)
            {
                Console.Write($"{(schedule.IsSeatBooked(i + j) ? "X" : "O")} ");
            }
            Console.WriteLine();
        }
    }
}
