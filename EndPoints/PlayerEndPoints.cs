namespace Atelier.EndPoints;

public  static class PlayerEndPoints
{
    internal const string IndexPlayersUrl = "/Players";
    internal const string GetPlayersUrl = $"{IndexPlayersUrl}/GetPlayers";
    internal const string GetPlayerUrl = IndexPlayersUrl + "/GetPlayer/{id}";
    internal const string GetPlayersStatsUrl = IndexPlayersUrl + "/GetPlayersStats";
}