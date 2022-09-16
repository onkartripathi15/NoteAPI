using NoteAPI.Models;

namespace NoteAPI.Services.Interfaces
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);

    }
}
