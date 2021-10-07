using correspondencia.Context;
using correspondencia.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace correspondencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreoLocalController : ControllerBase
    {
        private readonly AppDbContext context;


        public CorreoLocalController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<correolocal>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try {

                var listCorreo = await context.CorreoLocal.ToListAsync();
                var result = await context.Sp_Consulta.FromSqlRaw("SP_CONSULTA").ToListAsync();

                return Ok(result);

            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<correolocal>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var result = await context.Sp_Consulta.FromSqlRaw("SP_CONSULTARPORID @Id", new SqlParameter("@Id", id)).ToListAsync();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //GET api/<correolocal>/fecha/{fecha}
        [HttpGet("fecha/{fecha}")]
        public async Task<IActionResult> Get(DateTime fecha)
        {
            try
            {
                var result = await context.Sp_Consulta.FromSqlRaw("SP_CONSULTARPORFECHA @Fecha", new SqlParameter("@Fecha", fecha)).ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST api/<correolocal>/id

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CorreoLocal correoLocal)
        {
            try
            {
                context.Add(correoLocal);
                await context.SaveChangesAsync();

                return Ok(correoLocal);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<correolocal>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CorreoLocal correoLocal)
        {


            try { 

                if( id != correoLocal.CorreoLocalID)
                {
                    return NotFound();
                }

                context.Update(correoLocal);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<correolocal>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var correo =  await context.CorreoLocal.FindAsync(id);
                if (correo == null)
                {
                    return NotFound();
                }

                context.CorreoLocal.Remove(correo);

                await context.SaveChangesAsync();

                return Ok(new { message="Se elimino con exito" });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
