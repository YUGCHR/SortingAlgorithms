using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSortingAlgorithms
{
    public interface FlyBehavior
    {
        public void fly();
    }

    public interface QuackBehavior
    {
        public void quack();
    }

    public abstract class Duck
    {
        public FlyBehavior flyBehavior;
        public QuackBehavior quackBehavior;

        public Duck()
        {

        }

        public abstract void display();


    }

    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            flyBehavior = new FlyWithWings();
            quackBehavior = new Quack();
        }

        public override void display()
        {
            Console.WriteLine("I’m a real Mallard duck");
        }
    }

    public class FlyWithWings : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I’m flying!!");
        }
    }

    public class FlyNoWay : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I can’t fly");
        }
    }

    public class Quack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }
    }

    public class MuteQuack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("<<Silence>>");
        }
    }

    public class Squeak : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Squeak");
        }
    }

}
