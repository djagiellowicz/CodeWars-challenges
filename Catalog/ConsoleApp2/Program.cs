using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    // https://www.codewars.com/kata/catalog/train/csharp
    class Program
    {
        public static String s =
        "<prod><name>drill</name><prx>99</prx><qty>5</qty></prod>\n\n" +
        "<prod><name>hammer</name><prx>10</prx><qty>50</qty></prod>\n\n" +
        "<prod><name>screwdriver</name><prx>5</prx><qty>51</qty></prod>\n\n" +
        "<prod><name>table saw</name><prx>1099.99</prx><qty>5</qty></prod>\n\n" +
        "<prod><name>saw</name><prx>9</prx><qty>10</qty></prod>\n\n" +
        "<prod><name>chair</name><prx>100</prx><qty>20</qty></prod>\n\n" +
        "<prod><name>fan</name><prx>50</prx><qty>8</qty></prod>\n\n" +
        "<prod><name>wire</name><prx>10.8</prx><qty>15</qty></prod>\n\n" +
        "<prod><name>battery</name><prx>150</prx><qty>12</qty></prod>\n\n" +
        "<prod><name>pallet</name><prx>10</prx><qty>50</qty></prod>\n\n" +
        "<prod><name>wheel</name><prx>8.80</prx><qty>32</qty></prod>\n\n" +
        "<prod><name>extractor</name><prx>105</prx><qty>17</qty></prod>\n\n" +
        "<prod><name>bumper</name><prx>150</prx><qty>3</qty></prod>\n\n" +
        "<prod><name>ladder</name><prx>112</prx><qty>12</qty></prod>\n\n" +
        "<prod><name>hoist</name><prx>13.80</prx><qty>32</qty></prod>\n\n" +
        "<prod><name>platform</name><prx>65</prx><qty>21</qty></prod>\n\n" +
        "<prod><name>car wheel</name><prx>505</prx><qty>7</qty></prod>\n\n" +
        "<prod><name>bicycle wheel</name><prx>150</prx><qty>11</qty></prod>\n\n" +
        "<prod><name>big hammer</name><prx>18</prx><qty>12</qty></prod>\n\n" +
        "<prod><name>saw for metal</name><prx>13.80</prx><qty>32</qty></prod>\n\n" +
        "<prod><name>wood pallet</name><prx>65</prx><qty>21</qty></prod>\n\n" +
        "<prod><name>circular fan</name><prx>80</prx><qty>8</qty></prod>\n\n" +
        "<prod><name>exhaust fan</name><prx>62</prx><qty>8</qty></prod>\n\n" +
        "<prod><name>cattle prod</name><prx>990</prx><qty>2</qty></prod>\n\n" +
        "<prod><name>window fan</name><prx>62</prx><qty>8</qty></prod>";

        static void Main(string[] args)
        {
            // TODO: CreateProductLine, exception in GetStringsWithArticle if they don't exits.
            Console.WriteLine(Catalog(s, "saw"));
            Console.ReadKey();
        }

        public static string Catalog(string s, string article)
        {
            string mainTag = "prod";
            string priceTag = "prx";
            string quanityTag = "qty";
            string nameTag = "name";

            var listOfMatchedStrings = GetListOfMatchedStrings(s, mainTag);
            var listOfStringsWithArticle = GetStringsWithArticle(listOfMatchedStrings, article);
            if (listOfStringsWithArticle.Count == 0)
            {
                return "Nothing";
            }
            else
            {
                 return CreateProductLine(listOfStringsWithArticle, priceTag, quanityTag, nameTag);
            }
        }
  
        private static List<string> GetListOfMatchedStrings(string s, string tag)
        {
            List<string> listOfMatchedStrings;

            Regex regex = new Regex($"<{tag}>(.*)</{tag}>");
            MatchCollection matches = regex.Matches(s);

           return listOfMatchedStrings = matches.Select(x => x.Value).ToList();
        }

        private static List<string> GetStringsWithArticle(List<string> listOfMatchedStrings, string article)
        {
            return listOfMatchedStrings.Where(x => x.ToLower().Contains(article.ToLower())).ToList(); ;
        }

        private static string CreateProductLine(List<string> stringsWithArticleList, string priceTag, string quanityTag, string nameTag)
        {
            string lineToReturn = "";
            for (int i = 0; i < stringsWithArticleList.Count; i++)
            {
                string price = GetValueBtwnTags(stringsWithArticleList[i], priceTag);
                string name = GetValueBtwnTags(stringsWithArticleList[i], nameTag);
                string quantity = GetValueBtwnTags(stringsWithArticleList[i], quanityTag);

                lineToReturn += $"{name} > prx: ${price} qty: {quantity}";

                if(stringsWithArticleList.Count != i + 1)
                {
                    lineToReturn += "\n";
                }
            }

            return lineToReturn;
        }

        private static string GetValueBtwnTags(string stringWithArticle, string tag)
        {
            string startTag = $"<{tag}>";
            string closeTag = $"</{tag}>";
            int startIndex = stringWithArticle.IndexOf(startTag) + startTag.Length;
            int closeIndex = stringWithArticle.IndexOf(closeTag, startIndex);
            return stringWithArticle.Substring(startIndex, closeIndex - startIndex);
        }
    }
}
