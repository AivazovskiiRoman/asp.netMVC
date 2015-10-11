using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WineCatalog.Frontend.Models
{
    [Table("WineCatalogs")]
    public class WineCatalogModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Срок выдержки (года)")]
        public int TermExposure { get; set; }

        [Required]
        [Display(Name = "Крепость (об.%)")]
        public int Fortress { get; set; }

        [Required]
        [Display(Name = "Цена (руб.)")]
        public decimal Price { get; set; }
    }

    public class WineCatalogDBContext : DbContext
    {
        public DbSet<WineCatalogModel> WineCatalogs { get; set; }
    }
}