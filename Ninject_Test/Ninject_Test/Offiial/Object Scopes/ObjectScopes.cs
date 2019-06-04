using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial.Object_Scopes
{

    //生命周期  此方案只适用于从StandardKernel.Bind的实例而不是从NinjectModule，下一个章节介绍有关NinjectModule
    //InTransientScope  默认类型，每次都会重新创建一个实例去绑定
    //Singleton  单例
    //Thread
    //Request
    //Custom 自定义

    public class ScopeObject { }

    public static class ProcessingScope
    {
        public static ScopeObject Current { get; set; }
    }

    public class NinjectCustomScopeExample
    {
        public class TestService { }

        [Fact]
        public static void Test()
        {
            var kernel = new StandardKernel();
            kernel.Bind<TestService>().ToSelf().InScope(x => ProcessingScope.Current);

            var ScopeA = new ScopeObject();
            var ScopeB = new ScopeObject();

            ProcessingScope.Current = ScopeA;
            var testA1 = kernel.Get<TestService>();
            var testA2 = kernel.Get<TestService>();

            Assert.Same(testA1, testA2);

            ProcessingScope.Current = ScopeB;
            var testB = kernel.Get<TestService>();

            Assert.NotSame(testB, testA1);

            ProcessingScope.Current = ScopeA;
            var testA3 = kernel.Get<TestService>();

            Assert.Same(testA1, testA3);
        }
    }
}
