using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TablesAndViews.Models
{
    public class PeopleModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        public PeopleModel(string name, string phone, string city)
        {
            this.Name = name;
            this.Phone = phone;
            this.City = city;
        }

        public static List<PeopleModel> peopleList = new List<PeopleModel>() {
            new PeopleModel("Ella Persson","077646464","Stockholm"),
            new PeopleModel("Freddy Johansson","077858585","Gothenburg"),
            new PeopleModel("Maria Karlsson","077232323","Lund"),
            new PeopleModel("John Karlsson","077232323","Lund"),            
            new PeopleModel("Karl Olsson","077232323","Gothenburg"),
            new PeopleModel("Emma Johansson","077232323","Lund"),
            new PeopleModel("Karen Olsson","077232323","Lund"),
            new PeopleModel("Oliver Persson","077232323","Lund"),
            new PeopleModel("Astrid Olsson","077232323","Gothenburg"),               
            new PeopleModel("Adam Olsson","077232323","Lund"),
            new PeopleModel("Lucia Nilsson","077232323","Lund"),
            new PeopleModel("Erik Persson","077232323","Gothenburg")

        };

        public static List<PeopleModel> peopleListResult = new List<PeopleModel>();


        public static void GenerateResultList()
        {
            foreach(var person in peopleList)
            
                peopleListResult.Add(new PeopleModel(person.Name, person.Phone, person.City));
            
        }

        public static void AddPerson(string name, string phone, string city)
        {
            peopleList.Add(new PeopleModel(name, phone, city));
            peopleListResult.Add(new PeopleModel(name, phone, city));
        }

        public static void RemovePerson(int i)
        {
            peopleList.RemoveAt(i);
            peopleListResult.RemoveAt(i);
        }

        public static void ResetFilter()
        {
            peopleListResult.Clear();
            GenerateResultList();
        }

        public static void FilterBy(string filter)
        {
            peopleListResult.Clear();
            foreach(var person in peopleList)
            {
                if (person.Name.Contains(filter) || person.City.Contains(filter))
                {
                    peopleListResult.Add(new PeopleModel(person.Name, person.Phone, person.City));

                }
            }
            
        }


    }
}
