using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ViewBookedSeats
{
    private readonly Routes _routes;

    public ViewBookedSeats(Routes routes)
    {
        _routes = routes;
    }

    public void DisplayBookedSeats()
    {
        Console.WriteLine("\nSelect sorting algorithm:");
        Console.WriteLine("1. Bubble Sort");
        Console.WriteLine("2. Selection Sort");
        Console.WriteLine("3. Merge Sort");

        string sortChoice = Console.ReadLine() ?? "1";

        foreach (var route in _routes.RouteSchedules)
        {
            Console.WriteLine($"\nRoute: {route.Key}");
            foreach (var schedule in route.Value)
            {
                var bookedSeats = schedule.GetBookedSeats();
                switch (sortChoice)
                {
                    case "1": SortingAlgorithms.BubbleSort(bookedSeats); break;
                    case "2": SortingAlgorithms.SelectionSort(bookedSeats); break;
                    case "3": bookedSeats = SortingAlgorithms.MergeSort(bookedSeats).ToList(); break;
                }

                Console.WriteLine($"{schedule.Name} at {schedule.Time} - Booked seats: {string.Join(", ", bookedSeats.Select(x => x + 1))}");
            }
        }
    }
}