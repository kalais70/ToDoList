using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Controllers
{
    [Route("api/ToDo")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToDoController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _db.ToDo.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var todoFromDb =await _db.ToDo.FirstOrDefaultAsync(u => u.Id == id);
            if (todoFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _db.ToDo.Remove(todoFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted Successful" });
        }
    }
}
