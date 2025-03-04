using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

class ViewSchedule
{
    private readonly Routes _routes;

    public ViewSchedule(Routes routes)
    {
        _routes = routes;
    }

    public void DisplaySchedules()
    {
        foreach (var route in _routes.RouteSchedules)
        {
            Console.WriteLine($"\nRoute: {route.Key}");
            foreach (var schedule in route.Value)
            {
                Console.WriteLine($"- {schedule.Name} at {schedule.Time}");
            }
        }
    }
}