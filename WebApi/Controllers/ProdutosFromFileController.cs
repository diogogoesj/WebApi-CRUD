using Microsoft.AspNetCore.Mvc;
using WebApi.DomainNotifications;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Controlador que lida com operações relacionadas a produtos armazenados em um arquivo de texto.
    /// </summary>
    public class ProdutosFromFileController : ControllerBase
    {
        private TextFileRepository<Produto> fileRepository;
        private ProdutoValidationService produtoValidationService;

        /// <summary>
        /// Inicializa uma nova instância do controlador de produtos baseado em arquivos de texto.
        /// </summary>
        public ProdutosFromFileController()
        {
            fileRepository = new TextFileRepository<Produto>("./saveFiles/produtos.json");
            produtoValidationService = new ProdutoValidationService();
        }

        /// <summary>
        /// Obtém todos os produtos armazenados no arquivo de texto.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = fileRepository.GetAll();
            return Ok(produtos);
        }

        /// <summary>
        /// Obtém um produto específico com base em seu ID a partir do arquivo de texto.
        /// </summary>
        /// <param name="id">O ID do produto a ser obtido.</param>
        [HttpGet("{id:int}", Name = "ObterProdutoText")]
        public ActionResult<Produto> Get(int id)
        {
            var produtos = fileRepository.GetAll();
            var produto = produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado ou valor inválido.");
            }

            produto.CalcularValorTotal();
            return produto;
        }

        /// <summary>
        /// Adiciona um novo produto ao arquivo de texto.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado.</param>
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            var notifications = produtoValidationService.ValidateProduto(produto);

            if (notifications.HasNotifications)
            {
                return BadRequest(notifications.Notifications);
            }

            var produtos = fileRepository.GetAll();
            produto.ProdutoId = produtos.Count > 0 ? produtos.Max(p => p.ProdutoId) + 1 : 1;
            produtos.Add(produto);
            fileRepository.SaveAll(produtos);

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        /// <summary>
        /// Atualiza um produto específico no arquivo de texto com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser atualizado.</param>
        /// <param name="produto">O produto com as informações atualizadas.</param>
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            var notifications = new NotificationList(); // Crie uma nova lista de notificações

            if (produto == null || produto.Preco < 0 || id != produto.ProdutoId)
            {
                if (produto == null)
                {
                    notifications.AddNotification(new Notification<Produto>(produto, "Produto inválido (nulo)."));
                }
                if (produto.Preco < 0)
                {
                    notifications.AddNotification(new Notification<decimal>(produto.Preco, "O preço do produto não pode ser negativo."));
                }
                if (id != produto.ProdutoId)
                {
                    notifications.AddNotification(new Notification<int>(id, "O ID do produto na URL não corresponde ao ID do produto enviado."));
                }

                return BadRequest(notifications.Notifications);
            }

            var produtos = fileRepository.GetAll();
            var existingProduto = produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (existingProduto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            existingProduto.Nome = produto.Nome;
            existingProduto.Preco = produto.Preco;
            existingProduto.Estoque = produto.Estoque;
            existingProduto.DataCadastro = produto.DataCadastro;

            fileRepository.SaveAll(produtos);

            return Ok(existingProduto);
        }

        /// <summary>
        /// Remove um produto específico do arquivo de texto com base em seu ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser removido.</param>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produtos = fileRepository.GetAll();
            var produto = produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            produtos.Remove(produto);
            fileRepository.SaveAll(produtos);

            return Ok(produto);
        }
    }
}

