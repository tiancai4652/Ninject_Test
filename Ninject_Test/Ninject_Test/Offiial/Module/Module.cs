using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial.Module
{
    public class Module
    {
        [Fact]
        void xx()
        {
            //IKernel kernel = new StandardKernel(new WarriorModule());
            //Samurai warrior = kernel.Get<Samurai>();
            //warrior.Attack("the evildoers");

            IKernel kernel = new StandardKernel(new Module1(),new Module2());
            Samurai warrior = kernel.Get<Samurai>();
            warrior.Attack("the evildoers");

        }
    }

    class Module1 : NinjectModule
    {
        public override void Load() { Bind<IWeapon>().To<Sword>(); }
    }

    class Module2 : NinjectModule
    {
        public override void Load() { Bind<IWeapon>().To<Strike>(); }
    }

    public class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
            Bind<IWeapon>().To<Strike>();
            //Bind<Samurai>().ToSelf().InSingletonScope();
        }
    }
}
