using System;
using System.Collections.Generic;
using System.Linq;

namespace linqExample
{
    public class Person 
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime DOB {get; set;}
        public List<string> NickNames {get; set;}
    }
    internal class ReportEntry
    {
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public int NickNameCount { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>(){
                new Person(){
                    FirstName = "Ed", LastName = "Reed", DOB = new DateTime(1970, 04, 10),
                    NickNames = new List<string>(){
                        "Ed", "Goose", "Beast"
                    }
                },
                new Person(){
                    FirstName = "Dwayne", LastName = "Johnson", DOB = new DateTime(1966, 10, 11),
                    NickNames = new List<string>(){
                        "The Rock"
                    }
                },
                new Person(){
                    FirstName = "Bob", LastName = "Smith", DOB = new DateTime(1944, 12, 25),
                    NickNames = new List<string>(){
                        "Robby", "Smitty", "Bud", "The Tiger"
                    }
                },

            };

            //Use LINQ to generate a report a report that includes the pesron's name, their DOB and the number of nicknames they have
            // For example: Bob Smith (12/25/44) has 4 Nickname(s)

            List<ReportEntry> nickNameReport = people.Select(p => 
                new ReportEntry {
                    FullName = $"{p.FirstName} {p.LastName}",
                    DOB = p.DOB,
                    NickNameCount = p.NickNames.Count
                }
            ).ToList();

            foreach (ReportEntry re in nickNameReport)
            {
                Console.WriteLine($"{re.FullName} ({re.DOB.ToShortDateString()}) has {re.NickNameCount} Nickname(s)");
            }


        }
    }
}