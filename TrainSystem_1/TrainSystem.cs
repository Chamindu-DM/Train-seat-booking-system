using System;

class TrainSystem
{
    private readonly Routes _routes;
    private readonly ViewSchedule _viewSchedule;
    private readonly BookSeat _bookSeat;
    private readonly ViewBookedSeats _viewBookedSeats;

    public TrainSystem()
    {
        _routes = new Routes();
        _viewSchedule = new ViewSchedule(_routes);
        _bookSeat = new BookSeat(_routes);
        _viewBookedSeats = new ViewBookedSeats(_routes);
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Sri Lanka Railways Booking System ===");
            Console.WriteLine("1. View Train Schedules");
            Console.WriteLine("2. Book a Seat");
            Console.WriteLine("3. Cancel Booking");
            Console.WriteLine("4. View Booked Seats (Sorted)");
            Console.WriteLine("5. Exit");
            Console.Write("Select option: ");

            switch (Console.ReadLine())
            {
                case "1": _viewSchedule.DisplaySchedules(); break;
                case "2": _bookSeat.Book(); break;
                case "3": _bookSeat.CancelBooking(); break;
                case "4": _viewBookedSeats.DisplayBookedSeats(); break;
                case "5": return;
                default: Console.WriteLine("Invalid option"); break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
