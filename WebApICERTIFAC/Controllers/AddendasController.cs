using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApICERTIFAC.Models;
using WebApICERTIFAC.DataCtxt;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApICERTIFAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddendasController : ControllerBase
    {
        private readonly DataCtx _context;

        public AddendasController(DataCtx context)
        {
            _context = context;
        }
        // GET: api/<AddendasController>
        [HttpGet]
        public  IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<AddendasController>/5
        [HttpGet("{nombre},{Estado}")]
        public async Task<List<Addendas>> Get(string nombre, int Estado)
        {
            List<Addendas> addendas = new List<Addendas>();
            try
            {
                addendas = await _context.Addendas.FromSqlRaw($"EXEC SP_addenda @OPC=50, @NombreAddenda={nombre}, @Estado={Estado}").ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return addendas;
        }

        // POST api/<AddendasController>
        [HttpPost]
        public async void Post([FromBody] Addendas value)
        {
            try
            {
                await _context.Addendas.FromSqlInterpolated($"EXEC SP_addenda @OPC=1,@IdAddenda={value.IdAddenda}, @NombreAddenda={value.NombreAddenda},@XML={value.XML},@FechaModificacion={value.FechaModificacion},@Usuario={value.Usuario}, @Estado=True").ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // PUT api/<AddendasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddendasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
