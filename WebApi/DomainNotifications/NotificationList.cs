namespace WebApi.DomainNotifications
{
    /// <summary>
    /// Representa uma lista de notificações que carregam informações sobre eventos ou condições.
    /// </summary>
    public class NotificationList
    {
        private List<object> _notifications = new List<object>();

        /// <summary>
        /// Adiciona uma notificação à lista.
        /// </summary>
        /// <param name="notification">A notificação a ser adicionada à lista.</param>
        public void AddNotification(object notification)
        {
            _notifications.Add(notification);
        }

        /// <summary>
        /// Verifica se a lista de notificações possui alguma notificação.
        /// </summary>
        public bool HasNotifications => _notifications.Any();

        /// <summary>
        /// Obtém uma coleção somente leitura de notificações na lista.
        /// </summary>
        public IReadOnlyCollection<object> Notifications => _notifications.AsReadOnly();
    }
}

