namespace PCB.EnviadorDeEmail.Domain.Entities
{
    public abstract class Entidade
    {

        public Entidade()
        {
            Id = Guid.NewGuid(); ;
            DataCriacao = DateTime.UtcNow;
            DataAlteracao = DateTime.UtcNow;
        }

        public static bool operator !=(Entidade a, Entidade b)
        {
            return !(a == b);
        }

        public static bool operator ==(Entidade a, Entidade b)
        {
            if (ReferenceEquals(null, a) && ReferenceEquals(null, b)) return true;
            if (ReferenceEquals(null, a) || ReferenceEquals(null, b)) return false;

            return a.Equals(b);
        }

        public bool Equals(Entidade other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entidade;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public void SetDataAlteracao(DateTime datetime)
        {
            DataAlteracao = datetime;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public DateTime DataAlteracao { get; private set; } = DateTime.UtcNow;

        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

        public Guid Id { get; private set; }

        public string UsuarioAlteracao { get; private set; }

        public string UsuarioCriacao { get; private set; }
    }
}
