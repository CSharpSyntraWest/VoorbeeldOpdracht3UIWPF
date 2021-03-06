﻿using BierenWebAPI.Data;
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
    public class BierenController : ControllerBase
    {
        private readonly ILogger<BierenController> _logger;
        private readonly IBierenRepository _bierenRepository;

        public BierenController(ILogger<BierenController> logger, IBierenRepository bierenRepository)
        {
            _logger = logger;
            _bierenRepository = bierenRepository;
        }
        // GET api/Bieren/GetAll
        [HttpGet]
        public async Task<IActionResult> GetBieren()
        {
            var bieren = _bierenRepository.GeefBieren();
            return new OkObjectResult(bieren);
        }
        // GET api/Bieren/4
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBier(int id)
        {
            var bier = _bierenRepository.GeefBierVoorID(id);
            return Ok(bier);
        }

        // POST: api/Bieren
        [HttpPost]
        public IActionResult Post([FromBody] Bier bier)
        {
            using (var scope = new TransactionScope())
            {
                _bierenRepository.VoegBierToe(bier);
                scope.Complete();
                return CreatedAtAction(nameof(GetBier), new { id = bier.Id }, bier);
            }
        }

        // PUT: api/Bieren/5
        [HttpPut]
        public IActionResult Put([FromBody] Bier bier)
        {
            if (bier != null)
            {
                using (var scope = new TransactionScope())
                {
                    _bierenRepository.WijzigBier(bier);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/Bieren/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bierenRepository.VerwijderBier(id);
            return new OkResult();
        }
    }
}
