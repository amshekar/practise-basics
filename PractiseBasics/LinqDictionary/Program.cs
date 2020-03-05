using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            


            List<Employee> employees = new List<Employee>(){
            new Employee(){ Name="Test1",Skills = new Dictionary<string,int>(){ { "c#", 2}, {"SQL", 4}, {"java", 5}} },
            new Employee(){Name="Test2",Skills = new Dictionary<string,int>(){ { "SQL",1}, {"java", 2}} },
            new Employee(){Name="Test3",Skills = new Dictionary<string,int>(){ { "c#", 5}, {"SQL", 1}, {"java", 2}} },
            new Employee(){Name="Test4",Skills = new Dictionary<string,int>(){ { "c#", 3}, {"SQL", 3}} },
            new Employee(){Name="Test5",Skills = new Dictionary<string,int>(){ { "c#", 5}, {"SQL", 4}} },



        };
            var result = employees
                .Select(s => new { sk = s.Skills, name = s.Name })
                .SelectMany(sm => sm.sk)
                .Where(w => (w.Key == "java") && (w.Value == 2)).ToList();

            var filteredEmployees = employees.SelectMany(s => s.Skills.Where(w => (w.Key == "java") && (w.Value == 2)));
            foreach (var item in filteredEmployees)
            {
                Console.WriteLine(item);
                
                
            }
        }
        public class Employee
        {
            public string Name { get; set; }
            public Dictionary<string, int> Skills
            { get; set; }
        }
    }
}
