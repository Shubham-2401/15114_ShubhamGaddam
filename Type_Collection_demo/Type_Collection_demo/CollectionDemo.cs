using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Type_Collection_demo
{
    class CollectionDemo
    {
        static void Main(string[] args)
        {
            #region Array

            /*//datatype[] name = new datatype[size];

            //declare
            //int[] numberArray = new int[3];

            //initializing
            //numberArray[0] = 454;
            //numberArray[1] = 44754;
            //numberArray[2] = 23;
            //numberArray[3] = 55;

            //declare and initialize
            int[] numberArray = { 45, 67, 78, 54, 343, 899 };

            for (int i = 0; i < numberArray.Length; i++)
            {
            Console.WriteLine(numberArray[i]);
            }*/
            #endregion

            #region System.Collections classes

            /*ArrayList countryList = new ArrayList();
            countryList.Add("India");          //0
            countryList.Add("USA");            //2
            countryList.Insert(1, "France");   //1

            countryList.Add(100);  //int       //3
            countryList.Add(true); //bool      //4

            //object initializer { }
            Person person = new Person() { FirstName = "Shubham", LastName = "Gaddam" };

            Console.WriteLine(person.FirstName + " " + person.LastName);

            Console.WriteLine("--------------------\n");

            countryList.Add(person);     //5

            // from countrylist collection item no 5 (person object) print only FirstName
            
            //Type conversion
            Console.WriteLine(((Person) countryList[5]).FirstName     );
            
            Console.WriteLine("--------------------\n");


            for (int i = 0; i < countryList.Count; i++)
            {
                Console.WriteLine(countryList[i]);
            }*/

            #endregion

            #region genric Collection classes

            /*List<string> countryList = new List<string>();
            countryList.Add("India");
            //countryList.Add(100);

            List<int> numbers = new List<int>();
            numbers.Add(100);

            List<Person> personList = new List<Person>();
            personList.Add(new Person() { FirstName = "Shubham", LastName = "Gaddam" });

            Console.WriteLine(personList[0].FirstName);*/

            #endregion

            #region Nullable Type

            // int i = null;

            Nullable<int> x = null;
            x = 100;
            x = null;

            //datatype?   -----nullable type
            int? y = null;


            #endregion

        }
    }
}
