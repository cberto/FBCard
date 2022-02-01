using FBCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly AplicationDbContext _contex;

        public CardController(AplicationDbContext context)
        {
            _contex = context;
        }
        // GET: api/<CardController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listCard = await _contex.CreditCards.ToListAsync();
                return Ok(listCard);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<CardController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditCard card)
        {
            try {
                _contex.Add(card);
               await _contex.SaveChangesAsync();
                return Ok(card);

            } 
            catch(Exception ex){

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CardController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreditCard card)
        {
            try
            {   if(id != card.Id)
                {
                    return NotFound();
                }
                _contex.Update(card);
                await _contex.SaveChangesAsync();
                return Ok(new { message ="Tarjeta actualizada con exito!"});

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var card = await _contex.CreditCards.FindAsync(id);
                if (card == null)
                {
                    return NotFound();
                }
                _contex.CreditCards.Remove(card);
                await _contex.SaveChangesAsync();
                return Ok(new { message = "Tarjeta eliminada con exito!" });
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
