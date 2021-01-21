using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Model;

namespace ToDoList.Pages.ToDoList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ToDo ToDo { get; set; }
        public async Task OnGet(int id)
        {
            ToDo = await _db.ToDo.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var ToDoFromDb = await _db.ToDo.FindAsync(ToDo.Id);
                ToDoFromDb.Name = ToDo.Name;
                ToDoFromDb.Task = ToDo.Task;
                ToDoFromDb.Status = ToDo.Status;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
