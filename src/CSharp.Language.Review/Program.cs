//Identifies namespaces containing data types that are need to use or reference in in the code in this file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Declares an area or named space in which we can place our programmer defined data types

namespace CSharp.Language.Review
{
    //The namespace plus class name = fully qualified class name. The fully qualified class name  for program is CSharp.Language.Review.Program
    public class Program
    {
        //An example of static field initialized to new random object
        private static Random rnd = new Random();

        //Main method is entry point
        public static void Main(string[] args)
        {
            //Body of the Main  method acts as the driver of my application
            Program app = new Program(args);
            
                app.AssignMarks(30, 80);

                foreach (Student person in app.Students)
                {
                    Console.WriteLine("Name: " + person.Name);
                    foreach (EarnedMark item in person.Marks)
                       Console.WriteLine("\t" + item);
                }                                 
        }//eom

        //This field is acting as a "backing store" for the Students property
        private List<Student> _students = new List<Student>();

        //Property provides controlled access to the backing store (The field)
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        //Construcor, used to ensure all fields/Properties have meaningful values
        public Program(string[] studentNames)
        {
            WeightedMark[] CourseMarks = new WeightedMark[4];
            CourseMarks[0] = new WeightedMark("Quiz 1", 20);
            CourseMarks[1] = new WeightedMark("Quiz 2", 20);
            CourseMarks[2] = new WeightedMark("Exercises", 25);
            CourseMarks[3] = new WeightedMark("Lab", 35);
            int[] possibleMarks = new int[4] { 25, 50, 12, 35 };

            foreach (string name in studentNames)
            {
                EarnedMark[] marks = new EarnedMark[4];
                for (int i = 0; i < possibleMarks.Length; i++)
                    marks[i] = new EarnedMark(CourseMarks[i], possibleMarks[i], 0);
                Students.Add(new Student(name, marks));
            }
        }

        /// <summary>
        /// This assigns a random mark to each student in the  <see cref="Students"/> property
        /// </summary>
        /// <param name="min">Minimum possible earned value for student's mark</param>
        /// <param name="max">Maximum possible earned value for student's mark</param>
        public void AssignMarks(int min, int max)
        {
            foreach (Student person in Students)
                foreach (EarnedMark item in person.Marks)
                    item.Earned = (rnd.Next(min, max) / 100.0) * item.Possible;
        }//eom
    }//eoc
}//eon
