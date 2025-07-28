using Darts.Server.Domain.Enatities.GameAgregate;

namespace Darts.Server.Domain.Interfaces;

public interface IGameRepository
{
    public Game GetGameById(Guid id);
    public void CreateGame(Game game);
    public void UpdateGame(Game game);
}
