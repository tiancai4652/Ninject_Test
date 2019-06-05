using Ninject;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial.Providers
{
    /// <summary>
    /// 当Ninject 的默认使用不能满足你的要求的时候，你可以构建一个provider 
    ///Serciece Type  > Providers(craet new instance )
    /// </summary>
    public class ToProviders
    {
        [Fact]
        public void Run()
        {
            IKernel kernel = new StandardKernel(new TestModule());
            var swordTemp = kernel.Get<IWeapon>();
            swordTemp.Hit("You");
        }
    }

    /// <summary>
    /// 构建多注入实例模式
    /// </summary>
    class TestModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().ToProvider<SwordProvider>();
        }
    }

    public abstract class Provider<T> : IProvider
    {
        protected Provider() { }
        public virtual Type Type { get; }
        public object Create(IContext context) { return CreateInstance(context); }
        protected abstract T CreateInstance(IContext context);
    }

    public class SwordProvider : Provider<Sword>
    {
        protected override Sword CreateInstance(IContext context)
        {
            Sword sword = new Sword();

            // Do some complex initialization here.

            return sword;
        }
    }

}
