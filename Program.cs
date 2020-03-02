using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1,2,3,4,5,6,6,8,8,6,9 };
            var grades = new[] { 87.5, 88.5, 60.5, 90.5, 88.5 };

            var he = "hello world again".Capitalize();
            Console.WriteLine(he);

            var ha = "hello world again".SnakeCase();
            Console.WriteLine(ha);

            var ho = "hello world again".KebabCase();
            Console.WriteLine(ho);

            var mostNumbers = numbers.Mode();
            Console.WriteLine(mostNumbers);

            var mostGrades = grades.Mode();
            Console.WriteLine(mostGrades);
            
            // var satu = 1.Convert();
            // var belasan = 12.Convert();
            // var puluhan = 30.Convert();
            // Console.Writeline(satu)

            var hu = "ini adalah tulisan yang sangat panjang".Trim(8);
            Console.WriteLine(hu);

            var hi = "ini adalah tulisan yang sangat panjang".TrimWords(3);
            Console.WriteLine(hi);

        }
    }

    public static class IEnumerableExtension
    {
        public static string Capitalize(this string text)
        {
            var input = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
            return input;
        }

        public static string SnakeCase(this string text) => text.Replace(" ", "_");

        public static string KebabCase(this string text) => text.Replace(" ", "-");

        public static T Mode<T>(this IEnumerable <T> values)
        {
            return (values.GroupBy(H => H).OrderByDescending(H => H.Count()).Select(H=>H.Key)).First();
        }

        public static string Trim(this string text, int i)
        {
            var input = text.Substring(0, i)+ "...";
            return input;
        }

        public static string TrimWords(this string text, int i)
        {
            var input = string.Join(" ", text.Split(' ').ToList().GetRange(0, i));
            return input;
        }
    }
}
