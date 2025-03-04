using System;
using System.Collections.Generic;
using System.Linq;

class TrainSchedule
{
    public string Name { get; }
    public string Time { get; }
    private bool[] seats;

    public TrainSchedule(string name, string time, int seatCount)
    {
        Name = name;
        Time = time;
        seats = new bool[seatCount]; // false = available, true = booked
    }

    public bool IsSeatBooked(int seatNumber) => seats[seatNumber];

    public void ToggleSeat(int seatNumber)
    {
        seats[seatNumber] = !seats[seatNumber];
    }

    public List<int> GetBookedSeats()
    {
        var bookedSeats = new List<int>();
        for (int i = 0; i < seats.Length; i++)
            if (seats[i])
                bookedSeats.Add(i);
        return bookedSeats;
    }

    public int GetAvailableSeatsCount()
    {
        return seats.Count(seat => !seat);
    }

    public bool HasEnoughAvailableSeats(int requestedSeats)
    {
        return GetAvailableSeatsCount() >= requestedSeats;
    }
}
