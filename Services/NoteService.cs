using Dapper;
using NoteAPI.Common;
using NoteAPI.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static NoteAPI.Common.Enum;
namespace NoteAPI.Services
{
    public class NoteService : INoteService
    {
        Note _oNote = new Note();
        List<Note> _oNotes = new List<Note>();
        public string Delete(int Userid)
        {
            string message = "";
            try
            {
                _oNote = new Note()
                {
                    Userid = Userid
                };

                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oNotes = con.Query<Note>("Sp_Note", this.SetParameters(_oNote, (int)OperationType.Delete),
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

        public Note Get(int Userid)
        {
            _oNote = new Note();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
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

        public List<Note> Gets()
        {
            _oNotes = new List<Note>();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
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

        public Note Save(Note oNote)
        {
            _oNote = new Note();

            int operationType = Convert.ToInt32(oNote.Userid == 0 ? OperationType.Insert : OperationType.Update);

            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var oNotes = con.Query<Note>("Sp_Note", this.SetParameters(oNote, operationType),
                    commandType: CommandType.StoredProcedure);

                if (oNotes != null && oNotes.Count() > 0)
                {
                    _oNote = oNotes.FirstOrDefault();
                }
            }

            return _oNote;
        }
        private DynamicParameters SetParameters(Note oNote, int operationType)
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
