using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WebApiTemplate.Infrastructure {
    public class AuthenticationProviderInstaller : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter("bin"))
                .BasedOn<IWebApiTemplateAuthentication>()
                .WithService.FromInterface()
                .LifestyleTransient());

            WebApiTemplateOAuthProvider.SetAuthenticationProvider(container.Resolve<IWebApiTemplateAuthentication>());
        }
    }
}

