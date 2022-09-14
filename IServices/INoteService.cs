using NoteAPI.Common;
using System.Collections.Generic;

namespace NoteAPI.IServices
{
    public interface INoteService
    {
        Note Save(Note oNote);

        List<Note> Gets();

        Note Get(int userid);

        string Delete(int userid);
    }
}
