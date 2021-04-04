using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02RepositoryPattern_Repository;

namespace _02RepositoryPatter_Repository
{
    class Program
    {
        static void Main(string[] args)
        {

            ProgramUI program = new ProgramUI();
            program.Run();

            //ClaimsRepository claims = new ClaimsRepository();
            //claims.SayHello();
            
            
        }
    }
}
