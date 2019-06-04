using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test
{
    public class Class1
    {
        void test()
        {
            IKernel kernel = new StandardKernel();
            var samurai = kernel.Get<Offiial.Contextual_Binding.Samurai>();

        }

    }


    
}
