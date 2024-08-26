namespace SistemaCadastro.Domain.Contexts.Cadastro.Aggregates.ValueObjects;

public sealed record Telefone
{
    private Telefone(long numero, bool celular, bool whatsapp, bool telegram)
    {
        Numero = numero;
        Celular = celular;
        Whatsapp = whatsapp;
        Telegram = telegram;
    }

    public long Numero { get; }

    public bool Celular { get; }

    public bool Whatsapp { get; }

    public bool Telegram { get; }

    public static Telefone Criar(long numero, bool celular, bool whatsapp, bool telegram) =>
    new(numero, celular, whatsapp, telegram);
}