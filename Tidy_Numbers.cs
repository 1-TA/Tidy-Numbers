//Tidy-Numbers
//Tatiana likes to keep things tidy. Her toys are sorted from smallest to largest, 
//her pencils are sorted from shortest to longest and her computers from oldest to newest. One day, when 
//practicing her counting skills, she noticed that some integers, when written in base 10 with no leading zeroes, 
//have their digits sorted in non-decreasing order. Some examples of this are 8, 123, 555, and 224488. 
//She decided to call these numbers tidy. Numbers that do not have this property, like 20, 321, 495 and 999990, are not tidy. 
//She just finished counting all positive integers in ascending order from 1 to N. What was the last tidy number she counted?

//Input:
//4 (First input Number of inputs)
//132
//1000
//7
//111111111111111110

//Output:
//Case #1: 129
//Case #2: 999
//Case #3: 7
//Case #4: 99999999999999999


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidayNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // ***************************************************************************************************************Read from Console
            //int testCases = Convert.ToInt32(Console.ReadLine());
            //string[][] inputData = new string[testCases][];
            //int[] result = new int[testCases];
            //for (int i = 0; i < testCases; i++)
            //{
            //    //Console.WriteLine("Enter now");
            //    string allParts = Console.ReadLine();
            //    inputData[i] = allParts.Split(' ');
            //}
            // ***************************************************************************************************************Read from File

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\yekta.yazdani\Desktop\input.txt");
            int lln = 0;
            int j = 0;
            int testCases = 0;
            string[] inputData = new string[1000];

            foreach (string line in lines)
            {
                lln++;
                if (lln == 1)
                {
                    testCases = Convert.ToInt16(line);
                }
                else
                {
                    inputData[j] = line.ToString();
                    j++;
                }
            }
            string[] result = new string[testCases];
            // ******************************************************************************************************************Application Start
            for (int i = 0; i < testCases; i++)
            {
                result[i] = string.Join("", highnum(inputData[i]));
            }

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\yekta.yazdani\Desktop\output.txt", true))
            {
                for (int i = 0; i < testCases; i++)
                {
                    file.WriteLine("Case #" + (i + 1).ToString() + ": " + (result[i].Substring(0,1) == "0" ? result[i].Substring(1,(result[i].Length)-1) : result[i].ToString()));

                }
            }
        }


        public static string[] highnum(string strNum)
        {
            bool startover = true;
            var result = strNum.Select(a => a.ToString()).ToArray();
            while (startover)
            {
                startover = false;
                for (int i = result.Length - 1; i > 0; i--)
                {
                    if (Convert.ToInt16(result[i]) >= Convert.ToInt16(result[i - 1]))
                    {
                        continue;
                    }
                    else
                    {
                        startover = true;
                        negateone(result);
                        break;
                    }
                }
            }
            return result;
        }

        public static string[] negateone(string[] result)
        {
            bool countdown = false;
            while (!countdown)
            {
                for (int i = result.Length - 1; i >= 0; i--)
                {
                    if (Convert.ToInt16(result[i]) - 1 >= 0)
                    {
                        countdown = true;
                        result[i] = (Convert.ToInt16(result[i]) - 1).ToString();
                        break;
                    }
                    else
                    {
                        result[i] = 9.ToString();
                        continue;
                    }
                }
            }
            return result;
        }

    }
}
