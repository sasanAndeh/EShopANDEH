using System.Reflection;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var s = new Program();
            s.test();
        }
        public void test()
        {
            var s = this.GetType().Name;
            var s2 = MethodBase.GetCurrentMethod().Name;
            Console.WriteLine(s.ToString());
            Console.WriteLine(s2.ToString());
        }
    }
}