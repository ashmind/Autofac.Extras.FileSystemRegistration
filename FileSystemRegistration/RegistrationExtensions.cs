using System;
using System.IO;
using System.Reflection;
using Autofac.Extras.FileSystemRegistration.Internal;
using JetBrains.Annotations;

namespace Autofac.Extras.FileSystemRegistration {
    [PublicAPI]
    public static class RegistrationExtensions {
        [PublicAPI, NotNull]
        public static IDirectoryModuleRegistrar RegisterAssemblyModulesInDirectories([NotNull] this ContainerBuilder builder, params string[] directoryPaths) {
            return new DirectoryModuleRegistrar(builder, directoryPaths);
        }

        [PublicAPI, NotNull]
        public static IDirectoryModuleRegistrar RegisterAssemblyModulesInDirectoryOf([NotNull] this ContainerBuilder builder, Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException("assembly");
            var directoryPath = Path.GetDirectoryName(new Uri(assembly.CodeBase).LocalPath);
            return builder.RegisterAssemblyModulesInDirectories(directoryPath);
        }
    }
}
