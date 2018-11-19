using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletegateAndEventDiff
{
    class Program
    {

        delegate void MyDelegate();
        delegate void MyDelegate1(int a,int b);
        static void Main(string[] args)
        {
            MyDelegate myDeletegate = new MyDelegate(MethodA);
            myDeletegate();
            myDeletegate = MethodB;
            myDeletegate();
            myDeletegate += Myclass.MethodZ;
            myDeletegate();

            //delegate more optimized and smaller
            Func<int, int, int> operation = (a, b) => a + b;
            Console.WriteLine(operation(10,20));

            //problem statement:How to add Delegate to an Interface? 


            Console.Read();
        }
        static void MethodA()
        {
            Console.WriteLine("Method 'A' is doing workd");
        }
        static void MethodB()
        {
            Console.WriteLine("Method 'B' is doing work");
        }

    }

    class Myclass
    {
        public static void MethodZ()
        {
            Console.WriteLine("Method 'Z' of myclass is doing workk");
        }
    }

    class Myclass1
    {
        void M1(int MyDelegate1) { Console.WriteLine("M1"); }
        void M2(int MyDelegate1) { Console.WriteLine("M2"); }
        void M3(int MyDelegate1) { Console.WriteLine("M3"); }
        void M4(int MyDelegate1) { Console.WriteLine("M4"); }
        void M5(int MyDelegate1) { Console.WriteLine("M5"); }
    }

    public interface IDrawingObject
    {
        event EventHandler ShapeChanged;
    }

    public class shape : IDrawingObject
    {
        public event EventHandler ShapeChanged;

        void ChangeShape()
        {
            OnShapeChanged(new myEvents());
        }

        protected virtual void OnShapeChanged(myEvents e)
        {
            ShapeChanged?.Invoke(this, e);
        }
    }

    public class myEvents:EventArgs
    {

    }
}
