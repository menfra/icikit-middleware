using System.IO;

public interface IIncikit
{
    void HandleFailedLoginAttempt(string username);
    void QuarantineFile(FileStream file);
}