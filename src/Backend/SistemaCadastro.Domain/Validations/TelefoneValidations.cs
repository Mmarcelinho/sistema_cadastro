namespace SistemaCadastro.Domain.Validations;

public partial class ContractValidations<T>
{
    public ContractValidations<T> TelefoneIsValid(Telefone telefone, short minLength, short maxLength, string message, string propertyName)
    {
        if ((telefone.Numero.ToString().Length < minLength) || (telefone.Numero.ToString().Length > maxLength))
            AddNotification(new Notification(message, propertyName + " Telefone"));

        return this;
    }

}