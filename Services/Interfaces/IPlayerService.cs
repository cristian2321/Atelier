using Atelier.Dtos;

namespace Atelier.Services.Interfaces;

public interface IPlayerService
{
    Task<List<PlayerDto>> GetPlayers(CancellationToken cancellationToken);

    Task<PlayerDto?> GetPlayer(int id, CancellationToken cancellationToken);

    Task<PlayersStatsDto> GetPlayersStats(CancellationToken cancellationToken);
}