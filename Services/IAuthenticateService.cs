using NoteAPI.Models;

namespace NoteAPI.IServices
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);

    }
}
