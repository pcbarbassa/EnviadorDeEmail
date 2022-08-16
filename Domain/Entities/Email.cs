namespace PCB.EnviadorDeEmail.Domain.Entities
{
    public class Email : Entidade
    {
        private Email() { }

        public Email(string destinatario, string assunto, string mensagem)
        {
            Destinatario = destinatario;
            Assunto = assunto;
            Mensagem = mensagem;
        }

        public string Assunto { get; private set; } = string.Empty;
        public string Destinatario { get; private set; } = string.Empty;
        public string Mensagem { get; private set; } = string.Empty;
    }
}
