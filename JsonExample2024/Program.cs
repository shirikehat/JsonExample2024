using JsonExample2024.Models;
using System.Text.Json;


namespace JsonExample2024
{
    internal class Program
    {
        public static string BasicSerializtionExmaple(Student student)
        {
            string json = JsonSerializer.Serialize(student);
            Console.WriteLine(json);
            return json;
        }

        public static string SerializeWithOptions(Student student)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreReadOnlyProperties = true,
                IncludeFields = true,
                
            };
            string json = JsonSerializer.Serialize(student,options);
            Console.WriteLine("With indented option:"  );
            Console.WriteLine(json);
            return json;
        }

        public static void BasicDeserializtion(string str)
        {
            Student student = JsonSerializer.Deserialize<Student>(str);
            Console.WriteLine($@"Basic Deserializtion:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine("Grades:");
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }
        }

        

       
        public static void DeserializtionWithOptions(string str)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
               // PropertyNameCaseInsensitive = true

            };
            Student student = JsonSerializer.Deserialize<Student>(str,options);
            Console.WriteLine($@"Deserializtion With Options:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine("Grades:");
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }

        }
        public static void DeserializationWithPropertyNaming(string jsonStr2)
        {
           MyStudent student=JsonSerializer.Deserialize<MyStudent>(jsonStr2);
            Console.WriteLine($@"Deserializtion With Options:
    StudentId:{student.Id}
    StudentName:{student.Name}
    StudentAge:{student.Age}
    Student BirthDate:{student.BirthDate.ToString("dd/MM/yyyy")} 
    Student KushKush:{student.KushKush}");
            Console.WriteLine("Grades:"  );
            foreach (var sub in student.Subjects)
            {
                Console.WriteLine($@"
{nameof(sub.Name)}:{sub.Name}
Final Grade:{sub.FinalGrade}");
            }
        }



        public static void Print(string monkeys)
        {
            MonkeyList lst= new MonkeyList();
            List<Monkey> m= JsonSerializer.Deserialize<List<Monkey>>(monkeys);
            lst.Monkeys = m;
        }






        public static void ToJson(Monkey m)
        {
            string json= JsonSerializer.Serialize(m);
            Print(json);
        }




        static void Main(string[] args)
        {
           
            Student student = new Student() { BirthDate = new DateTime(2005, 12, 21), Id=1, Name = "Kuku Kaka" };
            student.Subjects.Add(new Subject() { Id = 1, Name = "History", FinalGrade = 100 });

            

            string jsonStr1= BasicSerializtionExmaple(student);
            Console.WriteLine("---------------------");
           
            string jsonStr2=SerializeWithOptions(student);
            Console.WriteLine("---------------------");
            BasicDeserializtion(jsonStr1);
            Console.WriteLine("---------------------");

            

            BasicDeserializtion(jsonStr2);
            Console.WriteLine("---------------------");
           
            
            jsonStr2 = @"{
    ""id"": 1,
    ""Name"": ""Kuku Kaka"",
    ""BirthDate"": ""2005-12-21T00:00:00"",
    ""Wow"":""this is sample to show JsonProperty""
}";
            DeserializtionWithOptions(jsonStr2);
            Console.WriteLine("---------------------");
            DeserializationWithPropertyNaming(jsonStr2);


            string text = File.ReadAllText(@"../../../monkeydata.json");
            


        }

    

    }
}