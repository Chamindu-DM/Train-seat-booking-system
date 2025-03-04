using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Routes
{
    public Dictionary<string, List<TrainSchedule>> RouteSchedules { get; }

    public Routes()
    {
        RouteSchedules = new Dictionary<string, List<TrainSchedule>>
        {
            {
                "Colombo-Kandy", new List<TrainSchedule>
                {
                    new TrainSchedule("Morning Express", "06:00"),
                    new TrainSchedule("Mid Morning", "09:00"),
                    new TrainSchedule("Afternoon Express", "14:00"),
                    new TrainSchedule("Evening Train", "17:00"),
                    new TrainSchedule("Night Mail", "20:00")
                }
            },
            {
                "Colombo-Galle", new List<TrainSchedule>
                {
                    new TrainSchedule("Coast Line Early", "05:30"),
                    new TrainSchedule("Coast Line Morning", "08:30"),
                    new TrainSchedule("Coast Line Noon", "12:30"),
                    new TrainSchedule("Coast Line Evening", "16:30"),
                    new TrainSchedule("Coast Line Night", "19:30")
                }
            },
            {
                "Colombo-Jaffna", new List<TrainSchedule>
                {
                    new TrainSchedule("Yal Devi Morning", "04:30"),
                    new TrainSchedule("Northern Express", "07:30"),
                    new TrainSchedule("Jaffna Special", "11:30"),
                    new TrainSchedule("Evening Express", "15:30"),
                    new TrainSchedule("Night Mail", "18:30")
                }
            },
            {
                "Colombo-Batticaloa", new List<TrainSchedule>
                {
                    new TrainSchedule("Eastern Morning", "05:00"),
                    new TrainSchedule("Batticaloa Express", "08:00"),
                    new TrainSchedule("Mid-Day Special", "12:00"),
                    new TrainSchedule("Evening Train", "16:00"),
                    new TrainSchedule("Night Service", "19:00")
                }
            },
            {
                "Colombo-Badulla", new List<TrainSchedule>
                {
                    new TrainSchedule("Upcountry Morning", "05:45"),
                    new TrainSchedule("Podi Menike", "08:45"),
                    new TrainSchedule("Hill Country Express", "11:45"),
                    new TrainSchedule("Evening Service", "15:45"),
                    new TrainSchedule("Night Mail", "18:45")
                }
            }
        };
    }
}