using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.DTOs
{
    public class CategoriaDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O Nome é Requerido")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
