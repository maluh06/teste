using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Model.Entidades;

namespace SistemaEstoque.Services
{
    public interface IServiceEstoque
    {
        Task<bool> PostCadastrarProduto(AdicionarProduto produto);
        Task<bool> PutEditarProduto(int id, double precoCusto, double precoVenda, Fornecedor fornecedor);
        Task<bool> GetConsultarProduto(int id);
        Task<bool> PostCadastrarFornecedor(Fornecedor fornecedor);
        Task<bool> PutRegistrarSaida(int id, int quantidade);
        Task<bool> PutRegistrarEntrada(int id, int quantidade);
        /*Task<ActionResult<Produto>> GetRelatorioDisposição();
        Task<ActionResult<Produto>> GetMovimentação(DateTime periodoInicial);*/
    }
}
