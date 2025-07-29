using Darts.Server.Domain.Enatities.GameAgregate;
using Darts.Server.Domain.Interfaces;
using Darts.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Darts.Server.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly DartsDbContext _dartsDbContext;

    public GameRepository(DartsDbContext dartsDbContext)
    {
        _dartsDbContext = dartsDbContext;
    }

    public void CreateGame(Game game)
    {
        _dartsDbContext.Games.Add(game);
        _dartsDbContext.SaveChanges();
    }

    public Game GetGameById(Guid id)
    {
        return _dartsDbContext.Games
            .Include(g => g.Owner)
            .Include(g => g.CurrentPlayer)
            .Include(g => g.Players)
            .Include(g => g.Scores)
            .FirstOrDefault(g => g.Id == id);
    }

    public void UpdateGame(Game game)
    {
        _dartsDbContext.Games.Update(game);
        _dartsDbContext.SaveChanges();
    }
}
