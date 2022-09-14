using System;

namespace NoteAPI.Common
{
    public class Note
    {
        public int Userid { get; set; }
        public string NoteDetails { get; set; }
        public string NoteType { get; set; }
        public string CreatedOn { get; set; }
    }
}
