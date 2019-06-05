using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.Offiial.InjectionPartterns
{
    //https://github.com/ninject/Ninject/wiki/Injection-Patterns
    //介绍Inject的三种模式
    //构造函数注入，属性注入，字段注入（舍弃）

    //**只推荐构造函数注入**

    class InjectionPartterns
    {
    }

    /// <summary>
    /// 构造函数注入
    /// • 带有[Inject]标签的(如果带有多个[Inject]标签，Ninject会抛出异常)
	/// • 如果没有[Inject] 标签，Ninject会选择一个能够解析的，带有最多参数的构造函数.
	/// • 如果没有构造函数定义，Ninject会选择一个假想的带有默认参数的构造函数

    /// </summary>
    //class Samurai
    //{
    //    readonly IWeapon weapon;

    //    public Samurai(IWeapon weapon)
    //    {
    //        if (weapon == null)
    //            throw new ArgumentNullException("weapon");
    //        this.weapon = weapon;
    //    }

    //    public void Attack(string target)
    //    {
    //        this.weapon.Hit(target);
    //    }
    //}

    //属性注入1
    //class Samurai
    //{
    //    IWeapon weapon;

    //    [Inject]
    //    public void Arm(IWeapon weapon)
    //    {
    //        this.weapon = weapon;
    //    }

    //    public void Attack(string target)
    //    {
    //        this.weapon.Hit(target);
    //    }
    //}

    //属性注入2
    //class Samurai
    //{
    //    [Inject]
    //    public IWeapon Weapon { private get; set; }

    //    public void Attack(string target)
    //    {
    //        this.Weapon.Hit(target);
    //    }
    //}

    ////武器接口
    //public interface IWeapon
    //{
    //    void Hit(string target);
    //}
}
