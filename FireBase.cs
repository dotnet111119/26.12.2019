//FirebaseDatabase.net 4.0.4
// https://medium.com/step-up-labs/firebase-c-library-5c342989ad18#.5j8zqmegj

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;


namespace FireBaseApp
{
    internal class Dinosaur
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                var firebase = new FirebaseClient("https://proj1-5351f.firebaseio.com/Customers");

                var dinos = firebase.Child("/1").OnceAsync<Dinosaur>().Result;

                //.OrderByKey()
                //.StartAt("pterodactyl")
                //.LimitToFirst(2)
                //.OnceAsync<Dinosaur>();
                var observable = firebase
                               .Child("/1")
                               .AsObservable<Dinosaur>()
                               .Subscribe(d => Console.WriteLine("Item 1 has changed"));
                // need to create -- Customers/1/dino/Id + name + address
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Done");
        }
    }
}
