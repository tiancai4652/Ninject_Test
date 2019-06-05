using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.DIByHand
{

    //https://github.com/ninject/Ninject/wiki/Dependency-Injection-By-Hand
    //Neject是什么呢？首先，让我来给你解释依赖注入的想法通过一个小例子，让我们写一个炸弹游戏，在那里，高贵的战士为伟大的荣耀而战。

    //不同的战士通过拥有武器（接口）从而拥有不同的武器，（一个战士可以用刀，一个战士可以用棍子......）
    //这解决了战士都用同一类武器的问题

    //现在我们的战士可以武装不同的武器了 ，
    //但是！！这个武器仍然是被创建在战士的构造函数里的，我们还是要改变战士的实现去给他更换武器.
    //战士和武器仍然是高内聚的.

    //一种简单的解决方案代替在战士的构造函数里去创建武器，我们可以把它作为构造函数的参数暴露在外面.

    //请看Step3

    class DIByHand_Step2
    {
        public void Run()
        {
            Buddhist buddhist = new Buddhist();
            buddhist.Attack("Enemy");
        }
    }

    //武器接口
    public interface IWeapon
    {
        void Hit(string target);
    }

    /// <summary>
    /// 棍子
    /// </summary>
    public class Truncheon : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"beat up {target} with my truncheon.");
        }
    }
    /// <summary>
    /// 僧人
    /// </summary>
    class Buddhist
    {
        readonly IWeapon weapon;
        public Buddhist()
        {
            this.weapon = new Truncheon();
        }
        public void Attack(string target)
        {
            this.weapon.Hit(target);
        }
    }



}
