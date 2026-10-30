using SistemaEstoque.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.Model.Entidades
{
    public class AdicionarProduto
    {
        [Display(Name = "Nome do Produto")]
        [Required]
        public string nome { get; set; }

        [Display(Name = "Preço de Custo")]
        [Required]
        public double precoCusto { get; set; }

        [Display(Name = "Quantidade")]
        [Required]
        public int quantidade { get; set; }

        [Display(Name = "Fornecedor")]
        [Required]
        public Fornecedor fornecedor { get; set; }

        [Display(Name = "Categoria")]
        [Required]
        public Categorias categoria { get; set; }

        [Display(Name = "Preço de Venda")]
        [Required]
        public double precoVenda { get; set; }

        [Display(Name = "Estoque Mínimo do produto")]
        [Required]
        public int estoqueMinimo { get; set; }
    }
}
