using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniDashboard.Models;
using MiniDashboard.Services;


namespace MiniDashboard.Pages
{
    public class CreateModel : PageModel
    {
        private readonly TaskService _taskService;
        [BindProperty]
        public TaskItem Task { get; set; } = new();

        public CreateModel(TaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _taskService.AddTask(Task);
            return RedirectToPage("Task");
             
        }
    }
}
