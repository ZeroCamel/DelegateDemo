using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{    
    //定义委托 定义了可以代表的方法的类型

    //委托作为参数传给所实现的方法
    //委托是一个类，它定义了方法的类型，使得可以将方法当作另一个方法的参数来进行传递，
    //这种将方法动态地赋给参数的做法，可以避免在程序中大量使用If-Else(Switch)语句，
    //同时使得程序具有更好的可扩展性。
    public delegate void GreetingDelete(string name);

    class GreetManager
    {
        //加static 与不加static 的区别
        //加静态后 另一个类实例化后不可以调用
        //静态方法不属于实例（对象） 属于类  访问方式不一样
        //静态类是程序在一开始运行的时候就为其分配了内存空间，而非静态类是在实例化的时候才为其分配内存空间
        //通俗理解 一个需要实例化 一个不需要实例化

        public GreetingDelete delegate3;
        public void GreetPeople(string name)
        {
            if (delegate3 != null)
                delegate3(name);
        }
        public void GreetPeople1(string name, GreetingDelete makeGreeting)
        {
            makeGreeting(name);
        }
        //事件  增加Event事件后 属性访问符失效 总是private
        public event GreetingDelete delegate4;
    }
}
