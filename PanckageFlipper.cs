//Problem A. Oversized Pancake Flipper
//Last year, the Infinite House of Pancakes introduced a new kind of pancake.
//It has a happy face made of chocolate chips on one side(the "happy side"), 
//and nothing on the other side(the "blank side"). 
//You are the head cook on duty.The pancakes are cooked in a single row over a hot surface.
//As part of its infinite efforts to maximize efficiency, the House has recently given you an oversized pancake flipper that flips exactly K consecutive pancakes.
//That is, in that range of K pancakes, it changes every happy-side pancake to a blank-side pancake, and vice versa; 
//it does not change the left-to-right order of those pancakes.
//You cannot flip fewer than K pancakes at a time with the flipper, even at the ends of the row(since there are raised borders on both sides of the cooking surface). 
//For example, you can flip the first K pancakes, but not the first K - 1 pancakes.
//Your apprentice cook, who is still learning the job, just used the old-fashioned single-pancake flipper to flip some individual pancakes and then ran to the restroom with it, 
//right before the time when customers come to visit the kitchen.You only have the oversized pancake flipper left, and you need to use it quickly to leave 
//all the cooking pancakes happy side up, so that the customers leave feeling happy with their visit.
//Given the current state of the pancakes, calculate the minimum number of uses of the oversized pancake flipper needed to leave all pancakes happy side up, 
//or state that there is no way to do it. 


//Input:
//3 (Number of the test cases)
//---+-++- 3
//+++++ 4
//-+-+- 4  

//Output: 
//Case #1: 3
//Case #2: 0
//Case #3: IMPOSSIBLE


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanckageFlipper
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
            //    //Console.WriteLine("Enter now");            //    string allParts = Console.ReadLine();
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
                }            }
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
        public static int flipString(string s, int k)
        {
            bool leftpassed = false;
            bool rightpassed = false;

            int numoflips = 0;
            int len_of_s = s.Length;
            var result = s.Select(a => a.ToString()).ToArray();
            int fard = len_of_s % 2;

            for (int i = 0; i < (result.Length) / 2; i++)
            {
                if (result[i] == "-")
                {
                    numoflips++;
                    int j = k;
                    int inner_i = i;
                    if (k <= (result.Length) - i)
                    {
                        while (j >= 1)
                        {
                            result[inner_i] = flip(result[inner_i]);
                            j--;
                            inner_i++;
                        }
                    }
                    if (inner_i >= (result.Length) / 2)
                    {
                        leftpassed = true;
                    }
                }
            }

            for (int i = (result.Length) - 1; i > (result.Length) / 2; i--)
            {
                if (result[i] == "-")
                {
                    numoflips++;
                    int j = k;
                    int inner_i = i;
                    if (k <= inner_i)
                    {
                        while (j >= 1)
                        {
                            result[inner_i] = flip(result[inner_i]);
                            j--;
                            inner_i--;
                        }
                    }
                    if (inner_i < (result.Length) / 2)
                    {
                        rightpassed = true;
                    }

                }
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == "+")
                    continue;
                else
                {
                    return -1;
                }
            }
            return numoflips;
        }

        public static string flip(string f)
        {
            return (f == "+" ? "-" : "+");
        }
    }
}
