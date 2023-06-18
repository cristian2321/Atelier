/*
using Atelier.Dtos;
using Atelier.Services.Interfaces;
using AutoFixture;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Atelier.Services.Tests;

[TestClass()]
public class PlayerServiceTests
{
    private PlayerService _playerService = default!;   
    private IFixture _fixture = default!;
    private IFichiersJsonService _fichiersJsonService = default!;
    private IConfiguration _configuration = default!;

    private const string DecimalDegits = "DecimalDegits";
    private const string CentimetersToMeters = "CentimetersToMeters";
    private const string GramsToKilograms = "GramsToKilograms";
    private const string Section = "Config";

    [TestInitialize]
    public void TestInitialize()
    {
        _configuration = Substitute.For<IConfiguration>();
        _fichiersJsonService = Substitute.For<IFichiersJsonService>();
        _fixture = new Fixture();

        _playerService = new PlayerService(_configuration, _fichiersJsonService);
    }

    [TestMethod]
    public void GetPlayersValideOperationCanceledException()
    {
        // Arrange
        var cancellationToken = new CancellationToken(true);
    
        // Act et Assert
        _ = Assert.ThrowsExceptionAsync<OperationCanceledException>(async () => await _playerService.GetPlayers(cancellationToken));
    }

    [TestMethod]
    public async Task GetPlayersValide()
    {
        // Arrange
        var cancellationToken = new CancellationToken(false);
        var id = _fixture.Create<int>();
        var player = _fixture.Build<PlayerDto>().With(x=>x.Id, id).Create();
        var players = new List<PlayerDto>{ player };
       
        _fichiersJsonService
            .GetPlayersFromJsonFile(cancellationToken)
            .Returns(players);

        // Act
        var playersFromService = await _playerService.GetPlayers(cancellationToken);

        // Assert
        Assert.AreEqual(playersFromService.Select(x=>x.Id).First(), id);
    }

    [TestMethod]
    public async Task GetPlayerValide()
    {
        // Arrange
        var cancellationToken = new CancellationToken(false);
        var id = _fixture.Create<int>();
        var player = _fixture.Build<PlayerDto>().With(x => x.Id, id).Create();
        var players = new List<PlayerDto> { player };

        _fichiersJsonService
            .GetPlayersFromJsonFile(cancellationToken)
            .Returns(players);

        // Act
        var playerFromService = await _playerService.GetPlayer(id, cancellationToken);

        // Assert
        Assert.AreEqual(playerFromService!.Id, id);
    }

    [TestMethod]
    public void GetPlayerOperationCanceledException()
    {
        // Arrange
        var cancellationToken = new CancellationToken(true);
        var id = _fixture.Create<int>();

        // Act et Assert
        _ = Assert.ThrowsExceptionAsync<OperationCanceledException>(async () => await _playerService.GetPlayer(id, cancellationToken));
    }

    [TestMethod]
    public async Task GetPlayerStatsValide()
    {
        // Arrange
        var cancellationToken = new CancellationToken(false);
        var id = _fixture.Create<int>();
        var player = _fixture.Build<PlayerDto>().With(x => x.Id, id).Create();
        var players = new List<PlayerDto> { player };

        _fichiersJsonService
            .GetPlayersFromJsonFile(cancellationToken)
            .Returns(players);

        _configuration.GetSection(Section)[GramsToKilograms].Returns("1000");
        _configuration.GetSection(Section)[CentimetersToMeters].Returns("100"); 
        _configuration.GetSection(Section)[DecimalDegits].Returns("4");

        // Act
        var playerFromService = await _playerService.GetPlayersStats(cancellationToken);

        // Assert
        Assert.IsNotNull(playerFromService);
    }

    [TestMethod]
    public void GetPlayerStatsNonValideLanceDivideByZeroException()
    {
        // Arrange
        var cancellationToken = new CancellationToken(false);
        var id = _fixture.Create<int>();
        var player = _fixture.Build<PlayerDto>().With(x => x.Id, id).Create();
        var players = new List<PlayerDto> { player };

        _fichiersJsonService
            .GetPlayersFromJsonFile(cancellationToken)
            .Returns(players);

        _configuration.GetSection(Section)[GramsToKilograms].Returns("1000");
        _configuration.GetSection(Section)[CentimetersToMeters].Returns("0");
        _configuration.GetSection(Section)[DecimalDegits].Returns("4");

        // Act
        _ = Assert.ThrowsExceptionAsync<DivideByZeroException>(async () => await _playerService.GetPlayersStats(cancellationToken));
    }

    [TestMethod]
    public void GetPlayerStatsOperationCanceledException()
    {
        // Arrange
        var cancellationToken = new CancellationToken(true);

        // Act et Assert
        _ = Assert.ThrowsExceptionAsync<OperationCanceledException>(async () => await _playerService.GetPlayersStats(cancellationToken));
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _fixture = default!;
        _fichiersJsonService = default!;
        _configuration = default!;
    }
}*/