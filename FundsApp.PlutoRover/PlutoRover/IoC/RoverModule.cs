using Ninject.Extensions.Factory;
using Ninject.Modules;
using PlutoRover.Core;
using PlutoRover.Core.Commands;
using PlutoRover.Interfaces;
using PlutoRover.Models.Enums;

namespace PlutoRover.IoC
{
    public class RoverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandFactory>().ToFactory(() => new NameInstanceProvider());

            Bind<ICommandExecute>().To<CommandF>().Named(Command.F.ToString());
            Bind<ICommandExecute>().To<CommandB>().Named(Command.B.ToString());
            Bind<ICommandExecute>().To<CommandR>().Named(Command.R.ToString());
            Bind<ICommandExecute>().To<CommandL>().Named(Command.L.ToString());

            Bind<IRoverManager>().To<RoverManager>();
            Bind<IProgramController>().To<ProgramController>();
        }
    }
}