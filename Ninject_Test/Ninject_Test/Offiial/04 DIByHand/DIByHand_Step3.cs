using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.DIByHand
{

    //https://github.com/ninject/Ninject/wiki/Dependency-Injection-By-Hand
    //Neject是什么呢？首先，让我来给你解释依赖注入的想法通过一个小例子，让我们写一个炸弹游戏，在那里，高贵的战士为伟大的荣耀而战。

    //这个被称作手动的依赖注入，
    //因为你每次想创建一个战士你都得先创建实现武器类接口的武器，然后把这个武器传递给战士的构造函数，
    //现在我们可以改变战士的武器而不用更改他的实现，战士类应该和武器分离
    //事实上，我们可以不需要知道战士的源码就能创建新的武器.

    //即，武器作为一个独立的个体，可以独自创建出来
    //战士的创建又不依赖具体某个武器才能被创建，只需要一个通用的武器接口

    //如果战士的构造函数里没有武器，那么不是可以分离的更彻底一些吗？？？？？？
    //战士和武器都不需要对方就能独立创建，不过好像不实现的话Attack方法使不了了

    //总结：我这个实体类需要一个实例，我需要将他接口化，并把它暴露在构造函数中，这样我就不需要依赖具体的实例才能实例化

    class DIByHand_Step3
    {
        public void Run()
        {
            Enchanter Enchanter1 = new Enchanter(new WindMagicBook());
            Enchanter1.Attack("Enemy1");
            Enchanter Enchanter2 = new Enchanter(new WindMagicBook());
            Enchanter1.Attack("Enemy2");
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

    /// <summary>
    /// 道士
    /// </summary>
    public class Enchanter
    {
        public IWeapon Weapon { get; set; }
        public Enchanter(IWeapon weapon)
        {
            Weapon = weapon;
        }
        public void Attack(string target)
        {
            this.Weapon.Hit(target);
        }
    }



}
