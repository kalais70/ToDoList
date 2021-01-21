using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Pages.ToDoList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ToDo> ToDos { get; set; }
        public async Task OnGet()
        {
            ToDos = await _db.ToDo.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ToDo = await _db.ToDo.FindAsync(id);
            if (ToDo==null)
            {
                return NotFound();
            }
            _db.ToDo.Remove(ToDo);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }
    }
}
