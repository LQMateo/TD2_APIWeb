using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TD2_APIWeb.Models.EntityFramework;

namespace TD2_APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly Td2Context _context;

        public SeriesController(Td2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all series.
        /// </summary>
        /// <returns>Http response</returns>
        /// <response code="200">When sucess</response>
        // GET: api/Series
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Serie))]
        public async Task<ActionResult<IEnumerable<Serie>>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // GET: api/Series/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Serie))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);

            if (serie == null)
            {
                return NotFound();
            }

            return serie;
        }

        /// <summary>
        /// Update an serie.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the serie</param>
        /// <response code="200">When the serie as update</response>
        /// <response code="404">When the serie is not found </response>
        // PUT: api/Series/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutSerie(int id, Serie serie)
        {
            if (id != serie.Serieid)
            {
                return BadRequest();
            }

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Add serie.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="serie">Object serie</param>
        /// <response code="200">When the serie added</response>
        // POST: api/Series
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Serie))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Serie>> PostSerie(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.Serieid }, serie);
        }

        /// <summary>
        /// Delete an serie.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the serie</param>
        /// <response code="200">When the serie as deleted</response>
        /// <response code="404">When the serie are not found</response>
        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Serieid == id);
        }
    }
}
