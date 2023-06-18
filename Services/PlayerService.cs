using Atelier.Dtos;
using Atelier.Services.Interfaces;

namespace Atelier.Services;

public class PlayerService : IPlayerService
{
    private readonly IFichiersJsonService _fichiersJsonService;
    private readonly IConfiguration _configuration;

    public PlayerService(IConfiguration configuration, IFichiersJsonService fichiersJsonService)
    {
        _configuration = configuration;
        _fichiersJsonService = fichiersJsonService; 
    }

    private const string DecimalDegits = "DecimalDegits";
    private const string CentimetersToMeters = "CentimetersToMeters";
    private const string GramsToKilograms = "GramsToKilograms";
    private const string Section = "Config";

    public async Task<PlayerDto?> GetPlayer(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return (await _fichiersJsonService.GetPlayersFromJsonFile(cancellationToken))
            .FirstOrDefault(x => x.Id == id);
    }

    public async Task<List<PlayerDto>> GetPlayers(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return (await _fichiersJsonService.GetPlayersFromJsonFile(cancellationToken))
            .OrderBy(x => x.Data.Rank).ToList();
    }

    public async Task<PlayersStatsDto> GetPlayersStats(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var playersFromJson = await _fichiersJsonService.GetPlayersFromJsonFile(cancellationToken);

        return playersFromJson.Any() ?
            new() 
            {
                Country = GetCountry(playersFromJson) ?? default!,
                IMC =GetImc(playersFromJson),
                Median =GetMedian(playersFromJson)
            }:
        default!;
    }

    private static CountryDto ? GetCountry(List<PlayerDto> players)
    {
        var query = (from p in players
                    group p by new 
                    { 
                        p.Country, 
                        p.Data.Last
                    } 
                    into pGroupByCountry
                    select new
                    {
                        pGroupByCountry.Key.Country,
                        Wins = pGroupByCountry.Key.Last.Sum(),
                        Matchs = pGroupByCountry.Key.Last.Count,
                    }).ToList();

        var resultat = query
            .Select(x => new { x.Country, Total = x.Matchs == 0 ? 0 : x.Wins / x.Matchs });

        return resultat.OrderByDescending(x => x.Total)
            .Select(x => x.Country)
            .FirstOrDefault();
    }
    
    private decimal GetImc(List<PlayerDto> players)
    {
        _ = int.TryParse(_configuration.GetSection(Section)[GramsToKilograms], out int gramsToKilograms);
        _ = int.TryParse(_configuration.GetSection(Section)[CentimetersToMeters], out int centimeterToMeter);
        _ = int.TryParse(_configuration.GetSection(Section)[DecimalDegits], out int decimalDegits);

        var query = players.Select(x => 
            new 
            { 
                x.Id, 
                Weight = Convert.ToDecimal(x.Data.Weight) / gramsToKilograms,
                Height = Convert.ToDecimal(x.Data.Height) / centimeterToMeter
            });

        var resultat = query.Select(x => new { x.Id, IMC = Math.Round(x.Weight / (x.Height * x.Height), decimalDegits) });

        return Math.Round(resultat.Select(x => x.IMC).Sum() / players.Count,4);
    }

    private static int GetMedian(List<PlayerDto> players)
    {
        var heights = players.Select(x => x.Data.Height).OrderBy(x => x).ToList();

        double mid = (heights.Count - 1) / 2.0;

        return (heights[(int)mid] + heights[(int)(mid + 0.5)]) / 2;
    }
}