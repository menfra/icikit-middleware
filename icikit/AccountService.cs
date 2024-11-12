public class AccountService
{
    private readonly IIncikit _incikit;

    public AccountService(IIncikit incikit)
    {
        _incikit = incikit;
    }

    public void Login(string username, string password)
    {
        bool isLoginSuccessful = AuthenticateUser(username, password);

        if (!isLoginSuccessful)
        {
            _incikit.HandleFailedLoginAttempt(username);
        }
    }

    private bool AuthenticateUser(string username, string password)
    {
        return false;
    }
}
