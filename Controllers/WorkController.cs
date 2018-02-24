using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using examplewebapi.Services;
using examplewebapi.Models;

namespace examplewebapi.Controllers
{
    [Route("api/[controller]")]
    public class WorkController : Controller
    {
        private ArtWorksContext _context;

        public WorkController(ArtWorksContext con)
        {
            _context = con;
        }

        /// <summary>
        /// Returns a list of Artist works
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int workID) 
        {
            var artistWorks = _context.Artists.Where(a=>a.ArtistID == workID).Select(w=>w.Works).ToList();
            if(artistWorks == null) {
                return NotFound();
            }
            return new ObjectResult(artistWorks);
        }
        /// <summary>
        /// Put Update the specified work instance
        /// </summary>
        /// <param name="workID"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{workID}")]
        public IActionResult Put(int workID, [FromBody]Work value) {
             var artistWork = _context.Works.Where(w=>w.WorkID == workID).SingleOrDefault();
            if(artistWork == null) {
                return NotFound();
            }
            artistWork = value;
            return Ok();
        }
        [HttpDelete("{workID}")]
        public IActionResult Delete(int workID)
        {
           var workToDelete =  _context.Works.Where(w=>w.WorkID== workID).SingleOrDefault();
           if(workToDelete == null) {
               return NotFound();
           }

           return Ok();
        }

    }

}