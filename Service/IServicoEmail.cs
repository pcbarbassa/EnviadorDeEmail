using PCB.EnviadorDeEmail.Domain.Entities;

namespace PCB.EnviadorDeEmail.Service
{
    public interface IServicoEmail
    {
        void EnviarEmail(Email email);

    }
}
