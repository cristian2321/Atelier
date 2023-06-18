using Atelier.EndPoints;
using Atelier.Services;
using Atelier.Services.Interfaces;

string version = "v1";
string title = "Atelier";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> c.SwaggerDoc(version, 
    new() {Title = title, Version = version }));

builder.Services.AddSingleton<IFichiersJsonService, FichiersJsonService>();
builder.Services.AddSingleton<IPlayerService, PlayerService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet(PlayerEndPoints.GetPlayersUrl, async (IPlayerService playerService, CancellationToken cancellationToken) =>
    await playerService.GetPlayers(cancellationToken));

app.MapGet(PlayerEndPoints.GetPlayerUrl, async (int id, IPlayerService playerService, CancellationToken cancellationToken) =>
    await playerService.GetPlayer(id, cancellationToken));

app.MapGet(PlayerEndPoints.GetPlayersStatsUrl, async (IPlayerService playerService, CancellationToken cancellationToken) =>
    await playerService.GetPlayersStats(cancellationToken));

app.Run();