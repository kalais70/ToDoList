using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class ToDo
    {
       [Key] 
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
    }
}
