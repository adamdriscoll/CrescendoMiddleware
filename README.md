# Crescendo Middleware

Middleware for generating Crescendo PowerShell modules from .NET command line tools using System.CommandLine

# Usage 

You will need to map your commands to PowerShell cmdlets and add the Crescendo middleware. 

```csharp
commandLineBuilder.AddCrescendoMiddleware(opts =>
{
    opts.AddCmdletMapping("Get-Message", rootCommand);
});
```

Once this is done, you can call your executable with `--crescendo`.

```powershell
.\ConsoleApp.exe --crescendo
```

A crescendo JSON file will be generated. You can then import that module and call the imported cmdlets. 

```
PS> Import-Module .\ConsoleApp.psd1
PS> Get-Message -message test
 --delay = 0
--message = Test
```
