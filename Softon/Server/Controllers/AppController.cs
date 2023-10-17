using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softon.Server.Services;
using Softon.Shared;

namespace Softon.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly IAppServices _appServices;
        public AppController(IAppServices appServices)
        {
            _appServices = appServices;
        }

        [HttpGet("{user}")]
        public async Task<List<AppModel>> Get(string user)
        {
            return await _appServices.GetApps(user);
        }

        [HttpGet("Search")]
        public async Task<List<AppModel>> Search([FromQuery]string search)
        {
            return await _appServices.Search(search);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppModel app)
        {
            await _appServices.Insert(app);
            return CreatedAtAction(nameof(Get), new { Id=app.Id },app);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appServices.Delete(id);
            return NoContent();
        }
    }
}
