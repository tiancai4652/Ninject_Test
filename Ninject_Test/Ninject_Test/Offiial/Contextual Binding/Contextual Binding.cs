using Ninject;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial.Contextual_Binding
{
    public class Contextual_Binding
    {
        [Fact]
        public void Test1()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IWeapon>().To<Sword>().Named("Sword");
            kernel.Bind<IWeapon>().To<WindMagicBook>().Named("WindMagicBook");

            //Method1
            WeakAttack w = kernel.Get<WeakAttack>();
            w.Attack("You");

            ////Method2
            //WeakAttack w1 = kernel.Get<WeakAttack>("Sword");
            //w.Attack("You");

        }
    }


    class WeakAttack
    {
        readonly IWeapon _weapon;
        public WeakAttack([Named("WindMagicBook")] IWeapon weakWeapon)
        {
            _weapon = weakWeapon;
        }
        public void Attack(string victim)
        {
            _weapon.Hit(victim);
        }
    }


    //武器接口
    public interface IWeapon
    {
        void Hit(string target);
    }

    /// <summary>
    /// 武器(去武装我们的战士)
    /// </summary>
    public class Sword : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Chopped {target} clean in half.");
        }
    }

    /// <summary>
    /// 寒风魔法书
    /// </summary>
    class WindMagicBook : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Call Strong wind to blow {target}");
        }
    }




    
}
