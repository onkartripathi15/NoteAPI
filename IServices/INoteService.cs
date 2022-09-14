using NoteAPI.Common;
using System.Collections.Generic;

namespace NoteAPI.IServices
{
    public interface INoteService
    {
        Note Save(Note oNote);

        List<Note> GetAllNotes();

        Note GetNoteById(int userid);

        string DeleteNoteById(int userid);
    }
}
