using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            return Json(new { data = _db.ToDo.ToList()});
        }
    }
}
