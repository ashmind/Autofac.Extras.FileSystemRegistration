using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using Autofac.Core.Registration;
using JetBrains.Annotations;

namespace Autofac.Extras.FileSystemRegistration.Internal {
    public class DirectoryModuleRegistrar : IDirectoryModuleRegistrar {
        private readonly ContainerBuilder _builder;
        private readonly string[] _directoryPaths;

        private string _filePattern = "*.*";
        private Func<FileInfo, bool> _fileFilter = f => f.Extension.Equals(".dll", StringComparison.InvariantCultureIgnoreCase)
                                                     || f.Extension.Equals(".exe", StringComparison.InvariantCultureIgnoreCase);
        private Func<Assembly, bool> _assemblyFilter = a => true;

        public DirectoryModuleRegistrar([NotNull] ContainerBuilder builder, params string[] directoryPaths) {
            if (builder == null) throw new ArgumentNullException("builder");
            _builder = builder;
            _directoryPaths = directoryPaths;

            _builder.RegisterCallback(DiscoverModules);
        }

        public IDirectoryModuleRegistrar WhereFileMatches(string filePattern) {
            if (filePattern == null) throw new ArgumentNullException("filePattern");

            _filePattern = filePattern;
            return this;
        }

        public IDirectoryModuleRegistrar WhereFile(Func<FileInfo, bool> filter) {
            if (filter == null) throw new ArgumentNullException("filter");

            _fileFilter = filter;
            return this;
        }

        public IDirectoryModuleRegistrar WhereAssembly(Func<Assembly, bool> filter) {
            if (filter == null) throw new ArgumentNullException("filter");

            _assemblyFilter = filter;
            return this;
        }

        private void DiscoverModules(IComponentRegistry registry) {
            var files = _directoryPaths.Select(p => new DirectoryInfo(p))
                                       .SelectMany(d => d.GetFiles(_filePattern))
                                       .Where(_fileFilter);

            var registrar = new ImmediateModuleRegistrar(registry);
            foreach (var file in files) {
                var assembly = LoadAssemblySafe(file);
                if (assembly == null || !_assemblyFilter(assembly))
                    continue;

                registrar.RegisterAssemblyModules(assembly);
            }
        }

        [CanBeNull]
        private static Assembly LoadAssemblySafe(FileInfo file) {
            try {
                return Assembly.LoadFrom(file.FullName);
            }
            catch (BadImageFormatException) {
                return null;
            }
        }

        [NotNull]
        public IModuleRegistrar RegisterModule([NotNull] IModule module) {
            if (module == null) throw new ArgumentNullException("module");
            _builder.RegisterCallback(module.Configure);
            return this;
        }
    }
}
