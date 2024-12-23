using Microsoft.AspNetCore.Mvc;
using NoteTaking_Server.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteTaking_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private static int count = 3;
        private static List<Note> notes = new List<Note>
        {
            new Note
            {
                Id = 1,Content = "Have a nice day", NumOfLike = 3, Title = "a class day bless"
            },
            new Note
            {
                Id = 2,Content = "Have a nice week", NumOfLike = 0, Title = "a class week bless"
            }
        };
        // GET: api/<NotesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(notes);
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var note = notes.Find((n) => n.Id == id);
            if (note != null)
            {
                return Ok(note);
            }
            return NotFound();
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult Post([FromBody] NotePostModel value)
        {
            var newNote = new Note { Content = value.Content, NumOfLike = 0, Title = value.Title, Id = count++ };
            notes.Add(newNote);
            return Ok(newNote);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] NotePutModel value)
        {
            var note = notes.Find((n) => n.Id == id);
            if (note != null)
            {
                note.NumOfLike = value.NumOfLike;
                note.Title = value.Title;
                note.Content = value.Content;
                return Ok(note);
            }
            return NotFound();
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var note = notes.Find((n) => n.Id == id);
            if (note != null)
            {
                notes.Remove(note);
                return Ok();
            }
            return NotFound();
        }
    }
}
