using PCB.EnviadorDeEmail.Domain.Commands;
using PCB.EnviadorDeEmail.Domain.Entities;
using PCB.EnviadorDeEmail.Service;

namespace PCB.EnviadorDeEmail.Domain.Handlers
{
    public class ManipuladorDeEmail
    {
        public readonly IServicoEmail _servicoEmail;
        public ManipuladorDeEmail(IServicoEmail emailService)
        {
            _servicoEmail = emailService;
        }

        public ICommandResultado Manipular(EnviarEmailCommand command)
        {
            command.Validar();
            if (!command.IsValid)
                return new RespostaGenericaCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Criar um email
            var NovoEmail = new Email(command.Destinatario, command.Assunto, command.Mensagem);

            //Enviar o e-mail
            _servicoEmail.EnviarEmail(NovoEmail);

            //Notificar o usuario
            return new RespostaGenericaCommandResult(true, "O email foi enviado com sucesso.", NovoEmail);
        }

    }
}
