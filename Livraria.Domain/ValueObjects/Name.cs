using FluentValidator;

namespace Livraria.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        protected Name(){}

        public Name(string completeName)
        {
            CompleteName = completeName;
            new ValidationContract<Name>(this)
                .IsRequired(x => x.CompleteName, "Nome é obrigatorio")
                .HasMaxLenght(x => CompleteName, 100);
        }

        public string CompleteName { get; private set; }

        public override string ToString()
        {
            return CompleteName;
        }
    }
}