using Ninject;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ninject_Test.Offiial.Contextual_Binding
{

    //Step1:定义如何Match Metadata 如何匹配键值对
        // will work just as well without this line, but it's more correct and important for IntelliSense etc.
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = true, Inherited = true)]
    public class Swimmer : ConstraintAttribute
    {
        public override bool Matches(IBindingMetadata metadata)
        {
            return metadata.Has("CanSwim") && metadata.Get<bool>("CanSwim");
        }
    }

    //根绝匹配的不同键值对定义多个绑定
    public class WarriorsModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IWarrior>().To<Ninja>();
            Bind<IWarrior>().To<Samurai>().WithMetadata("CanSwim", false);
            Bind<IWarrior>().To<SpecialNinja>().WithMetadata("CanSwim", true);
        }
    }
    public class AmphibiousAttack
    {
        IWarrior _warrior;
        public AmphibiousAttack([Swimmer]IWarrior warrior)
        {
            _warrior = warrior;
        }

        [Fact]
        public static void xx()
        {
            var kernel = new StandardKernel();
            AmphibiousAttack A = kernel.Get<AmphibiousAttack>();
            Assert.IsType<SpecialNinja>(A._warrior);
        }
    }

    public interface IWarrior
    { }

    public class Ninja : IWarrior
    { }

    public class Samurai : IWarrior
    { }

    public class SpecialNinja : IWarrior
    { }



    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = true, Inherited = true)]
    public class NonSwimmer : ConstraintAttribute
    {
        public override bool Matches(IBindingMetadata metadata)
        {
            return metadata.Has("CanSwim") && !metadata.Get<bool>("CanSwim");
        }
    }
    class OnLandAttack
    {
        public OnLandAttack([NonSwimmer]IWarrior warrior)
        {
            Assert.IsType<Samurai>(warrior);
        }
    }

    class JustAttack
    {
        // Note: This will fail because we have three matching bindings.
        public JustAttack(IWarrior warrior)
        {
        }
    }
}
