using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.Offiial.DIByNinject
{
    //https://github.com/ninject/Ninject/wiki/Dependency-Injection-With-Ninject
    //如果使用Ninject

    //1 用kernel.Get<Samurai>();去构建我们的实例
    //2 用Bind<IWeapon>().To<Sword>();去确定接口要实现哪种试题类型的参数



    class DIByNinject
    {
        public void Run()
        {
            IKernel kernel = new StandardKernel();
            //此时就可以构建一个Samurai的实例
            //等等，Samurai的构造函数有个IWeapon，但是IWeapon是个接口，接口不能实例化，那么Niniject是如何知道他要实现哪种类型呢
            var samurai = kernel.Get<Samurai>();
            //要通过Type Binding来确定接口要实现哪种类型.
            Bind<IWeapon>().To<Sword>();
        }
    }


    class Samurai
    {
        readonly IWeapon weapon;
        public Samurai(IWeapon weapon)
        {
            this.weapon = weapon;
        }
        public void Attack(string target)
        {
            this.weapon.Hit(target);
        }
    }
    /// <summary>
    /// 武器(去武装我们的战士)
    /// </summary>
    class Sword:IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Chopped {target} clean in half.");
        }
    }


    //武器接口
    public interface IWeapon
    {
        void Hit(string target);
    }

}
