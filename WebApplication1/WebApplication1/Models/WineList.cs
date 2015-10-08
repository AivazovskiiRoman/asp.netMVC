using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WineList
    {
        public int ID { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Цвет")]
        public string Color { get; set; }
        [Display(Name = "Срок выдержки (года)")]
        public int TermExposure { get; set; }
        [Display(Name = "Крепость (об.%)")]
        public int Fortress { get; set; }
        [Display(Name = "Цена (руб.)")]
        public decimal Price { get; set; }
    }

    public class WineListDBContext : DbContext
    {
        public DbSet<WineList> Wines { get; set; }
    }
}