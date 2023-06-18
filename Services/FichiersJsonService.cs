using Atelier.Dtos;
using Atelier.Services.Interfaces;
using System.Reflection;
using System.Text.Json;

namespace Atelier.Services;

public class FichiersJsonService : IFichiersJsonService
{
    private readonly IConfiguration _configuration;

    public FichiersJsonService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private const string Key = "FileName";
    private const string Section = "File";

    public async Task<List<PlayerDto>> GetPlayersFromJsonFile(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var fileName = _configuration.GetRequiredSection(Section)[Key];

        string cheminDAcces = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, fileName);
        
        string contenu = await File.ReadAllTextAsync(cheminDAcces, cancellationToken);
        
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        return JsonSerializer.Deserialize<PlayersJsonFileDto>(contenu, options)!.Players;
    }
}