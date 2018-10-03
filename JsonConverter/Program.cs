using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"C:\Users\Viktor.Jakovlev\Documents\Workspace\JsonConverter\data.json");
            Person person = JsonConvert.DeserializeObject<Person>(input);

            //da pristapis do propertija od prv stepen vo objektot
            Console.WriteLine(person.Name);
            Console.WriteLine("---------------");

            //da pristapis do konkreten del od slozen objekt
            Console.WriteLine(person.Adress[0].City);
            Console.WriteLine("---------------");

            //da iteriras vo koleckija od slozeni objekti so podobjekti
            foreach (var item in person.Adress)
            {
                Console.WriteLine(item.City);
            }
            Console.WriteLine("---------------");

            //da iteriras vo koleckija od slozeni objekti
            foreach (var item in person.Roles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------");

            //prebaruvanje po odreden parametar
            GetAllAdressesInACurrentCity("Skopje");
            Console.WriteLine("---------------");
            GetAllAdressesInACurrentCity("Ohrid");
            Console.WriteLine("---------------");

            //da proveris dali userot go ima toj role
            GetUserByRole("Admin");
            Console.WriteLine("---------------");
            GetUserByRole("CEO");
            Console.WriteLine("---------------");
        }

        public static void GetAllAdressesInACurrentCity(string filter)
        {
            string input = File.ReadAllText(@"C:\Users\Viktor.Jakovlev\Documents\Workspace\JsonConverter\data.json");
            Person person = JsonConvert.DeserializeObject<Person>(input);

            var list = person.Adress.FindAll(x => x.City == filter);

            foreach (var item in list)
            {
                Console.WriteLine(item.Street);
            }
        }

        public static void GetUserByRole(string role)
        {
            string input = File.ReadAllText(@"C:\Users\Viktor.Jakovlev\Documents\Workspace\JsonConverter\data.json");
            Person person = JsonConvert.DeserializeObject<Person>(input);

            bool isConteined = person.Roles.Contains(role);

            if (isConteined)
            {
                Console.WriteLine(person.Name);
            }
            else
            {
                Console.WriteLine("This person doenst have " + role + " role.");
            }
        }
    }
}


