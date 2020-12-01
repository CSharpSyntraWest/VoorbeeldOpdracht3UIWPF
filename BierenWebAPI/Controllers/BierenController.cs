using BierenWebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BierenWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BierenController : ControllerBase
    {
        private readonly ILogger<BierenController> _logger;
        private readonly BierenDbContext _database;

        public BierenController(ILogger<BierenController> logger, BierenDbContext context)
        {
            _logger = logger;
            _database = context;
        }



        [HttpGet]
        [Route("GeefAlleBrouwers")]
        public async Task<IActionResult> GeefAlleBrouwers()
        {
            IList<Brouwers> brouwers = await _database.Brouwers.ToListAsync();
            return Ok(brouwers);
        }

        [HttpGet]
        [Route("GeefAlleBieren")]
        public async Task<IActionResult> GeefAlleBieren() {
            IList<Bieren> bieren = await _database.Bieren.ToListAsync();
            return Ok(bieren);
        }
        [HttpGet]
        [Route("GeefBierVoorID/{id}")]
        public async Task<IActionResult> GeefBierVoorID(int id)
        {
            var bier = await _database.Bieren.FirstOrDefaultAsync<Bieren>((p) => p.BierNr == id);

            if (bier == null)
            {
                return NotFound();
            }

            return Ok(bier);
        }
        [HttpGet]
        [Route("GeefAlleBierSoorten")]
        public async Task<IActionResult> GeefAlleBierSoorten()
        {
            IList<Soorten> biersoorten = await _database.Soorten.ToListAsync();
            return Ok(biersoorten);
        }
        //[HttpPost]
        //[Route("user")]
        //[AllowAnonymous]
        //public IActionResult AddUser([FromBody] Bieren bier)
        //{
        //    _logger.LogInformation("Voeg bier toe }");

        //    _database.Bieren.Add(bier);
        //    return Ok(bier);
        //}

        //[HttpPost]
        //[Route("book")]
        //[AllowAnonymous]
        //public IActionResult AddBook([FromBody] Book book)
        //{
        //    _logger.LogInformation("Add Book for BookId: {BookId}", book.BookId);
        //    _database.AddBook(book);
        //    return Ok(book);
        //}

        //public string AddUser(Users user)
        //{
        //    user.Id = _id++;
        //    userList.Add(user);
        //    return "User added";
        //}

        //public Users GetUserById(int id)
        //{
        //    var user = userList.FirstOrDefault<Users>((p) => p.Id == id);

        //    if (user == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    return user;
        //}

        //public void DeleteUser(int id)
        //{
        //    var user = userList.FirstOrDefault<Users>((p) => p.Id == id);

        //    if (user == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    userList.Remove(user);
        //}
    }
}
