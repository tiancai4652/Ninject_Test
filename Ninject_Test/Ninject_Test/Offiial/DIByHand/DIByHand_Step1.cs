using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.DIByHand
{

    //https://github.com/ninject/Ninject/wiki/Dependency-Injection-By-Hand
    //Neject是什么呢？首先，让我来给你解释依赖注入的想法通过一个小例子，让我们写一个炸弹游戏，在那里，高贵的战士为伟大的荣耀而战。

    //定义了一个战士类，一个武器类，实现战士攻击敌人
    //武器是战士内部创建，没有暴露给外面,这造成了当战士想换武器的时候，需要修改战士的构造函数

    //当一个类是依赖于具体依赖项的时候，他被称作高聚合，在这个例子中，战士类和刀类就是高聚合的，
    //当一个类是高聚合的时候，当想要他们内部改变就必须更改他们的实现，
    //为了避免高聚合类，我们使用接口来提供一种间接，让我们创建一个接口来代表武器.

    //请看Step2

    public class DIByHand_Step1
    {

        public void Go()
        {
            //战士攻击敌人
            Samurai samurai = new Samurai();
            samurai.Attack("Enemy");
        }
    }

    /// <summary>
    /// 武器(去武装我们的战士)
    /// </summary>
    class Sword
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Chopped {target} clean in half.");
        }
    }

    /// <summary>
    /// 战士
    /// </summary>
    class Samurai
    {
        //战士拥有一个剑
        readonly Sword sword;
        public Samurai()
        {
            this.sword = new Sword();
        }
        public void Attack(string target)
        {
            this.sword.Hit(target);
        }
    }



}
