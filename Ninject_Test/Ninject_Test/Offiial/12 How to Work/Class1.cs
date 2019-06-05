using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject_Test.Offiial._12_How_to_Work
{
    /// <summary>
    /// 是运用反射去生成实现类，但是反复用反射会很慢
    /// 所以利用了在CLR2.0介绍的轻量级代码生成系统
    /// dynamic method在生成目标的时候会被调用
    /// </summary> 动态方法像这样
    /// delegate(IWeapon weapon)
    //{
    //    return new Samurai(weapon);
    //}
public class Class1
    {
    }
}
