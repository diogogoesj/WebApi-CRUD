using Microsoft.AspNetCore.Mvc;
using WebApi.DomainNotifications;
using WebApi.Models;
using WebApi.Repository.Interfaces.InterfaceSql;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a produtos em uma Web API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosFromSqlController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationList _notifications = new NotificationList();

        /// <summary>
        /// Inicializa uma nova instância do controlador de produtos com o contexto de unidade de trabalho fornecido.
        /// </summary>
        /// <param name="contexto">A unidade de trabalho que fornece acesso aos repositórios de produtos.</param>
        public ProdutosFromSqlController(IUnitOfWork contexto)
        {
            _unitOfWork = contexto;
        }

        /// <summary>
        /// Obtém uma lista de todos os produtos.
        /// </summary>
        [HttpGet()]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _unitOfWork.ProdutoRepository.Get().ToList();
            if (produtos is null)
            {
                return NotFound("A lista de produtos está vazia.");
            }
            return produtos;
        }

        /// <summary>
        /// Obtém um produto com o ID especificado.
        /// </summary>
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if (produto is null)
            {
                _notifications.AddNotification(new Notification<int>(id, "Produto não encontrado."));
                return NotFound(_notifications.Notifications);
            }
            produto.CalcularValorTotal();
            return produto;
        }

        /// <summary>
        /// Adiciona um novo produto.
        /// </summary>
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            // Valida se o produto é nulo
            if (produto is null)
            {
                _notifications.AddNotification(new Notification<string>("Produto", "Produto não pode ser nulo."));
                return BadRequest(_notifications.Notifications);
            }

            // Valida o produto usando o serviço de validação
            var validationService = new ProdutoValidationService();
            var validationNotifications = validationService.ValidateProduto(produto);

            if (validationNotifications.HasNotifications)
            {
                _notifications.AddNotification(validationNotifications.Notifications);
                return BadRequest(_notifications.Notifications);
            }

            _unitOfWork.ProdutoRepository.Add(produto);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        /// <summary>
        /// Atualiza um produto com o ID especificado.
        /// </summary>
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                _notifications.AddNotification(new Notification<string>("Id", "O Id do produto na URL não corresponde ao Id do produto enviado."));
                return BadRequest(_notifications.Notifications);
            }

            var validationService = new ProdutoValidationService();
            var validationNotifications = validationService.ValidateProduto(produto);

            if (validationNotifications.HasNotifications)
            {
                _notifications.AddNotification(validationNotifications.Notifications);
                return BadRequest(_notifications.Notifications);
            }

            _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();

            return Ok(produto);
        }

        /// <summary>
        /// Exclui um produto com o ID especificado.
        /// </summary>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.GetById(p => p.ProdutoId == id);

            if (produto is null)
            {
                _notifications.AddNotification(new Notification<int>(id, "Produto não encontrado."));
                return NotFound(_notifications.Notifications);
            }

            _unitOfWork.ProdutoRepository.Delete(produto);
            _unitOfWork.Commit();

            return Ok(produto);
        }
    }
}

