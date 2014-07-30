using System;
using Autofac.Core;
using Autofac.Core.Registration;
using JetBrains.Annotations;

namespace Autofac.Extras.FileSystemRegistration.Internal {
    public class ImmediateModuleRegistrar : IModuleRegistrar {
        private readonly IComponentRegistry _registry;

        public ImmediateModuleRegistrar([NotNull] IComponentRegistry registry) {
            if (registry == null) throw new ArgumentNullException("registry");

            _registry = registry;
        }

        public IModuleRegistrar RegisterModule(IModule module) {
            module.Configure(_registry);
            return this;
        }
    }
}
