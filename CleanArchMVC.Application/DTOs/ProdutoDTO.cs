using CleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.DTOs
{
    public class ProdutoDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O Nome é Requerido")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição é Requerida")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é Requerido")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preco")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O Estoque é Requerido")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Estoque { get; set; }

        [MaxLength(250)]
        [DisplayName("Imagem do Produto")]
        public string Imagem { get; set; }
        public long CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
