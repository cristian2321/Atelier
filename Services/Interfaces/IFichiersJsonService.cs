using Atelier.Dtos;

namespace Atelier.Services.Interfaces
{
    public interface IFichiersJsonService
    {
        Task<List<PlayerDto>> GetPlayersFromJsonFile(CancellationToken cancellationToken);
    }
}
