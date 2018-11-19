using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    class Program
    {
        public enum Language
        {
            Chinese, English
        }
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning " + name);
        }
        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好  " + name);
        }
        //委托实现
        private static void MakeGreeting(string name, GreetingDelete makeGreeting)
        {
            makeGreeting(name);
        }
        //普通实现
        public static void GreetPeople(string name, Language language)
        {
            switch (language)
            {
                case Language.Chinese:
                    ChineseGreeting(name);
                    break;
                case Language.English:
                    EnglishGreeting(name);
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            //都是传两个参数 但是维护性和可扩展性差
            GreetPeople("zhangsan", Language.Chinese);
            //维护性可扩展性好
            MakeGreeting("zhangsan", EnglishGreeting);
            //直接使用委托先后调用两个方法

            //法1
            GreetingDelete delegate1;
            //赋值语句  注意先赋值后绑定 先绑定会出现编译错误
            //使用了未赋值的局部变量

            //TODO:委托的多路广播
            delegate1 = EnglishGreeting;
            //绑定语句
            delegate1 += ChineseGreeting;
            delegate1("zhang san");

            Console.WriteLine();

            //法2 委托是一个类 可以对其实例化
            GreetingDelete delegate2 = new GreetingDelete(EnglishGreeting);
            //绑定另一个方法
            delegate2 += ChineseGreeting;
            MakeGreeting("zhang san", delegate2);
            //取消绑定另一个方法
            delegate2 -= ChineseGreeting;
            MakeGreeting("Jerry", delegate2);

            Console.WriteLine();

            //法3
            GreetManager gm = new GreetManager();
            GreetingDelete gd;
            gd = EnglishGreeting;
            gd += ChineseGreeting;
            //非静态调用方法
            gm.GreetPeople1("helen", gd);
            //静态调用方法
            //GreetManager.GreetPeople("helen",gd);

            Console.WriteLine();

            //法4
            //对象封装的概念 将delegate3 变量封装到GreetManager类中
            GreetManager gm1 = new GreetManager();
            gm1.delegate3 = EnglishGreeting;
            gm1.delegate3 += ChineseGreeting;
            gm1.GreetPeople1("John ", gm1.delegate3);
            Console.WriteLine();

            //法5 不需要传参数gm1.delegate3
            GreetManager gm2 = new GreetManager();
            gm1.delegate3 = EnglishGreeting;
            gm1.delegate3 += ChineseGreeting;
            gm1.GreetPeople("John ");

            //法6 控制委托的访问类型
            GreetManager gm3 = new GreetManager();
            gm3.delegate4 += EnglishGreeting;
            gm3.delegate4 += ChineseGreeting;
            gm3.GreetPeople("John ");

            Console.ReadLine();

            //GET NEW IDEAS
            //委托又类似函数指针
            //委托是一种异步通信机制
        }
    }
}
