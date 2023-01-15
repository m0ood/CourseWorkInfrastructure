using Microsoft.AspNetCore.Mvc;

namespace WebCourseWork.API.Controllers
{
    [ApiController]
    [Route("PlayerController")]
    public class PlayerController : ControllerBase
    {
        private List<Player> Players = new List<Player>();
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
            Players.Add(new Player("s1mple", "Oleksandr ", "Kostyliev", 25, "Natus Vincere", 1.14));
            Players.Add(new Player("m0NESY", "Ilya", "Osipov", 17, "G2", 1.23));
            Players.Add(new Player("Jame", "Dzhami", "Ali", 24, "Outsiders", 1.18));
            Players.Add(new Player("ZywOo", "Mathieu", "Herbaut", 22, "Vitality", 1.26));
            Players.Add(new Player("ropz", "Robin", "Kool", 23, "FaZe", 1.19));
            Players.Add(new Player("headtr1ck", "Daniil", "Valitov", 18, "Ninjas in Pyjamas", 1.40));
            Players.Add(new Player("npl", "Andrii", "Kukharskyi", 17, "Natus Vincere", 1.09));
        }

        [HttpGet(Name = "GetPlayers")]
        public IEnumerable<Player> GetPlayers()
        {
            return Players.ToArray();
        }
    }
}