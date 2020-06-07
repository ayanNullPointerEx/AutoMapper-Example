using Source;
using Destination;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AutoMapper_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbStudent = new DBStudent
            {
                Name = "Ayan",
                Address = "Shbpr Rd",
                Section = "ECE",
                Roll = 1
            };
            Console.WriteLine("DB Student - ");
            Console.WriteLine("Name: " + dbStudent.Name + ", Roll : " + dbStudent.Roll + ", Section : " + dbStudent.Section + ", Address : " + dbStudent.Address);
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<DBStudent,WebStudent>()
                .ForMember(dest => dest.Department, act => act.MapFrom(src => src.Section)));
            var mapper = new Mapper(config);
            WebStudent webStudent = mapper.Map<WebStudent>(dbStudent);
            Console.WriteLine("Web Student - ");
            Console.WriteLine("Name: " + webStudent.Name + ", Roll : " + webStudent.Roll + ", Dept : " + webStudent.Department + ", Address : " + webStudent.Address);
            Console.WriteLine("\n\n");
            ListConvertion(mapper);
        }

        static void ListConvertion(IMapper mapper) 
        {
            var listDBStudent = new List<DBStudent>
            {
                new DBStudent
                {
                    Name = "Ayan", Address = "Shbpr Rd", Section = "ECE", Roll = 1
                },
                new DBStudent
                {
                    Name = "Sayan", Address = "Shbpr Rd", Section = "CSE", Roll = 2
                },
                new DBStudent
                {
                    Name = "Chayan", Address = "Shbpr Rd", Section = "IT", Roll = 3
                },
                new DBStudent
                {
                    Name = "Nayan", Address = "Shbpr Rd", Section = "EE", Roll = 4
                }
            };
            var listWebStudent =  listDBStudent.ConvertAll( x => mapper.Map<WebStudent>(x) );
            Console.WriteLine("DB Students - ");
            listDBStudent.ForEach( x=> Console.WriteLine("Name: " + x.Name + ", Roll : " + x.Roll + ", Dept : " + x.Section + ", Address : " + x.Address));
            Console.WriteLine("Web Students - ");
            listWebStudent.ForEach( x=> Console.WriteLine("Name: " + x.Name + ", Roll : " + x.Roll + ", Dept : " + x.Department + ", Address : " + x.Address));
        }
    }
}
