using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Model.ApplicationDbContext;
using SistemaEstoque.Model.Entidades;

namespace SistemaEstoque.Services
{
    public class ServiceEstoque : IServiceEstoque
    {
        private readonly Context _context;

        public ServiceEstoque(Context context)
        {
            _context = context;
        }

        public async Task<bool> GetConsultarProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> PostCadastrarFornecedor(Fornecedor fornecedor)
        {
            var addFornecedor = await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PostCadastrarProduto(AdicionarProduto produto)
        {
            var produtos = await _context.Produtos.AddAsync(
                new Produto
                {
                    nome = produto.nome,
                    precoCusto = produto.precoCusto,
                    quantidade = produto.quantidade,
                    fornecedor = produto.fornecedor,
                    categoria = produto.categoria,
                    precoVenda = produto.precoVenda,
                    estoqueMinimo = produto.estoqueMinimo,
                    primeiraEntrada = DateTime.Now
                }
            );
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutEditarProduto(int id, double precoCusto, double precoVenda, Fornecedor fornecedor)
        {
            var editar = await _context.Produtos.FindAsync(id);
            if (editar == null)
            {
                return false;
            }

            editar.precoCusto = precoCusto;
            editar.precoVenda = precoVenda;
            editar.fornecedor = fornecedor;

            return true;
        }

        public async Task<bool> PutRegistrarEntrada(int id, int quantidade)
        {
            var entrada = await _context.Produtos.FindAsync(id);
            if (entrada == null)
            {
                return false;
            }

            entrada.quantidade += quantidade;
            entrada.ultimaEntrada = DateTime.Now;
            return true;
        }

        public async Task<bool> PutRegistrarSaida(int id, int quantidade)
        {
            var saida = await _context.Produtos.FindAsync(id);
            if (saida == null)
            {
                return false;
            }

            if (saida.quantidade <= saida.estoqueMinimo)
            {
                Console.WriteLine("O produto está abaixo do estoque mínimo.");
                return false;
            }
            if (saida.quantidade - quantidade < 0)
            {       
                    Console.WriteLine("A quantidade do produto em estoque é: " + saida.quantidade);
                return false;
            }
            saida.quantidade -= quantidade;
            saida.ultimaEntrada = DateTime.Now;
            return true;
        }

        /*public async Task<ActionResult<Prduto>> GetMovimentação(DateTime periodoInicial)
       {

           // Buscaremos todas as movimentações de entrada e saída de produtos no período informado até o periodo atual
           // ver sobre estabelecer uma formatação de data 
           // gerar um arquivo
       }

       public async Task<ActionResult<Produto>> GetRelatorioDisposição()
       {
           // Ter no arquivo gerado itens: 
           //                             acima do estoque mínimo, abaixo do estoque mínimo e produtos com estoque zerado.
           // mostrará nome quantidade, status (acima do estoque mínimo, abaixo do estoque mínimo e produtos com estoque zerado)
       }*/
    }
}
