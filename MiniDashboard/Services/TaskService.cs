using System.Collections.Generic;
using System.Linq;
using MiniDashboard.Models;

namespace MiniDashboard.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _task = new();
        private int _nextId = 1;

        public List<TaskItem> GetAllTask() => _task;

        public TaskItem GetTaskById(int id) => _task.FirstOrDefault(t => t.Id == id);

        public void AddTask(TaskItem task)
        {
            task.Id = _nextId++;
            _task.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            var existing = GetTaskById(task.Id);
            if(existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.Status = task.Status;
            }
        }

        public void DeleteTask(int id) => _task.RemoveAll(t => t.Id == id);




    }
}
