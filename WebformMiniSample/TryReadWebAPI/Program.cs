using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TryReadWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
          WeatherDataReader.ReadData();
            Console.ReadLine();

        }
    }
}
