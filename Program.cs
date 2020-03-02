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
            
            var satu = 1.Convert();
            var belasan = 12.Convert();
            var puluhan = 30.Convert();
            Console.WriteLine(satu);
            Console.WriteLine(belasan);
            Console.WriteLine(puluhan);

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

        public static string Convert(this int number)
        {
            string words = "";

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "nol", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas", "duabelas", "tigabelas", "empat belas", "lima belas", "enam belas", "tujuh belas", "delapan belas", "sembilan belas" };
                var tensMap = new[] { "nol", "sepuluh", "dua puluh", "tiga puluh", "empat puluh", "lima puluh", "enam puluh", "tujuh puluh", "delapan puluh", "sembilan puluh" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
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
