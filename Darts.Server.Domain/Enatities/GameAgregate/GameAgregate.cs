using Darts.Server.Domain.Enatities.UserAgregate;

namespace Darts.Server.Domain.Enatities.GameAgregate;

public class Game : BaseEntity
{
    public User Owner { get; set; }
    public User CurrentPlayer { get; set; }
    public List<User> Players { get; set; }
    public List<Score> Scores { get; set; }
    public GameStatus Status { get; set; }

    public Game(User owner, List<User> players)
    {
        Owner = owner;
        CurrentPlayer = owner;
        Players = players;

        Scores = new List<Score>();
        foreach (var player in Players)
        {
            Scores.Add(new Score(player, 301));
        }

        Status = GameStatus.Created;
    }

    public void UpdateScore(User player, int scoreValue)
    { 
        if (player != CurrentPlayer) throw new Exception("player is not current");

        var score = Scores.FirstOrDefault(s => s.Owner == player);
        if (score == null) throw new Exception("score not found");

        if (scoreValue > 0)
        {
            score.Update(scoreValue);
        }
        else if (scoreValue == 0)
        {
            score.Update(scoreValue);
            Status = GameStatus.Finished;
        }
    }
}

public class Score : BaseEntity
{
    public User Owner { get; set; }
    public int Value { get; set; }

    public Score(User owner, int value)
    {
        Owner = owner;
        Value = value;
    }

    public void Update(int value)
    { 
        Value = value;
    }
}

public enum GameStatus
{
    Created,
    Running,
    Finished
}
