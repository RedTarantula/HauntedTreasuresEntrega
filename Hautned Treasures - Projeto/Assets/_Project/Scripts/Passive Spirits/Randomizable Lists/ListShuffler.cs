using System;
using System.Collections.Generic;

namespace _Project.Scripts.Exorcism
{
    public static class ListShuffler
    {
        private static Random rng = new Random();  

        public static void ShuffleList<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                (list[k], list[n]) = (list[n], list[k]);
            }  
        }
    }
}