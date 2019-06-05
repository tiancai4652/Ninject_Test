using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial._13_Contextual_binding
{
    public class ChooseStrongTypeByName
    {

        /// <summary>
        /// （最常用）使用场景2:通过命名来选择我到底使用哪个实现类去实现接口
        /// </summary>
        [Fact]
        public void Run()
        {
            IKernel kernel = new StandardKernel(new TestModule());

            //获取实例的时候用名称来获取
            var sword = kernel.Get<IWeapon>("Sword");
            sword.Hit("You");

        }

    }

    /// <summary>
    /// 构建多注入实例模式
    /// </summary>
    class TestModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>().Named("Sword");
            Bind<IWeapon>().To<Strike>().Named("Strike");
            Bind<IWeapon>().To<WindMagicBook>().Named("WindMagicBook");

            Bind<IWeapon2>().To<Sword2>().Named("Sword2");
            Bind<IWeapon2>().To<Sword3>().Named("Sword3");

        }
    }


    public class Sword2 : IWeapon2
    {
        IWeapon weapon = null;
        //这个好像就只有一个提示的作用，获取实例的时候还是得加上Name
        public Sword2([Named("Sword2")]IWeapon iweapin)
        {
            weapon = iweapin;
        }

        public void Hit(string target)
        {
            throw new NotImplementedException();
        }
    }

    public class Sword3 : IWeapon2
    {
        IWeapon weapon = null;
        public Sword3([Named("Sword3")]IWeapon iweapin)
        {
            weapon = iweapin;
        }

        public void Hit(string target)
        {
            throw new NotImplementedException();
        }
    }

    interface IWeapon2
    {
        void Hit(string target);
    }
}
