using ManagedIdentityPoC.Application.Services;
using ManagedIdentityPoC.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ManagedIdentityPoC.API.Controllers
{
    public class PersonController : CommonController
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IAppService _appService;

        public PersonController(
            ILogger<PersonController> logger,
            IAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPerson()
        {
            return Response(await _appService.GetAllPersonAsync());
        }

        [HttpGet("{partitionKey}/{rowKey}")]
        public async Task<ActionResult> GetPersonById(string partitionKey, string rowKey)
        {
            var vm = await _appService.GetPersonByIdAsync(partitionKey, rowKey);

            if (vm == null)
            {
                return ResponseNotFound();
            }

            return Response(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddPersonAsync([FromBody] PersonDto value)
        {
            await _appService.AddPersonAsync(value);

            return Response("", value);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonAsync([FromBody] PersonDto value)
        {
            await _appService.UpdatePersonAsync(value);

            return Response();
        }

        [HttpDelete("{partitionKey}/{rowKey}")]
        public async Task<ActionResult> DeletePersonAsync(string partitionKey, string rowKey)
        {
            await _appService.DeletePersonAsync(partitionKey, rowKey);

            return Response();
        }
    }
}