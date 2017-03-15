using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Static Class inclusion > direct usages of WriteLine(), ReadLine() and etcs
using static System.Console;
using static System.Environment;
#endregion


namespace TestingFramework4._6._1
{    
    class Decorate : IDisposable
    {       
        public Decorate()
        {
            WriteLine("*********************************");            
        }

        public void Dispose()
        {
            WriteLine("*********************************");
            WriteLine(NewLine + NewLine);
        }
        public static Decorate NewObj
        {
            get { return new Decorate(); }
        }
    }


class Program
    {
        
        static void Main(string[] args)
        {

            CallStaticMethod();
            NewStringFormat();
            CatchWithFilters();
            AutoPropertyInitializer();
            SayByeBye();
        }

        private static void SayByeBye()
        {
            Write("hit <Enter> to exist.");
            ReadLine();
        }

        #region using static 'System.Console' or any other static class
        private static void CallStaticMethod()
        {
            using (Decorate.NewObj)
            {
                Write("Enter your name - ");
                var name = ReadLine();
                WriteLine($"Hello {name},{NewLine}Here I'm directly calling static method on Console class.{NewLine}Notice `using static System.Console`"); 
            }
        }
        #endregion

        #region new string format
        private static void NewStringFormat()
        {
            using (Decorate.NewObj)
            {
                var str = $"Hello,{NewLine}This is {UserName} logged in @ {MachineName}.";
                WriteLine(str); 
            }
        }
        #endregion
                
        #region Exception filters
        private static void CatchWithFilters()
        {
            using (Decorate.NewObj)
            {
                var r = new Random().Next(0, 100);
                var isMultipleOf3 = r % 3 == 0;
                var msg = $"Random number is {r}, and isMultipleOf3 is {isMultipleOf3}.{0}";
                try
                {
                    //will throw exception here.
                    var temp = r / 0;
                }
                catch (Exception) when (isMultipleOf3)
                {
                    WriteLine($"Random number is {r}, and isMultipleOf3 is {isMultipleOf3}.");
                }
                catch (Exception)
                {
                    WriteLine($"Random number is {r}, and isMultipleOf3 is {isMultipleOf3}. Under the Last Exception.");
                } 
            }
        }
        #endregion

        #region Property Initializer

        private static string MyMsg { get; } = "Default Value here.";
        private static void AutoPropertyInitializer()
        {
            using (Decorate.NewObj)
            {
                WriteLine($"`MyMsg = \"Another Message\";`  //It will be compile time error.");
                WriteLine($"Default value is = [{MyMsg}]");
            }            
        }
        #endregion

        #region Primary constructor input to class level itself.
        
        private static void PrimaryConstructor()
        {
            using (Decorate.NewObj)
            {

            }
        }
        #endregion
    }    
}
