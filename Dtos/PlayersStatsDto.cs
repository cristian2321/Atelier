namespace Atelier.Dtos;

public class PlayersStatsDto
{
    public CountryDto Country { get; set; } = default!;

    public decimal IMC { get; set; }

    public int Median { get; set; }
}