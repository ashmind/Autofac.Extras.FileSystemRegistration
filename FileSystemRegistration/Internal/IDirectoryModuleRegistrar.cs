using System;
using System.IO;
using System.Reflection;
using Autofac.Core.Registration;
using JetBrains.Annotations;

namespace Autofac.Extras.FileSystemRegistration.Internal {
    public interface IDirectoryModuleRegistrar : IModuleRegistrar {
        [NotNull] IDirectoryModuleRegistrar WhereFileMatches([NotNull] string filePattern);
        [NotNull] IDirectoryModuleRegistrar WhereFile([NotNull] Func<FileInfo, bool> filter);
        [NotNull] IDirectoryModuleRegistrar WhereAssembly([NotNull] Func<Assembly, bool> filter);
    }
}