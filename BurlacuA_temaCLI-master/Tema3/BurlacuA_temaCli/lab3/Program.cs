using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            using (ImmediateMode window = new ImmediateMode())
            {
                window.Run(60.0); // Rulează la 60 de cadre pe secundă
            }
        }
    }

}
