using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial._13_Contextual_binding
{

    public class Warrior
    {
        readonly IEnumerable<IWeapon> _weapons;
        public Warrior(IEnumerable<IWeapon> weapons)
        {
            _weapons = weapons;
        }
        /// <summary>
        /// 使用场景1：通过一个List<Interface> 绑定一个集合的多个实现实例
        /// </summary>
        public void Attack(string victim)
        {
            //foreach (var weapon in _weapons)
            //    Console.WriteLine(weapon.Hit(victim));
        }










    }
}
