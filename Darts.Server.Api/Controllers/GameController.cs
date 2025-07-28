using Darts.Server.Application.DTO;
using Darts.Server.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Darts.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("/game/{id}")]
        public GameDTO GetGame(Guid id)
        {
            return _gameService.GetGameById(id);
        }

        [HttpPost("/game/add")]
        public void CreateUser(GameCreationDTO gameCreationDTO)
        {
            _gameService.CreateGame(gameCreationDTO);
        }

        [HttpPut("/game/score")]
        public void ChangeUserPassword(UpdateScoreDTO updateScoreDTO)
        {
            _gameService.UpdateScore(updateScoreDTO);
        }
    }
}
