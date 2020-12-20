using System;

namespace char_by_char
{
    class Program
    {
        static void Main(string[] args)
        {

            int endProg =0;
            do
            {
                int num;
                Console.WriteLine();
                Console.WriteLine("Main menu");
                Console.WriteLine("//////////////////////////////////////////////////");
                Console.Write("(1). Name and Lastname.\n");
                Console.Write("(2). Age.\n");
                Console.Write("(3). Money saving\n");
                Console.Write("(4). Password.\n");
                Console.Write("(5). Exit.\n");
                Console.WriteLine("//////////////////////////////////////////////////");
                Console.Write("Select option: ");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (num)
                {
                    case 1:
                    string name, lastName;
                    Console.Write("Name: ");
                    name = GetNames();
                    Console.Write("\nLast name:");
                    lastName = GetNames();
                    break;

                    case 2:
                    string age;
                    Console.Write("Enter your age: ");
                    age = GetNumber();
                    break;

                    case 3:
                    float money;
                    money = GetMoney();
                    break;

                    case 4:
                    Password();
                    break;

                    case 5:
                        endProg++;
                    break;

                    default:
                    Console.WriteLine("Invalid input.");
                    break;
                }
            } while (endProg == 0);
        }

        static string GetNames()
        {
            var name = string.Empty;
            ConsoleKey key;
            do
            {
              var keyInfo = Console.ReadKey(intercept: true);
              key = keyInfo.Key;
              if(key == ConsoleKey.Backspace && name.Length > 0)
              {
                 Console.Write("\b \b");
                 name = name[0..^1];
              }else if (key == ConsoleKey.Spacebar)
              {
                  Console.Write(keyInfo.KeyChar);
                  name += keyInfo.KeyChar;
              }
              else if(char.IsLetter(keyInfo.KeyChar))
              {
                  Console.Write(keyInfo.KeyChar);
                  name += keyInfo.KeyChar;
              }
            }while(key != ConsoleKey.Enter);
            return name;
        }

        static string GetNumber()
        {
            var num = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if(key == ConsoleKey.Backspace && num.Length > 0)
                {
                    Console.Write("\b \b");
                    num = num[0..^1];
                }
                else if( char.IsDigit(keyInfo.KeyChar))
                {
                    Console.Write(keyInfo.KeyChar);
                    num += keyInfo.KeyChar;
                }

            }while(key != ConsoleKey.Enter);
            return num;
        }
     
     static float GetMoney ()
     {
          var num = string.Empty;
          float Money;
          bool exist = true;
          ConsoleKey key;
          Console.Write("Money saving: ");
          do
          {
              var keyInfo = Console.ReadKey(intercept: true);
              key = keyInfo.Key;

              if (key == ConsoleKey.Backspace && num.Length >0)
              {
                  Console.Write("\b \b");
                  num = num[0..^1];
              }
              else if((key == ConsoleKey.OemPeriod) && exist)
              {
                  Console.Write(keyInfo.KeyChar);
                  num += keyInfo.KeyChar;
                  exist = false;
              }
              else if(char.IsDigit(keyInfo.KeyChar))
              {
                  Console.Write(keyInfo.KeyChar);
                  num += keyInfo.KeyChar;
              }
          }while(key != ConsoleKey.Enter);
          Money = float.Parse(num);
          return Money;

     }

     static string CodePassword()
     {
         var pass = string.Empty;
         ConsoleKey key;
         do
         {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if(key == ConsoleKey.Backspace && pass.Length > 0)
            {
                 Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if(!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
         }while(key != ConsoleKey.Enter);
         return pass;
     }

     static void Password()
     {
         string pass = "";
         string pass1 = "";
         Console.Write("Enter your password: ");
         pass = CodePassword();
         Console.WriteLine();

         do
         {
             Console.WriteLine("Enter your password again: ");
             pass1 = CodePassword();
             if(!(pass1 == pass))
             {
                 Console.WriteLine("Your password doesn't match. ");
                 Console.ReadKey();
             }
             Console.Clear();

         }while(!(pass == pass1));
     }

    }

}
