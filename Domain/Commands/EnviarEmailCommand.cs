namespace PCB.EnviadorDeEmail.Domain.Commands
{
    public class EnviarEmailCommand : Notifiable<Notification>, ICommand
    {
        public EnviarEmailCommand(string assunto, string destinatario, string mensagem)
        {
            Assunto = assunto;
            Destinatario = destinatario;
            Mensagem = mensagem;
        }

        public string Assunto { get; private set; } = string.Empty;
        public string Destinatario { get; private set; } = string.Empty;
        public string Mensagem { get; private set; } = string.Empty;

        public void Validar()
        {
            AddNotifications(new Contract<EnviarEmailCommand>()
                .Requires()
                    .IsEmail(Destinatario, "Destinatario", "Email do destinatário invalido")
                    .IsNotNullOrEmpty(Assunto, "Asssunto", "O assunto precisa ser informado")
                    .IsNotNullOrEmpty(Mensagem, "Mensagem", "Uma mensagem precisa ser informada")
                    .IsGreaterOrEqualsThan(Mensagem.Split(' ').Length, 3, "Mensagem", "Mensagem precisa ter no minimo 3 palavras")
                    .IsGreaterOrEqualsThan(Assunto.Split(' ').Length, 1, "Mensagem", "Mensagem precisa ter no minimo 1 palavra"));
        }
    }
}
