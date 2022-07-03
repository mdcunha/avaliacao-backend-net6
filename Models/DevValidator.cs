using FluentValidation;

namespace Api.Models
{
    public class DevValidator : AbstractValidator<Dev>
    {

        public DevValidator()
        {
            RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Informe o e-mail")
            .EmailAddress().WithMessage("E-mail inválido")
            .Must(ValidaEmailProsoft).WithMessage("Somente e-mails com domínio Prosoft são válidos");
        }

        private static bool ValidaEmailProsoft(string email)
        {

            var dominioEmail = email.Split('@');
            if (dominioEmail[1] == "prosoft.com.br")
                return true;
            else
                return false;                
        }
    }
}