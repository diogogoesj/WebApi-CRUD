namespace WebApi.DomainNotifications
{
    /// <summary>
    /// Representa uma notificação que carrega informações sobre algum evento ou condição.
    /// </summary>
    /// <typeparam name="T">O tipo de conteúdo associado à notificação.</typeparam>
    public class Notification<T>
    {
        /// <summary>
        /// Obtém o conteúdo associado à notificação.
        /// </summary>
        public T Content { get; }

        /// <summary>
        /// Obtém a mensagem descritiva da notificação.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Inicializa uma nova instância da classe de notificação com o conteúdo e a mensagem especificados.
        /// </summary>
        /// <param name="content">O conteúdo associado à notificação.</param>
        /// <param name="message">A mensagem descritiva da notificação.</param>
        public Notification(T content, string message)
        {
            Content = content;
            Message = message;
        }
    }
}
