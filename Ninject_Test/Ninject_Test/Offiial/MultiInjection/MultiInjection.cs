using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.Offiial.MultiInjection
{
    //https://github.com/ninject/Ninject/wiki/Multi-injection
    /// <summary>
    /// 可以注入一个List<Interface> 实例集（）{implement1，implement2，implement3}
    /// </summary>
    class MultiInjection
    {
        public static void Main()
        {
            Ninject.IKernel kernel = new StandardKernel(new TestModule());
 

            //Way1
            var samurai = kernel.Get<Samurai>();
            samurai.Attack("your enemy");

            //Way2
            //请注意：如果你移除了上面Foreach，这个对象是不会构造出来的，
            //GetAll的结构只有你去迭代他才会被构建,每个计算都会合成一系列的对象.
            IEnumerable<IWeapon> weapons = kernel.GetAll<IWeapon>();
            foreach (var weapon in weapons)
                Console.WriteLine(weapon.Hit("the evildoers"));

        }

    }

    /// <summary>
    /// 构建多注入实例模式
    /// </summary>
    class TestModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
            Bind<IWeapon>().To<Dagger>();
        }
    }

    /// <summary>
    /// With Multi Weapons
    /// </summary>
    public class Samurai
    {
        readonly IWeapon[] allWeapons;

        public Samurai(IWeapon[] allWeapons)
        {
            this.allWeapons = allWeapons;
        }

        public void Attack(string target)
        {
            foreach (IWeapon weapon in this.allWeapons)
                Console.WriteLine(weapon.Hit(target));
        }
    }



    public interface IWeapon
    {
        string Hit(string target);
    }

    public class Sword : IWeapon
    {
        public string Hit(string target)
        {
            return "Slice " + target + " in half";
        }
    }

    public class Dagger : IWeapon
    {
        public string Hit(string target)
        {
            return "Stab " + target + " to death";
        }
    }
}
