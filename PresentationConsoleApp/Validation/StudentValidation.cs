using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationConsoleApp.Validation
{
    public static class StudentValidation
    {
        public static bool CheckName(string text)
        {
            char[] chars = { '@', '!', '#', '$', '%',' ','^' };
            if (text.Any(char.IsDigit))
            {
                Console.WriteLine("reqem daxil edile bilmez");
                return false;
            }
            foreach (char c in chars)
            {
                if (text.Contains(c))
                {
                    Console.WriteLine("xususi simvol istifade edile bilmez");
                    return false;
                }
            }
            if (text.Length < 2)
            {
                Console.WriteLine("3 ve ya daha cox simvol daxil edin");
                return false;
            }
            return true;
        }
        
        
    }
}
