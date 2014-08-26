using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
using Autofac.Extras.FileSystemRegistration.Properties;

[assembly: AssemblyTitle("Autofac.Extras.FileSystemRegistration")]
[assembly: AssemblyCompany("Affinity ID")]
[assembly: AssemblyProduct("Autofac.Extras.FileSystemRegistration")]
[assembly: AssemblyCopyright("Copyright © Affinity ID 2014")]
[assembly: AssemblyDescription("Provides file system assembly discovery for Autofac (e.g. builder.RegisterAssemblyModulesInDirectories).")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9ce7bde7-71cf-4cad-8d0e-b03b0d9a1acd")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(AssemblyInfo.Version)]
[assembly: AssemblyFileVersion(AssemblyInfo.Version)]
[assembly: AssemblyInformationalVersion(AssemblyInfo.Version + "-pre")]

namespace Autofac.Extras.FileSystemRegistration.Properties {
    internal static class AssemblyInfo {
        public const string Version = "0.1.2";
    }
}