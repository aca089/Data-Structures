using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSorting
{
    public class Sorting
    {
        private static System.Diagnostics.Stopwatch sortingWatch = new System.Diagnostics.Stopwatch();
        private static long count = 0;
        public static float currentTime, minTime = 9999, maxTime, avgTime;

        public static void DepthSort(Particle[] particles)
        {
            sortingWatch.Restart();

            // You can select which sorting algorithm you'll be using by uncommenting one of the two function calls below
            // You can visually test both of your algorithms this way

            //QuicksortDepthSort(particles);
            InsertionDepthSort(particles);

            sortingWatch.Stop();
            UpdateTimes((float)sortingWatch.ElapsedTicks / System.Diagnostics.Stopwatch.Frequency);
        }

        public static void InsertionDepthSort(Particle[] particles)
        {
            // Implement me
	    //throw new NotImplementedException();
         for (int i =1;i<particles.Length;i++)
         {
//             
             for (int j = i; j > 0 && particles[j - 1].depth > particles[j].depth;j--)
             {
                 Particle temp = particles[j - 1];
                 particles[j - 1] = particles[j];
                 particles[j] = temp;
             }
           
         }  
        }

        public static void QuicksortDepthSort(Particle[] particles)
        {
            // Implement me
            QuickSortR(particles, 0, particles.Length - 1);
	         
            //throw new NotImplementedException()
        
        }

        public static void QuickSortR(Particle[] array, int start, int end)
        {
            if (end > start)
            {
                int pIndex = (start + end) / 2;
                int newIndex = Partition(array, pIndex, start, end);
                QuickSortR(array, start, newIndex - 1);
                QuickSortR(array, newIndex+1, end);
            }
        }

           
        
        public static int Partition(Particle [] array,int pIndex,int start,int end){
            Particle pValue = array[pIndex];
            //swap
            var temp = array[pIndex];
            array[pIndex] = array[end];
            array[end] = temp;
            
            int nextLeft = start;
            for (int i = start; i < end; i++)
            {
                if (array[i].depth <= pValue.depth)
                {
                    var temp1 = array[i];
                    array[i] = array[nextLeft];
                    array[nextLeft] = temp1;
                    nextLeft++;
                }

                
                
            }
            var temp2 = array[nextLeft];
            array[nextLeft] = array[end];
            array[end] = temp2;
            return nextLeft;

           
           
        }

        public static void UpdateTimes(float time)
        {
            time *= 1000;
            count++;
            currentTime = time;
            minTime = minTime < time ? minTime : time;
            maxTime = maxTime > time ? maxTime : time;
            avgTime = avgTime == 0 ? time : ((avgTime * (count - 1)) + time) / count;
        }
    }
}
