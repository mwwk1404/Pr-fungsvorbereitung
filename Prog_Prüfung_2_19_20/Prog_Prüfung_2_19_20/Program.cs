using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Prüfung_2_19_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Stadt_anlegen";
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Land:");
            string Land = Console.ReadLine();
            Console.WriteLine("Provinz:");
            string Provinz = Console.ReadLine();
            Console.WriteLine("Einwohner:");
            decimal Einwohner = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Höhe:");
            decimal Höhe = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Breitengrad:");
            decimal Breitengrad = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Längengrad:");
            decimal Längengrad = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Zum Beenden Eingabetaste (return) drücken.");



            mondialEntities mondialEntities = new mondialEntities();
            City c = new City();
            
            c.Name = name;
            c.Country = Land;
            c.Province = Provinz;
            c.Population = Einwohner;
            c.Elevation = Höhe;
            c.Latitude = Breitengrad;
            c.Longitude = Längengrad;

            mondialEntities.City.Add(c);
            mondialEntities.SaveChanges();
            

        }
    }
}
