using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DEMO1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CompanyEntities entities = new CompanyEntities())
            {
                Console.WriteLine("Print All:");
                var result = entities.EMPLOYEES.ToList();
                result.ForEach(company => Console.WriteLine(JsonConvert.SerializeObject(company)));
                Console.WriteLine("================================="); // QUERY SYNTAX
                var res1 = from e in entities.EMPLOYEES
                           where e.AGE > 20
                           select new { e.NAME , e.AGE };
                res1.ToList().ForEach(e => Console.WriteLine(JsonConvert.SerializeObject(e)));
                Console.WriteLine("================================="); // QUERY SYNTAX
                var res2 = (from e in entities.EMPLOYEES
                           where e.AGE > 20
                           select e).ToList().Count;
                Console.WriteLine(res2);
                Console.WriteLine("================================="); // METHOD SYNTAX
                // bool func(employee e)
                // { 
                //   return  e.Age > 20;
                // }
                // e => e.Age > 20;               
                var res3 = entities.EMPLOYEES.ToList().Where(e => e.AGE > 20);
                res1.ToList().ForEach(e => Console.WriteLine(JsonConvert.SerializeObject(e)));

                Console.WriteLine();

                //entities.EMPLOYEES.Add(new EMPLOYEE { NAME = "A", AGE = 20, ADDRESS = "B", SALARY = 80000 });
                //entities.EMPLOYEES.Remove(entities.EMPLOYEES.ToList().FirstOrDefault(e => e.ID == 9));
                //entities.SaveChanges();
            }
        }
    }
}
