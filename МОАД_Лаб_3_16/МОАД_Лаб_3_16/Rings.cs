using System;
using System.Collections.Generic;
using System.IO;

namespace МОАД_Лаб_3_16
{
    internal class Rings
    {
        private List<List<int>> RingsTable = new List<List<int>>(); //{оператор, начало звонка, конец звонка, тема, оценка}
        internal void ReadFromFile()
        {
            StreamReader streamReader = new StreamReader("Task2 1.csv");
            streamReader.ReadLine();
            int[] startRing = new int[5];
            do
            {
                string row = streamReader.ReadLine();
                string[] words = row.Split(';');
                int numberOperator =Convert.ToInt32(words[0]);
                string[] timeStrings = words[2].Split(':');

                int[] timeNumbers = { Convert.ToInt32(timeStrings[0]), Convert.ToInt32(timeStrings[1]), Convert.ToInt32(timeStrings[2]) };
                
                int time = timeNumbers[0]*3600+timeNumbers[1]*60+timeNumbers[2];
                

                if (words[1].Trim() == "on")
                {
                    startRing[numberOperator - 1] = time;
                }
                else
                {
                    int timeRing = time - startRing[numberOperator-1];
                    int topic = Convert.ToInt32(words[3]);
                    int grade = Convert.ToInt32(words[4]);

                    List<int> ring = new List<int> { numberOperator, timeRing, topic, grade };
                    RingsTable.Add(ring);
                }
            }
            while (!streamReader.EndOfStream);
        }







        internal List<double> GetAverageTimeByOperators()
        {
            List<int> time = new List<int>();
            List<int> counts = new List<int>();
            int count = 0;
            int value = 0;
            for (int k = 1; k < 6; k++)
            {
                for (int i = 0; i < RingsTable.Count; i++)
                {
                    if (RingsTable[i][0] == k)
                    {
                        value += RingsTable[i][1];
                        count++;
                    }
                }
                time.Add(value);
                counts.Add(count);
            }
            List<double> midTime = new List<double>();
            for (int i = 0; i < 5; i++)
            {
                double midTm = (double)time[i] / counts[i];
                midTime.Add(midTm);
            }
            return midTime;
        }

        internal List<double> GetAverageTimeByTopic()
        {
            List<int> time = new List<int>();
            List<int> counts = new List<int>();
            int count = 0;
            int value = 0;
            for (int k = 0; k < 6; k++)
            {
                for (int i = 0; i < RingsTable.Count; i++)
                {
                    if (RingsTable[i][2] == k)
                    {
                        value += RingsTable[i][1];
                        count++;
                    }
                }
                time.Add(value);
                counts.Add(count);
            }
            List<double> midTime = new List<double>();
            for (int i = 0; i < 5; i++)
            {
                double midTm = (double)time[i] / counts[i];
                midTime.Add(midTm);
            }
            return midTime;
        }

        internal List<List<double>> GetAverageTimeByTopicAndOperator()
        {
            List<List<int>> time = new List<List<int>>(5);

            for (int i = 0; i < 5; i++)
            {
                time.Add(new List<int> { 0, 0, 0, 0, 0, 0 });
            }
            List<List<int>> counts = new List<List<int>>(5);
            for (int i = 0; i < 5; i++)
            {
                counts.Add(new List<int> { 0, 0, 0, 0, 0, 0 });
            }

            for (int i = 1; i < RingsTable.Count; i++)
            {
                time[RingsTable[i][0]-1][RingsTable[i][2]] += RingsTable[i][1];
                counts[RingsTable[i][0]-1][RingsTable[i][2]]++;
            }

            List<List<double>> midTime = new List<List<double>>();
            for (int i = 0; i < 5; i++)
            {
                midTime.Add(new List<double> { 0, 0, 0, 0, 0, 0 });
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    midTime[i][j] = (double)time[i][j] / counts[i][j];
                }
            }
            return midTime;
        }


        

        internal List<int> GetWorkTimes()
        {
            throw new NotImplementedException();
        }

        internal List<List<int>> GetAverageGradeByTopicAndOperator()
        {
            throw new NotImplementedException();
        }

        internal List<List<int>> GetModeGradeByTopicAndOperator()
        {
            throw new NotImplementedException();
        }

        internal List<List<int>> GetMedianGradeByTopicAndOperator()
        {
            throw new NotImplementedException();
        }
    }
}