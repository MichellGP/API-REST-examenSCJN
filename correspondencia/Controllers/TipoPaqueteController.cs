using correspondencia.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace correspondencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPaqueteController : Controller
    {

        private readonly AppDbContext context;

        public TipoPaqueteController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        // GET: TipoPaqueteController
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListTipoPaquete = await context.TipoPaquete.ToListAsync();
                return Ok(ListTipoPaquete);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
