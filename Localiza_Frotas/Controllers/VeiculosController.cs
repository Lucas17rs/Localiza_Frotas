using Localiza_Frotas_Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza_Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository veiculoRepository;
        //private readonly IVeiculoDetran veiculoDetran;
        public VeiculosController(IVeiculoRepository repository /*, IVeiculoDetran veiculoDetran*/)
        {
            this.veiculoRepository = repository;
            //this.veiculoDetran = veiculoDetran;
        }

        // GET: api/<VeiculosController>
        [HttpGet]
        public IActionResult Get() => Ok(veiculoRepository.GetAll());

        // GET api/<VeiculosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = veiculoRepository.GetById(id);
            if (veiculo == null)
                return NotFound();
            return Ok(veiculo);
        }

        // POST api/<VeiculosController>
        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            veiculoRepository.Add(veiculo);
            return CreatedAtAction(nameof(Get), new { id = veiculo.Id }, veiculo);
        }

        // PUT api/<VeiculosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Veiculo veiculo)
        {
            var veiculo0 = veiculoRepository.GetById(id);
            if (veiculo0 == null)
                return NotFound();

            veiculoRepository.Update(veiculo);

            return NoContent();
        }

        // DELETE api/<VeiculosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var veiculo = veiculoRepository.GetById(id);
            if (veiculo == null)
                return NotFound();

            veiculoRepository.Delete(veiculo);

            return NoContent();
        }

    }//
}
