using NoteAPI.Common;
using System.Collections.Generic;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static NoteAPI.Common.Enum;
using Microsoft.Extensions.Configuration;
using NoteAPI.Repositories.Interfaces;

namespace NoteAPI.Repositories
{
    public class NoteRepo : INoteRepo
    {
        private IConfiguration Configuration;
        string config;
        public NoteRepo(IConfiguration _configuration)
        {
            Configuration = _configuration;
            config = Configuration.GetConnectionString("NoteDB");
        }


        Note _oNote = new Note();
        List<Note> _oNotes = new List<Note>();

        public string DeleteNoteById(int Userid)
        {
            string message = "";
            try
            {
                _oNote = new Note()
                {
                    Userid = Userid
                };

                using (IDbConnection con = new SqlConnection(config))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oNotes = con.Query<Note>("Sp_Note", SetParameters(_oNote, (int)OperationType.Delete),
                        commandType: CommandType.StoredProcedure);

                    if (oNotes != null && oNotes.Count() > 0)
                    {
                        _oNote = oNotes.FirstOrDefault();
                    }
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }

        public List<Note> GetAllNotes()
        {
            _oNotes = new List<Note>();
            using (IDbConnection con = new SqlConnection(config))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var oNotes = con.Query<Note>("SELECT * FROM Note").ToList();


                if (oNotes != null && oNotes.Count() > 0)
                {
                    _oNotes = oNotes;
                }
            }
            return _oNotes;
        }

        public Note GetNoteById(int Userid)
        {
            _oNote = new Note();
            using (IDbConnection con = new SqlConnection(config))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var oNotes = con.Query<Note>("SELECT * FROM Note WHERE userid=" + Userid).ToList();


                if (oNotes != null && oNotes.Count() > 0)
                {
                    _oNote = oNotes.SingleOrDefault();
                }
            }
            return _oNote;
        }

        public Note Save(Note oNote)
        {
            _oNote = new Note();

            int operationType = Convert.ToInt32(oNote.Userid == 0 ? OperationType.Insert : OperationType.Update);

            using (IDbConnection con = new SqlConnection(config))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var oNotes = con.Query<Note>("Sp_Note", SetParameters(oNote, operationType),
                    commandType: CommandType.StoredProcedure);

                if (oNotes != null && oNotes.Count() > 0)
                {
                    _oNote = oNotes.FirstOrDefault();
                }
            }

            return _oNote;
        }
        public DynamicParameters SetParameters(Note oNote, int operationType)
        {
            dynamic parameters = new DynamicParameters();
            parameters.Add("@Userid", oNote.Userid);
            parameters.Add("@NoteDetails", oNote.NoteDetails);
            parameters.Add("@NoteType", oNote.NoteType);
            parameters.Add("@CreatedOn", oNote.CreatedOn);
            parameters.Add("@OperationType", operationType);
            return parameters;

        }
    }
}
