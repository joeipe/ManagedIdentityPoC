using ManagedIdentityPoC.Application.Services;
using ManagedIdentityPoC.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.API.Controllers
{
    public class CountryController : CommonController
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IAppService _appService;

        public CountryController(
            ILogger<PersonController> logger,
            IAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCountriesAsync()
        {
            return Response(await _appService.GetAllCountriesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCountryByIdAsync(int id)
        {
            var vm = await _appService.GetCountryByIdAsync(id);

            if (vm == null)
            {
                return ResponseNotFound();
            }

            return Response(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddCountryAsync([FromBody] CountryDto value)
        {
            await _appService.AddCountryAsync(value);

            return Response("", value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCountryAsync([FromBody] CountryDto value)
        {
            await _appService.UpdateCountryAsync(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountryAsync(int id)
        {
            await _appService.DeleteCountryAsync(id);

            return Response();
        }
    }
}
