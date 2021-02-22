using System;
using System.Collections.Generic;
using System.Linq;

namespace WithPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = GetPopulationRegister();
            RegisterPerson(people);
        }

        private static List<Person> GetPopulationRegister()
        {
            Person person1 = new Person();
            person1.Name = "A";
            person1.Id = "00A";
            person1.Address = new Address()
            {
                Area = "A",
                City = "A",
                HouseNo = "001",
                State = "Karnataka",
                ZipCode = "560033"
            };
            Person person2 = new Person();
            person2.Name = "B";
            person2.Id = "00B";
            person2.Address = new Address()
            {
                Area = "B",
                City = "B",
                HouseNo = "002",
                State = "Karnataka",
                ZipCode = "560034"
            };
            Person person3 = new Person();
            person3.Name = "C";
            person3.Id = "00C";
            person3.Address = new Address()
            {
                Area = "C",
                City = "C",
                HouseNo = "003",
                State = "Karnataka",
                ZipCode = "560033"
            };

            List<Person> people = new List<Person>()
            {
                person1, person2, person3
            };
            return people;
        }

        private static void RegisterPerson(List<Person> people)
        {
            Console.WriteLine("Enter father Id");
            string id = Console.ReadLine();
            Person fatherPerson = people.SingleOrDefault(p => p.Id == id);
            if (fatherPerson == null)
            {
                Console.WriteLine("No such person exists");
            }
            else
            {
                PrintPersonDetail(fatherPerson);
                Random random = new Random();
                Console.WriteLine("Please enter child name");
                string childName = Console.ReadLine();
                Person childPerson =  new Person();
                childPerson.Name = childName;
                childPerson.Id = random.Next(0, 10000).ToString();
                childPerson.Address = new Address()
                {
                    Area = fatherPerson.Address.Area,
                    City = fatherPerson.Address.City,
                    HouseNo = fatherPerson.Address.City,
                    State = fatherPerson.Address.State,
                    ZipCode = fatherPerson.Address.ZipCode
                };
                people.Add(childPerson);
                PrintPersonDetail(childPerson);
                Console.ReadLine();

            }
            RegisterPerson(people);
        }

        private static void PrintPersonDetail(Person person)
        {
            Console.WriteLine("Person details are as below:");
            Console.WriteLine($"Name is {person.Name}");
            Console.WriteLine($"Id is {person.Id}");
            Console.WriteLine($"HouseNo is {person.Address.HouseNo}");
            Console.WriteLine($"Area is {person.Address.Area}");
            Console.WriteLine($"ZipCode is {person.Address.ZipCode}");
            Console.WriteLine($"City is {person.Address.City}");
            Console.WriteLine($"State is {person.Address.State}");
            Console.WriteLine();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string HouseNo { get; set; }
        public string Area { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
