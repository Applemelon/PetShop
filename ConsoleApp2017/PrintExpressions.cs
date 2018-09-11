using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp
{
    class PrintExpressions
    {
        void P(string message)
        {
            Console.WriteLine(message);
        }

        public void Intro()
        {
            P("   ._________________.");
            P("   |.---------------.|");
            P("   ||               ||");
            P("   ||   Welcome to  ||");
            P("   ||      the      ||");
            P("   ||    Pet Shop   ||");
            P("   ||  application  ||");
            P("   ||_______________||");
            P("   /.-.-.-.-.-.-.-.-.\\");
            P("  /.-.-.-.-.-.-.-.-.-.\\");
            P(" /.-.-.-.-.-.-.-.-.-.-.\\");
            P("/______/__________\\_____\\");
            P("\\_______________________/");
            P("");
        }

        public void PMain()
        {
            P("-----------------------------------");
            P("What would you like to do?");
            P("");
            P("Enter 1 to add a new Pet");
            P("Enter 2 to find a Pet");
            P("Enter 3 to update Pet information");
            P("Enter 4 to delete a Pet");
            P("Enter 0 to exit the application");
            P("");
        }
    }
}
