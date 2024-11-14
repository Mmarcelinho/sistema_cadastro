namespace SistemaCadastro.Application.Shared.Results;

public class Result(int resultCode, string message, bool isOk) : IResult
{
    private List<Notification> _notifications = [];

    public int ResultCode { get; private set; } = resultCode;
    public string Message { get; private set; } = message;
    public bool IsOk { get; private set; } = isOk;
    public object? Data { get; private set; }
    public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

    public void SetNotifications(List<Notification> notifications)
    => _notifications = notifications;

    public void SetData(object data) => Data = data;
}

