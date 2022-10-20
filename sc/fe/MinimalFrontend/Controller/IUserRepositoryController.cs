using fingerprint.Models;

namespace MinimalFrontend.Controller;

public interface IUserRepositoryController
{
    Task Create(UserModel user);
}