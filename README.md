# Incikit

**Incikit** is an incident response library for C# .NET applications that enables automatic actions in response to detected security threats. This library provides a simple framework for responding to suspicious activities such as unauthorized access attempts, malicious file uploads, and unusual account behavior. Actions include locking accounts, notifying administrators, and quarantining suspicious files. Incikit integrates easily with existing Endpoint Detection and Response (EDR) solutions to provide a robust response layer for applications.

## Key Features

- **Automated Incident Response**: Lock accounts, quarantine files, or notify admins in response to suspicious behavior.
- **Customizable Actions**: Easily configure response actions to meet specific security requirements.
- **EDR Integration**: Seamlessly integrates with existing EDR systems for extended security monitoring and management.
- **Event Logging**: Logs incidents and responses for later analysis and auditing.

## Getting Started

### Installation

Install Incikit via NuGet Package Manager Console:

```bash
Install-Package Incikit
```

Or, add it to your .csproj file:
```xml
<PackageReference Include="Incikit" Version="1.0.0" />
```

## Setup and Configuration

1. Initialize Incikit in your application’s startup file (e.g., Startup.cs).
2. Configure the library with desired incident response actions and integration settings.
   
Here’s an example setup in Startup.cs:
```csharp
// Startup.cs
using Incikit;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIncikit(options =>
        {
            options.EnableAccountLocking = true;     // Lock accounts in response to unauthorized access attempts
            options.EnableFileQuarantine = true;     // Quarantine suspicious files detected in the application
            options.NotifyAdminEmail = "admin@example.com"; // Admin email for notifications
            options.LogAllIncidents = true;          // Enable logging for all incident responses
        });
    }
}
```

## Usage
Incikit can be integrated with security checks throughout your application to detect and respond to threats automatically.

### Example 1: Locking an Account After Suspicious Activity
In this example, an account will be locked if the library detects multiple failed login attempts, which could indicate a brute-force attack.
```csharp
using Incikit;

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
        // Authentication logic here
        return false;
    }
}
```

### Example 2: Quarantining a Suspicious File
This example shows how Incikit can quarantine a suspicious file detected in the system, preventing further access until it is reviewed by an admin.
```csharp
using Incikit;

public class FileUploadService
{
    private readonly IIncikit _incikit;

    public FileUploadService(IIncikit incikit)
    {
        _incikit = incikit;
    }

    public void UploadFile(File file)
    {
        if (IsFileSuspicious(file))
        {
            _incikit.QuarantineFile(file);
        }
    }

    private bool IsFileSuspicious(File file)
    {
        // Logic to determine if the file is suspicious
        return true;
    }
}
```

## Example Scenarios
1. Account Locking: Automatically lock user accounts after a series of failed login attempts.
2. File Quarantine: Place suspicious files in quarantine for review by administrators.
3. Administrator Notifications: Notify security administrators immediately when high-priority threats are detected.
4. Integration with EDR Systems: Connect to existing EDR solutions to trigger specific responses based on real-time threat data.

## Contributing
We welcome contributions! Please open an issue or submit a pull request if you have suggestions or improvements.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Contact
For questions or feedback, please contact [menfra@menfra.de].


