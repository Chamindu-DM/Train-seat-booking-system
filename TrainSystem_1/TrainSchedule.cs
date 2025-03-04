using System;
using System.Collections.Generic;
using System.Linq;

class TrainSchedule
{
    public string Name { get; }
    public string Time { get; }
    private Dictionary<string, bool[]> seatsByClass;
    private Dictionary<string, decimal> seatPrices;

    public TrainSchedule(string name, string time)
    {
        Name = name;
        Time = time;
        seatsByClass = new Dictionary<string, bool[]>
        {
            { "First Class", new bool[40] },   // 40 seats
            { "Second Class", new bool[100] }, // 100 seats
            { "Third Class", new bool[300] }   // 300 seats
        };
        
        // ticket prices
        seatPrices = new Dictionary<string, decimal>
        {
            { "First Class", 1500m },   // Rs. 1500
            { "Second Class", 800m },   // Rs. 800
            { "Third Class", 400m }     // Rs. 400
        };
    }

    public bool IsSeatBooked(string seatClass, int seatNumber) => seatsByClass[seatClass][seatNumber];

    public void ToggleSeat(string seatClass, int seatNumber)
    {
        seatsByClass[seatClass][seatNumber] = !seatsByClass[seatClass][seatNumber];
    }

    public List<int> GetBookedSeats(string seatClass)
    {
        var bookedSeats = new List<int>();
        var seats = seatsByClass[seatClass];
        for (int i = 0; i < seats.Length; i++)
            if (seats[i])
                bookedSeats.Add(i);
        return bookedSeats;
    }

    public int GetAvailableSeatsCount(string seatClass)
    {
        return seatsByClass[seatClass].Count(seat => !seat);
    }

    public bool HasEnoughAvailableSeats(string seatClass, int requestedSeats)
    {
        return GetAvailableSeatsCount(seatClass) >= requestedSeats;
    }
    
    public int GetTotalSeats(string seatClass)
    {
        return seatsByClass[seatClass].Length;
    }

    public decimal GetSeatPrice(string seatClass)
    {
        return seatPrices[seatClass];
    }

    public decimal GetAdjustedPrice(string seatClass, string route)
    {
        // Route distance multiplier
        decimal routeMultiplier = route switch
        {
            "Colombo-Kandy" => 1.0m,
            "Colombo-Galle" => 1.1m,
            "Colombo-Jaffna" => 1.8m,
            "Colombo-Batticaloa" => 1.6m,
            "Colombo-Badulla" => 1.5m,
            _ => 1.0m
        };
        
        return Math.Round(seatPrices[seatClass] * routeMultiplier, 2);
    }
}
