using NoteAPI.Models;

namespace NoteAPI.Services
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);

    }
}
