using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.Offiial
{
    /// <summary>
    /// 寒风魔法书
    /// </summary>
    public class WindMagicBook : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Call Strong wind to blow {target}");
        }
    }
}
