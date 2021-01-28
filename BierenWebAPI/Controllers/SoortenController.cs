using BierenWebAPI.Data;
using BierenWebAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BierenWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoortenController : ControllerBase
    {
        private readonly ILogger<BierenController> _logger;
        private readonly ISoortenRepository _soortenRepository;

        public SoortenController(ILogger<BierenController> logger, ISoortenRepository soortenRepository)
        {
            _logger = logger;
            _soortenRepository = soortenRepository;
        }
        // GET api/Soorten
        [HttpGet]
        public async Task<IActionResult> GetSoorten()
        {
            var soorten = _soortenRepository.GeefSoorten();
            return new OkObjectResult(soorten);
        }
        // GET api/Soorten/4
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSoort(int id)
        {
            var soort = _soortenRepository.GeefSoortVoorID(id);
            return Ok(soort);
        }

        // POST: api/Soorten
        [HttpPost]
        public IActionResult Post([FromBody] Soort soort)
        {
            using (var scope = new TransactionScope())
            {
                _soortenRepository.VoegSoortToe(soort);
                scope.Complete();
                return CreatedAtAction(nameof(GetSoort), new { id = soort.Id }, soort);
            }
        }

        // PUT: api/Soorten/5
        [HttpPut]
        public IActionResult Put([FromBody] Soort soort)
        {
            if (soort != null)
            {
                using (var scope = new TransactionScope())
                {
                    _soortenRepository.WijzigSoort(soort);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/Soorten/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _soortenRepository.VerwijderSoort(id);
            return new OkResult();
        }
    }
}
