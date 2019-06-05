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
    public class ToMethod
    {
        [Fact]
        public void Run()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IWeapon>().ToMethod(GetSword);
            var swordTemp = kernel.Get<IWeapon>();
            swordTemp.Hit("You");
        }

        public Sword GetSword(IContext context)
        {
            return new Sword();
        }
    }
}
