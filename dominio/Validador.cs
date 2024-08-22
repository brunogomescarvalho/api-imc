
using FluentValidation;

namespace dominio
{
    public class Validador : AbstractValidator<CalculoImc>
    {
        public Validador()
        {
            RuleFor(x => x.Altura).GreaterThan(0);
            RuleFor(x => x.Peso).GreaterThan(0);
        }
    }
}