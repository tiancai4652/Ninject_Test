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

    class Samurai
    {
        List<IWeapon> weapon;
        public Samurai(List<IWeapon> weapon)
        {
            this.weapon = weapon;
        }
        public void Attack(string target)
        {
            for (int i = 0; i < weapon.Count; i++)
            {
                this.weapon[i].Hit(target);
            }
           
        }
    }
    /// <summary>
    /// 武器(去武装我们的战士)
    /// </summary>
    class Sword : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Sword {target} clean in half.");
        }
    }

    /// <summary>
    /// 武器(去武装我们的战士)
    /// </summary>
    class Strike : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Strike {target} clean in half.");
        }
    }


    //武器接口
    public interface IWeapon
    {
        void Hit(string target);
    }

}
