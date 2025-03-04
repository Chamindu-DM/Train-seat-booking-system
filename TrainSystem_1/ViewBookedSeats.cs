using System;
using System.Collections.Generic;
using System.Linq;

class ViewBookedSeats
{
    private readonly Routes _routes;

    public ViewBookedSeats(Routes routes)
    {
        _routes = routes;
    }

    public void DisplayBookedSeats()
    {
        // Display available routes for selection
        Console.WriteLine("\nAvailable Routes:");
        var routesList = _routes.RouteSchedules.Keys.ToList();
        for (int i = 0; i < routesList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {routesList[i]}");
        }

        // Get user's route selection
        Console.Write("\nSelect route number: ");
        if (!int.TryParse(Console.ReadLine(), out int routeIndex) ||
            routeIndex < 1 || routeIndex > routesList.Count)
        {
            Console.WriteLine("Invalid route number!");
            return;
        }

        string routeName = routesList[routeIndex - 1];
        var schedules = _routes.RouteSchedules[routeName];

        // Display available train schedules for selected route
        Console.WriteLine($"\nAvailable Schedules for {routeName}:");
        for (int i = 0; i < schedules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {schedules[i].Name} at {schedules[i].Time}");
        }

        // Get user's schedule selection
        Console.Write("\nSelect schedule number: ");
        if (!int.TryParse(Console.ReadLine(), out int scheduleIndex) ||
            scheduleIndex < 1 || scheduleIndex > schedules.Count)
        {
            Console.WriteLine("Invalid schedule!");
            return;
        }

        var selectedSchedule = schedules[scheduleIndex - 1];
        
        Console.WriteLine($"\n== Booked Seats for {routeName}: {selectedSchedule.Name} at {selectedSchedule.Time} ==");
        
        // Process each class with appropriate sorting algorithm
        ProcessClassBookings(selectedSchedule, "First Class");
        ProcessClassBookings(selectedSchedule, "Second Class");
        ProcessClassBookings(selectedSchedule, "Third Class");
    }
    
    private void ProcessClassBookings(TrainSchedule schedule, string seatClass)
    {
        var bookedSeats = schedule.GetBookedSeats(seatClass);
        if (bookedSeats.Count == 0)
        {
            Console.WriteLine($"\n{seatClass}: No booked seats");
            return;
        }
        
        // Choose appropriate sorting algorithm based on class size
        string algorithmUsed;
        switch (seatClass)
        {
            case "First Class":
                // Small dataset (40) - Bubble Sort is simple and works well
                SortingAlgorithms.BubbleSort(bookedSeats);
                algorithmUsed = "Bubble Sort";
                break;
                
            case "Second Class":
                // Medium dataset (100) - Selection Sort has better performance
                SortingAlgorithms.SelectionSort(bookedSeats);
                algorithmUsed = "Selection Sort";
                break;
                
            case "Third Class":
                // Large dataset (300) - Merge Sort is much more efficient
                bookedSeats = SortingAlgorithms.MergeSort(bookedSeats);
                algorithmUsed = "Merge Sort";
                break;
                
            default:
                SortingAlgorithms.BubbleSort(bookedSeats);
                algorithmUsed = "Bubble Sort";
                break;
        }
        
        // Display the sorted booked seats
        Console.WriteLine($"\n{seatClass} - Booked seats (sorted using {algorithmUsed}):");
        Console.WriteLine($"Seats: {string.Join(", ", bookedSeats.Select(x => x + 1))}");
        
        // Educational note about the algorithm choice
        Console.WriteLine($"Algorithm Note: {GetAlgorithmNote(seatClass)}");
    }
    
    private string GetAlgorithmNote(string seatClass)
    {
        return seatClass switch
        {
            "First Class" => "Bubble Sort is simple and efficient for small datasets (40 seats)",
            "Second Class" => "Selection Sort performs better than Bubble Sort for medium datasets (100 seats)",
            "Third Class" => "Merge Sort is efficient for large datasets (300 seats) with O(n log n) complexity",
            _ => string.Empty
        };
    }
}