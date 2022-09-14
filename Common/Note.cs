using System;

namespace NoteAPI.Common
{
    public class Note
    {
        public int Userid { get; set; }
        public string NoteDetails { get; set; }
        public int NoteType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
