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
            List<string> operator1time = 
        }

        internal List<int> GetAverageTimeByOperators()
        {
            throw new NotImplementedException();
        }

        internal List<int> GetAverageTimeByTopic()
        {
            throw new NotImplementedException();
        }

        internal List<List<int>> GetAverageTimeByTopicAndOperator()
        {
            throw new NotImplementedException();
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