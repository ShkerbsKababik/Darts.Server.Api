using Darts.Server.Domain.Enatities.GameAgregate;

namespace Darts.Server.Application.DTO;

public class GameDTO
{
    public UserDTO Owner { get; set; }
    public UserDTO CurrentPlayer { get; set; }
    public List<UserDTO> Players { get; set; }
    public List<ScoreDTO> Scores { get; set; }
    public GameStatus Status { get; set; }

    public static GameDTO FromDomain(Game game)
    {
        return new GameDTO()
        {
            Owner = UserDTO.FromDomain(game.Owner),
            CurrentPlayer = UserDTO.FromDomain(game.CurrentPlayer),
            Players = game.Players.Select(UserDTO.FromDomain).ToList(),
            Scores = game.Scores.Select(ScoreDTO.FromDomain).ToList(),
            Status = game.Status
        };
    }
}

public class GameCreationDTO
{ 
    public Guid OwnerId { get; set; }
    public List<Guid> PlayerIds { get; set; }
}

public class UpdateScoreDTO
{
    public Guid GameId { get; set; }
    public Guid PlayerId { get; set; }
    public int Value { get; set; }
}

public class ScoreDTO
{ 
    public Guid OwnerId { get; set; }
    public int Value { get; set; }

    public static ScoreDTO FromDomain(Score score)
    {
        return new ScoreDTO()
        {
            OwnerId = score.Owner.Id,
            Value = score.Value,
        };
    }
}
