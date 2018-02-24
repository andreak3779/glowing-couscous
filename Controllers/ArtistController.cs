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
    public class ArtistController : Controller
    {
        private readonly ArtWorksContext _context;

        public ArtistController(ArtWorksContext con)
        {
            _context= con;
        }

        /// <summary>
        /// Returns the entire list of Artists
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return _context.Artists.ToList();
        }
        /// <summary>
        /// Returns the specified artist based on the id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var artistObj = _context.Artists.FirstOrDefault(a=>a.ArtistID == id);
            if(artistObj == null) {
                return NotFound();
            }
            return new ObjectResult(artistObj);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Artist artObj)
        {
            if(artObj == null) {
                return BadRequest();
            }
            _context.Artists.Add(artObj);
            _context.SaveChanges();
            return CreatedAtRoute("GetArtist" + new {artObj.ArtistID},artObj);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Artist value)
        {
            var artistObj = _context.Artists.Where(a=>a.ArtistID == id).SingleOrDefault();
            if(artistObj == null) {
                return NotFound();
            }
            artistObj = value;
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var artistToDelete =  _context.Artists.Where(a=>a.ArtistID == id).SingleOrDefault();
           if(artistToDelete == null) {
               return NotFound();
           }

           return Ok();
        }
    }

}