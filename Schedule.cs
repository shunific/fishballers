using System;

namespace InventoryManagementSystem
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Schedule(DateTime date, string name, string description)
        {
            Date = date;
            Name = name;
            Description = description;
        }
    }
}