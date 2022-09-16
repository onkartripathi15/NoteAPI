using Dapper;
using NoteAPI.Common;
using NoteAPI.Repositories;
using NoteAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static NoteAPI.Common.Enum;
namespace NoteAPI.Services
{
    public class NoteService : INoteRepo
    {
        private NoteRepo _noteRepo;
        public NoteService(NoteRepo noteRepo)
        {
            _noteRepo = noteRepo;
        }
        public string DeleteNoteById(int Userid)
        {
            return _noteRepo.DeleteNoteById(Userid);
        }
        public List<Note> GetAllNotes()
        {
            return _noteRepo.GetAllNotes();
        }
        public Note GetNoteById(int Userid)
        {
            return _noteRepo.GetNoteById(Userid);
        }
        public Note Save(Note oNote)
        {
            return _noteRepo.Save(oNote);
        }
        private DynamicParameters SetParameters(Note oNote, int operationType)
        {
            return _noteRepo.SetParameters(oNote, operationType);
        }
    }
}
