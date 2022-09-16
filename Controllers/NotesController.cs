using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.Common;
using NoteAPI.Repositories.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteRepo _oNoteService;

        public NotesController(INoteRepo oNoteService)
        {
            _oNoteService = oNoteService;
        }
        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> GetAllNotes()
        {
            return _oNoteService.GetAllNotes();
        }

        // GET api/<NotesController>/5
        [HttpGet("{userid}")]
        public Note GetNoteById(int userid)
        {
            return _oNoteService.GetNoteById(userid);
        }

        // POST api/<NotesController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public string DeleteNoteById(int userid)
        {
            return _oNoteService.DeleteNoteById(userid);
        }
    }
}
