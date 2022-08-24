using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMenu.Entities.Models
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public int Rating { get; set; }
        public int Rate { get; set; }
    }
}
