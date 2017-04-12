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
