using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.Offiial
{
    /// <summary>
    /// 武器(去武装我们的战士)
    /// </summary>
    public class Strike : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Strike {target} clean in half.");
        }
    }
}
