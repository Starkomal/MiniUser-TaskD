using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniDashboard.Models;
using MiniDashboard.Services;

namespace MiniDashboard.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly TaskService _taskService;
        [BindProperty]
        public TaskItem Task { get; set; }

        public DeleteModel(TaskService taskService) => _taskService = taskService;

        public IActionResult OnGet(int id)
        {
            Task = _taskService.GetTaskById(id);
            if (Task == null) return RedirectToPage("Task");
            return Page();
        }

        public IActionResult OnPost()
        {
            _taskService.DeleteTask(Task.Id);
            return RedirectToPage("Task");
        }
    }
}
