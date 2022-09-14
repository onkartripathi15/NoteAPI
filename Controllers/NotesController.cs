using Microsoft.AspNetCore.Mvc;
using NoteAPI.Common;
using NoteAPI.IServices;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteService _oNoteService;

        public NotesController(INoteService oNoteService)
        {
            _oNoteService = oNoteService;
        }
        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return _oNoteService.Gets();
        }

        // GET api/<NotesController>/5
        [HttpGet("{userid}")]
        public Note Get(int userid)
        {
            return _oNoteService.Get(userid);
        }

        // POST api/<NotesController>
        [HttpPost]
        public Note Post([FromBody] Note oNote)
        {
            if (ModelState.IsValid) return _oNoteService.Save(oNote);
            return null;
        }

        // PUT api/<NotesController>/5
        [HttpPut("{userid}")]
        public void Put(int userid, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{userid}")]
        public string Delete(int userid)
        {
            return _oNoteService.Delete(userid);
        }
    }
}
