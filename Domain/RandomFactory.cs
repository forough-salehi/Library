using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain
{
    public static class RandomFactory
    {
        public static readonly Random rnd = new Random();

        private const string lorem =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur maximus congue nulla in elementum. Nunc finibus vehicula arcu, eget iaculis ligula vestibulum vel. Aliquam interdum ligula libero. Morbi placerat tellus lorem, sit amet iaculis felis tincidunt quis. Nam vel nibh et risus semper laoreet. Maecenas ligula lorem, dictum vitae convallis nec, venenatis sed urna. Etiam at porta diam, sed interdum arcu. Nulla rutrum arcu eget quam pellentesque, at luctus sem posuere. In lectus erat, lacinia sit amet leo vitae, accumsan pharetra diam. Nulla vitae ultricies sapien. Sed malesuada malesuada augue a efficitur.";


        public static string GetString(int minLength, int maxLength)
        {
            var length = GetInt32(min: minLength, max: maxLength);
            return lorem.Substring(rnd.Next(lorem.Length - length - 1), length);
        }

        public static int GetInt32(int max = 100, int min = 0)
        {
            return rnd.Next(min, max);
        }

        public static double GetDouble(double min = 0, double max = 1, int decimalCharacterCount = 2)
        {
            var multiplier = Math.Pow(10, decimalCharacterCount);

            var randomed = GetInt32((int)(max * multiplier), (int)(min * multiplier));
            return randomed / multiplier;
        }

        public static DateTime GetDateTime(int pastYearsOffset = 10)
        {
            Random rnd = new Random();
            int min = 0;
            int max = pastYearsOffset;

            // Generate a random number of years to subtract from the current year
            int yearsToSubtract = rnd.Next(min, max + 1);

            // Calculate the resulting DateTime
            DateTime resultDateTime = DateTime.UtcNow.AddYears(-yearsToSubtract);

            return resultDateTime;
        }

        public static List<Book> Repeat(int count = -1)
        {
            List<Book> books = new List<Book>();
            if (count == -1)
                count = rnd.Next(0, 10);

            for (int i = 0; i < count; i++)
            {
                books.Add(CreateBook());
            }

            return books;
        }

        private static Book CreateBook()
        {
            return new Book
            {
                Author = GetString(18, 32),
                Title = GetString(10, 46),
                Description = GetString(120, 240),
                Id = Guid.NewGuid().ToString(),
                Rate = GetDouble(1, 5),
                TotalPage = GetInt32(min: 110, max: 950),
                Year = GetInt32(min: 1990, max: DateTime.UtcNow.Year),
                CreateDate = GetDateTime(),
                UpdateDate = GetDateTime(),
            };
        }
    }
}
