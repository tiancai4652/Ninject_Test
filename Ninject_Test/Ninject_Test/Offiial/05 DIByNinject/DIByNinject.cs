using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial.DIByNinject
{
    //https://github.com/ninject/Ninject/wiki/Dependency-Injection-With-Ninject
    //如果使用Ninject

    //1 用kernel.Get<Samurai>();去构建我们的实例
    //2 用Bind<IWeapon>().To<Sword>();去确定接口要实现哪种试题类型的参数



    public class DIByNinject
    {
        [Fact]
        public void Run()
        {
            IKernel kernel = new StandardKernel();
            //要通过Type Binding来确定接口要实现哪种类型.
            kernel.Bind<IWeapon>().To<Sword>();
            //此时就可以构建一个Samurai的实例
            var samurai = kernel.Get<Samurai>();
            samurai.Attack("You");
        }
    }
}
