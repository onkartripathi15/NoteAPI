using NoteAPI.Common;
using System.Collections.Generic;

namespace NoteAPI.Repositories.Interfaces
{
    public interface INoteRepo
    {
        Note Save(Note oNote);

        List<Note> GetAllNotes();

        Note GetNoteById(int userid);

        string DeleteNoteById(int userid);
    }
}
