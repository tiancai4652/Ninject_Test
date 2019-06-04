using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial.Contextual_Binding3
{

    //This allows one to define constraints based on any of the following:

    //the Target: the parameter being injected into
    //the Member: the property, method or constructor itself
    //the Class: the class Type within which the Member or Target is defined within

        //Target:被注入的参数
        //Member:属性，方法或构造函数
        //Class:类
    public class Contextual_Binding3
    {
        [Fact]
        public void Test()
        {
            IKernel kernel = new StandardKernel(new WarriorsModule());
            var multiAttack= kernel.Get<MultiAttack>();
            Assert.IsType<Samurai>(multiAttack.Temp);

        }
    }

    class SwimmerNeeded : Attribute { }
    class ClimberNeeded : Attribute { }

    class WarriorsModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IWarrior>().To<Ninja>();
            //当类有这个特性的时候我就用Samurai实例去实现IWarrior接口
            Bind<IWarrior>().To<Samurai>().WhenClassHas<ClimberNeeded>();
            //当目标有这个特性的时候我就用Samurai实例去实现IWarrior接口
            Bind<IWarrior>().To<Samurai>().WhenTargetHas<ClimberNeeded>();
            //当属性有这个特性的时候我就用SpecialNinja实例去实现IWarrior接口
            Bind<IWarrior>().To<SpecialNinja>().WhenMemberHas<SwimmerNeeded>();

            //其他用法
            Bind<IWarrior>().To<Samurai>().When(request => request.Target.Member.Name.StartsWith("Climbing"));
            Bind<IWarrior>().To<Samurai>().When(request => request.Target.Type.Namespace.StartsWith("Samurais.Climbing"));
        }
    }

    class MultiAttack
    {
        public MultiAttack([ClimberNeeded] IWarrior MountainWarrior)
        {
            Temp = MountainWarrior;
        }
        [Inject, SwimmerNeeded]
        IWarrior OffShoreWarrior { get; set; }
        [Inject]
        IWarrior AnyOldWarrior { get; set; }
        public IWarrior Temp { get; set; }
    }

    [ClimberNeeded]
    class MountainousAttack
    {
        [Inject, SwimmerNeeded]
        IWarrior HighlandLakeSwimmer { get; set; }
        [Inject]
        IWarrior StandardMountainWarrior { get; set; }
    }

    public interface IWarrior
    { }

    public class Ninja : IWarrior
    { }

    public class Samurai : IWarrior
    { }

    public class SpecialNinja : IWarrior
    { }


}
