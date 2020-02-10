using System;
using System.Linq;
using System.Collections.Generic;

namespace Assigment1._2
{
    class Program
    {
        public static void Main(String[] args)
        {
            string[] palin = new string[5] { "abcd", "dcba", "lls", "s", "sssll" };

            Console.WriteLine("\nQuestion 1:"); PrintPattern(5);
            Console.WriteLine("\nQuestion 2:"); PrintSeries(6);
            Console.WriteLine("\nQuestion 3:\n" + UsfTime("9:15:35 PM"));
            Console.WriteLine("\nQuestion 4:"); UsfNumbers(110, 11);
            Console.WriteLine("\nQuestion 5:"); PalindromePairs(palin);
            Console.WriteLine("\nQuestion 6:"); Stones(5);
        }

        // Question 1
        /*n – number of lines for the pattern, integer (int)
         * summary   : This method prints number pattern of integers using recursion
         * For example n = 5 will display the output as: 
         * 54321
         * 4321
         * 321
         * 21
         * 1
         * returns      : N/A
         * return type  : void
         */

        private static void PrintPattern(int n)
        {
            try
            {
                while (n > 0)
                {
                    int m = n;

                    while (m > 0)
                    {
                        Console.Write(m);
                        m = m - 1;
                    }
                    Console.WriteLine();
                    n = n - 1;
                }
            }
            catch //We use catch and try to manage any possible corner solution such as n less than 0
            {
                Console.Write("The value is incorrect or non positive");
            }
        }

        /* Coments Question 1
         * To resolve this question it took me like 3 hours. The most difficult part was to find the adequate logic
         * to solve the problem. This problem was pretty useful, because it allow me to understand how to use recursion.
         * My personal recommendations for the future programmers will be to use while loop instead of for loop, because
         * it is more time efficient.
        
        

        // Question 2

        /*n2 – number of terms of the series, integer (int)
         * This method prints the following series till n terms: 1, 3, 6, 10, 15, 21……
         * For example, if n2 = 6, output will be
         * 1,3,6,10,15,21
         * Returns : N/A
         * Return type: void
         * Hint: Series is 1,1+2=3,1+2+3=6,1+2+3+4=10,1+2+3+4+5=15, 1+2+3+4+5+6=21……
         */
        public static void PrintSeries(int n)
        {
            try
            {
                if (n <= 0)
                {
                    Console.WriteLine("Invalid input. Abort!");// This if condition treats the corner cases of n less than 0
                }
                else
                {
                    int sum = 0;
                    // let's start with the looping
                    for (int series = 1; series < n + 1; series++)
                    {
                        sum = series + sum;// We use this sum inside the loop to repetitively sum the elements of the series
                        Console.Write(sum + " ");
                    }
                }

            }
            catch
            {
                Console.WriteLine("Invalid input. Abort!");
            }

        }
        /* Comments Question 2
         * This question took me around the same time than question 1. Again, in this kind of questions the thing that
         * takes more time is to think the logic of how to resolve the problem. I aarive to the solution after several trials
         * and errors. To finally, discover than my mistake was in a semi-colon. My learning from this problem was huge, 
         * because I was used to just find the output of the entire sum of consecutive numbers. However, in this problem
         * I learn how to print partial results in a series way using a for loop. My recommendation will be to pay extra attention
         * to the method used, because that can affect the variables called.
        
        
        // Question 3

        /* On planet “USF” which is similar to that of Earth follows different clock
         * where instead of hours they have U , instead of minutes they have S , instead
         * of seconds they have F. Similar to earth where each day has 24 hours, each hour
         * has 60 minutes and each minute has 60 seconds , USF planet’s day has 36 U , each
         * U has 60 S and each S has 45 F. 
         * Your task is to write a method usfTime which takes 12HR  format and return string 
         * representing input time in USF time format.
         * Input format: A string s with time in 12 hour clock format (i.e. hh:mm:ssAM or
          * hh:mm:ssPM) where 01<= hh<=12, 00<=mm,ss,<=60
         * Output format: a string with converted time in USF clock format (i.e. UU:SS:FF ) 
         * where 01<= UU<=36, 00<=SS<=59,00<=FF<=45
         * 
         * Sample Input : 09:15:35PM
         * Sample Output: 28:20:35 
         * 
         * returns      : String
         * return type  : string
         * 
         * Hint: One way of doing this is by calculating total number of seconds in Input time
         * and dividing those seconds according to USF time.
         */

        public static string UsfTime(string t)
        {
            DateTime time = Convert.ToDateTime(t);
            string rtn;
            float u;// variable for hours in USF time
            float s;//variable for minutes in USF time

            float f;//variable for seconds in usf time
            float sec;// This variable allow us to work with the transformations because thoe will be done in seconds

            try
            {
                sec = time.Hour * 3600
                    + time.Minute * 60
                    + time.Second;

                f = (sec % 45) / 45; //We divide by 45 because that's the value given by the problem for seconds 
                s = (((sec / 45) - f) % 60) / 60;
                u = (((sec / 45) - f) / 60) - s;

                f *= 45;
                s *= 60;

                rtn = u + ":" + s + ":" + f;
            }
            catch
            {
                rtn = "Invalid input. Abort!";// This treats the case of corner solutions in case the input is not writen in the right format
            }
            return rtn;
        }

        /*Comment Question 3
         * This one for sure was one of the most difficult questions, because I needed to understand the logic of converting
         * everything to seconds, before starting working on the transformations to USF time. This question took me around 7
         * hours in total in order to solve it. I spent several days thinking about how to solve it. The learning experience
         * from this question is huge, because I learn how to think backwards in order to solve a problem. For my corner case
         * I thought about inputs that are not written in the right format. My recommendation for this problem will be
         * to call and create the variables for hours minutes and seconds, in that way when we perform the division to find the
         * USF time it will be easier to call

        // Question 4

        /*n- total number of integers( 110 )
        * k-number of numbers per line ( 11)
        * USF Numbers : This method prints the numbers 1 to 110, 11 numbers per line.
        * The method shall print 'U' in place of numbers which are multiple of 3,"S" for 
        * multiples of 5,"F" for multiples of 7, 'US' in place of numbers which are multiple 
        * of 3 and 5,'SF' in place of numbers which are multiple of 5 and 7 and so on. 
        * The output shall look like 
        * 1 2 U 4 S U F 8 U S 11 
        * U 13 F US 16 17 U 19 S UF 22
        * 23 U S 26 U F 29 US 31 32 U....
        * 
        * returns      : N/A
        * return type  : void
        */
        public static void UsfNumbers(int n3, int k)
        {
            String tab = "\t";
            String nln = "\n";// This will help us to divide in different lines

            for (int i = 1; i <= n3; i++)
            {
                String val = "";// inside the for loop we include the if conditions that will change the numbers for the given letters


                if (i % 105 == 0)
                {
                    val = "USF";
                }
                else
                if (i % 35 == 0)
                {
                    val = "SF";
                }
                else
                if (i % 21 == 0)
                {
                    val = "UF";
                }
                else
                if (i % 15 == 0)
                {
                    val = "US";
                }
                else
                if (i % 7 == 0)
                {
                    val = "F";
                }
                else
                if (i % 5 == 0)
                {
                    val = "S";
                }
                else
                if (i % 3 == 0)
                {
                    val = "U";
                }
                else
                {
                    val = i.ToString();
                }

                if (i % k == 0)
                {
                    Console.Write(val + nln);
                }
                else
                {
                    Console.Write(val + tab);
                }
            }
        }

        /*Comments Question 4
         * To me this question was the easiest in this assigment, I think the reason for it is that I was used to this
         * kind of algorithm, because I read the book for absolute begginers. This problem took me around 2 hours to solve.
         * Basically, in this problem I learn that we should call the string value, before solving all the if conditions,
         * because if not we would get the number and the letter. I learnd that after several trials and errors. My recomendation
         * is related to that fact. Also, for a begginer programmer like myself, I will recommend to be very careful with the
         * if conditions use inside a loop.

        // Question 5

        /* You are given a list of unique words, the task is to find all the pairs of 
         * distinct indices (i,j) in the given list such that, the concatenation of two
         * words i.e. words[i]+words[j] is a palindrome.
         * Example:
         * Input: ["abcd","dcba","lls","s","sssll"]
         * Output: [[0,1],[1,0],[3,2],[2,4]] 
         * Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
         * Example:
         * Input: ["bat","tab","cat"]
         * Output: [[0,1],[1,0]] 
         * Explanation: The palindromes are ["battab","tabbat"]
         * 
         * returns      : N/A
         * return type  : void
         */

        public static void PalindromePairs(string[] words)// I created this module after creating the botton module
        {
            string rtn = "";

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (i != j)
                    {
                        if (PalindromeCheck(words[i], words[j]))
                        {
                            if (rtn != "") { rtn = rtn + ","; }
                            rtn = rtn + "[" + i + "," + j + "]";
                        }
                    }
                }
            }
            Console.WriteLine(rtn);
        }
        public static bool PalindromeCheck(string x, string y)
        {
            string z = x + y;// we create the sum of the strings to see if that forms a palindrome.

            for (int i = 0; i < z.Length; i++)
            {
                if (z[i] != z[z.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
        /*Comments Question 5
         * This question took me around 5 hours, because I was not used to deal with indices and lenghts.Therefore it took
         * me a little bit to figure out that I needed to work with lenghts in order to find the Palindrome.I think this
         * exercise was useful, because I learn how to deal with comparissons in programming language. My recommendation
         * for this kind of program will be to use 2 methods one that call another, that can make simpler and more efficient
         * the Palindrome comparisson.
         * 



        /*Question 6
        * You are playing a stone game with one of your friends. There are N number of 
        * The player who takes out the last stone will be the winner. In this case you
        * stones in a bag, each time one of you take turns to take out 1 to 3 stones. 
        * will be the first player to remove the stone(s)(Player 1).
        * 
        * Write a method to determine whether you can win the game given the number of 
        * stones in the bag. Print false if you cannot win the game, otherwise print any
        * one set of moves where you are winning the game. Array should contain moves by
        * both the players.
        * Input: 4
        * Output: false
        * Explanation: As there are 4 stones in the bag, you will never win the game. 
        * No matter 1,2 or 3 stones you take out, the last stone will always be removed by
        * your friend.
        * Input: 5
        * Output: [1,1,3]   or [1,2,2] or [1,3,1]
        * Player 1 picks up 1 stone then player 2 picks up 1 or 2 or 3 stones and the  
        * remaining stones are picked up by player 1.
        * Explanation: As there are 5 stones in the bag, you take out one stone.
        * As there are 4 stones in the bag and it’s your friend’s turn. He will never win 
        * the game because no matter 1,2 or 3 stones he takes out, you will the one to take 
        * out the last stone.
        * 
        * returns      : N/A
        * return type  : void
        */
        /*Comments Question 6
         *This question took me about 4 and a half hours. The reality is that I missread the question and I thought
         * that we should display all the possible outputs, when in reality we just need to print one. I learn from
         * this exercise how to put in practice my previous math knowledge. I used the notion of N (mod 4) to notice that
         * if the number of balls was equal to 4 was impossible for the first player to win. My recommendation for this problem
         * will be to use the asqueryable function in order to call the N(mod 4) that will give us the winner combination
         * in this case the remainders of 1, 2 and 3.
         *
         */

        public static void Stones(int n)
        {
            string rtn;
            int win = 0;

            List<int> list = new List<int>();

            if (n < 4)
            {// We create this corner case in which in order to players can play the minimun amount of balls is 4
                Console.WriteLine("Invalid input. Abort!");
            }
            else
            {
                if (n % 4 == 0)
                {
                    Console.WriteLine("false");
                }
                else
                {
                    win = n % 4;// this describe the case in which the modules of 4 or the residuals are 1,2,3 so the first player can win

                    list.Add(win);

                    while (list.AsQueryable().Sum() != n)
                    {
                        if (list.AsQueryable().Sum() + 3 <= n) { list.Add(3); }
                        else
                        if (list.AsQueryable().Sum() + 2 <= n) { list.Add(2); }
                        else
                        if (list.AsQueryable().Sum() + 1 <= n) { list.Add(1); }
                    }
                }
                rtn = String.Join(",", list);
                Console.WriteLine(rtn);

            }
        }
    }
} 

