using WebApi.Models;

namespace WebApi.DomainNotifications
{
    /// <summary>
    /// Serviço de validação de produtos que verifica se um objeto de produto atende a critérios específicos.
    /// </summary>
    public class ProdutoValidationService
    {
        /// <summary>
        /// Valida um objeto de produto e retorna uma lista de notificações, se houver problemas de validação.
        /// </summary>
        /// <param name="produto">O objeto de produto a ser validado.</param>
        /// <returns>Uma lista de notificações contendo problemas de validação, se houver.</returns>
        public NotificationList ValidateProduto(Produto produto)
        {
            var notifications = new NotificationList();

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                notifications.AddNotification(new Notification<string?>(produto.Nome, "Nome do produto é obrigatório."));
            }

            if (produto.Preco < 0)
            {
                notifications.AddNotification(new Notification<decimal>(produto.Preco, "O preço do produto não pode ser negativo."));
            }

            if (produto.Estoque < 0)
            {
                notifications.AddNotification(new Notification<float>(produto.Estoque, "O estoque do produto não pode ser negativo."));
            }

            return notifications;
        }
    }
}

