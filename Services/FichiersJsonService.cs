using Atelier.Dtos;
using System.Reflection;
using System.Text.Json;

namespace Atelier.Services;

public static class FichiersJsonService 
{
    private const string Key = "FileName";
    private const string Section = "File";

    public static async Task<List<PlayerDto>> GetPlayersFromJsonFile(CancellationToken cancellationToken, IConfiguration configuration)
    {
        var fileName = configuration.GetRequiredSection(Section)[Key];

        string cheminDAcces = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!, fileName);
        
        string contenu = await File.ReadAllTextAsync(cheminDAcces, cancellationToken);
        
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        return JsonSerializer.Deserialize<PlayersJsonFileDto>(contenu, options)!.Players;
    }
}