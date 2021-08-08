using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood2.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Kategori Adı Boş Geçilemez")]
        [StringLength(20, ErrorMessage="Lütfen  20 karakterden fazla 4 karakterden az isim girişi yapmayınız",MinimumLength =4)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }

        public List<Food> Foods { get; set; }
    }
}
