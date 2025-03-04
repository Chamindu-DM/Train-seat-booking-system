using System;
using System.Collections.Generic;
using System.Linq;

class TrainSchedule
{
    public string Name { get; }
    public string Time { get; }
    private Dictionary<string, bool[]> seatsByClass;
    
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
}
