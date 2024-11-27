using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniDashboard.Models;
using MiniDashboard.Services;

namespace MiniDashboard.Pages
{
    public class TaskModel : PageModel
    {
        private readonly TaskService _taskService;
        [BindProperty(SupportsGet = true)]
        public string Status { get; set; } // Status filter, e.g., "Pending", "Completed"

        public List<TaskItem> Tasks { get; set; } // List of tasks
        public TaskModel(TaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult OnGet()
        {
            var tasklist = _taskService.GetAllTask();
            // Filter tasks based on the Status parameter
            if (!string.IsNullOrEmpty(Status))
            {
                Tasks = tasklist.Where(t => t.Status.Equals(Status, StringComparison.OrdinalIgnoreCase)).ToList();
                
              
            }
            else
            {
                Tasks = tasklist; // Show all tasks if no filter is applied
            }
            return Page();
        }
    }
}
