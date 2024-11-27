using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniDashboard.Models;
using MiniDashboard.Services;

namespace MiniDashboard.Pages
{
    public class EditModel : PageModel
    {
        private readonly TaskService _taskService;
        [BindProperty]
        public TaskItem Task { get; set; }

        public EditModel(TaskService taskService) => _taskService = taskService;

        public IActionResult OnGet(int id)
        {
            Task = _taskService.GetTaskById(id);
            if (Task == null) return RedirectToPage("Task");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _taskService.UpdateTask(Task);
            return RedirectToPage("Task");
        }
    }
}
