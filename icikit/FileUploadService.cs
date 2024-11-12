using System.IO;

public class FileUploadService
{
    private readonly IIncikit _incikit;

    public FileUploadService(IIncikit incikit)
    {
        _incikit = incikit;
    }

    public void UploadFile(FileStream file)
    {
        if (IsFileSuspicious(file))
        {
            _incikit.QuarantineFile(file);
        }
    }

    private bool IsFileSuspicious(FileStream file)
    {
        // Logic to determine if the file is suspicious
        return true;
    }
}
