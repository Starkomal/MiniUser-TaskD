﻿namespace MiniDashboard.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //Pending, In Progress, Completed
    }
}
