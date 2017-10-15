# AspNetCoreApp

ASP.NET Core app (TargetFramework .NetFramework) hosted in a Windows Service, with a reference to an .NetStandard project.

## Installing the service
1. Publish the wep app to the outpout folder. 
2. To install the service run in the cmd: "AspNetCoreApp.Service --install"
4. Browse http://localhost:5000 to access to the webapp.
5. To uninstall the service run in the cmd "AspNetCoreApp.Service --uninstall"

## Workarounds .NetFramework refencing .NetStandard project

Make the .NET Framework project a ProjectReference based project by setting the following property in the project in the csproj:

```
<RestoreProjectStyle> PackageReference </RestoreProjectStyle>
```
There is also a good change you will need auto-bindingredirects as well so make sure that is set in your project:

```
<AutoGenerateBindingRedirects> true </AutoGenerateBindingRedirects>
```

References:
* [[Host an ASP.NET Core app in a Windows Service]](https://docs.microsoft.com/en-us/aspnet/core/hosting/windows-service)
* [[Referencing .NET Standard Assemblies from both .NET Core and .NET Framework]](https://www.hanselman.com/blog/ReferencingNETStandardAssembliesFromBothNETCoreAndNETFramework.aspx)
* [[dotnet/standard issues]](https://github.com/dotnet/standard/issues) : #410, #901, #481, #342
 