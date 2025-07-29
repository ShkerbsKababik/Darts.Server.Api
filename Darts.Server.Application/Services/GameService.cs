using Darts.Server.Application.DTO;
using Darts.Server.Domain.Enatities.GameAgregate;
using Darts.Server.Domain.Interfaces;

namespace Darts.Server.Application.Services;

public interface IGameService
{
    GameDTO GetGameById(Guid id);
    void CreateGame(GameCreationDTO gameCreationDTO);
    void UpdateScore(UpdateScoreDTO updateScoreDTO);
}

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IUserRepository _userRepository;

    public GameService(
        IGameRepository gameRepository,
        IUserRepository userRepository)
    {
        _gameRepository = gameRepository;
        _userRepository = userRepository;
    }

    public void CreateGame(GameCreationDTO gameCreationDTO)
    {
        var owner = _userRepository.GetUserById(gameCreationDTO.OwnerId);
        if (owner is null) throw new Exception("owner not found");

        var players = _userRepository.GetUsersByIds(gameCreationDTO.PlayerIds);
        if (players.Count != gameCreationDTO.PlayerIds.Count) throw new Exception("one of users not found");

        var game = new Game(owner, players);
        _gameRepository.CreateGame(game);
    }

    public GameDTO GetGameById(Guid id)
    {
        var game = _gameRepository.GetGameById(id) 
            ?? throw new Exception("game not found");

        return GameDTO.FromDomain(game);
    }

    public void UpdateScore(UpdateScoreDTO updateScoreDTO)
    {
        var game = _gameRepository.GetGameById(updateScoreDTO.GameId)
            ?? throw new Exception("game not found");

        var player = _userRepository.GetUserById(updateScoreDTO.PlayerId)
            ?? throw new Exception("user not found");

        game.UpdateScore(player, updateScoreDTO.Value);
        _gameRepository.UpdateGame(game);
    }
}
