namespace PCB.EnviadorDeEmail.Domain.Commands
{
    public class RespostaGenericaCommandResult : ICommandResultado
    {
        public RespostaGenericaCommandResult() { }
         
        public RespostaGenericaCommandResult(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }

    }
}
