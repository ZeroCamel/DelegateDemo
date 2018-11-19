using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapTwoInterfaceEvent
{
    /// <summary>
    /// 1、打包两个接口事件
    /// </summary>
    class Program
    {
        public interface IDrawingObject
        {
            event EventHandler onDrawn;
        }
        public interface IShape
        {
            event EventHandler onDrawn;
        }
        public class shape : IDrawingObject, IShape
        {
            public event EventHandler PreOnDrawn;
            public event EventHandler PostOnDrawn;

            object objectLock = new object();

            event EventHandler IDrawingObject.onDrawn
            {
                add
                {
                    lock (objectLock)
                    {
                        PreOnDrawn += value;
                    }
                }
                remove
                {
                    lock(objectLock)
                    {
                        PreOnDrawn -= value;
                    }
                }
            }
            event EventHandler IShape.onDrawn
            {
                add
                {
                    lock (objectLock)
                    {
                        PostOnDrawn += value;
                    }
                }
                remove
                {
                    lock (objectLock)
                    {
                        PostOnDrawn -= value;
                    }
                }
            }

            public void Draw()
            {
                PreOnDrawn?.Invoke(this, EventArgs.Empty);
                Console.WriteLine("Drawing a shape!");
                PostOnDrawn?.Invoke(this, EventArgs.Empty);
            }
        }

        public class Subscriber1
        {
            public Subscriber1(shape shape)
            {
                IDrawingObject d = shape;
                d.onDrawn += d_OnDraw;
            }

            void d_OnDraw(object sender,EventArgs s)
            {
                Console.WriteLine("Sub1 receives the IDrawingObject event");
            }
        }

        public class Subscriber2
        {
            public Subscriber2(shape shape)
            {
                IShape d = shape;
                d.onDrawn += d_OnDraw;
            }

            void d_OnDraw(object sender, EventArgs s)
            {
                Console.WriteLine("Sub2 receives the IShape event");
            }
        }

        static void Main(string[] args)
        {
            shape shape = new shape();
            Subscriber1 sub1 = new Subscriber1(shape);
            Subscriber2 sub2 = new Subscriber2(shape);

            shape.Draw();

            Console.Read();
        }
    }
}
