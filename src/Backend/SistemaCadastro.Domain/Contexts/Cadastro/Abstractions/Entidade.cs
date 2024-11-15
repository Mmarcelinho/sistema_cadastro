namespace SistemaCadastro.Domain.Contexts.Cadastro.Abstractions;

public abstract class Entidade : IValidate
{
    private List<Notification> _notifications;

    protected Entidade()
    {
        Id = Guid.NewGuid();
        CriadoEmUtc = DateTime.UtcNow;
        _notifications = [];
    }

    public Guid Id { get; }

    public DateTime CriadoEmUtc { get; }

    public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

    public void SetNotificationList(List<Notification> notifications) => _notifications = notifications;

    public abstract bool Validate();
}
