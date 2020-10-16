using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МОАД_Лаб_3_16
{
    class Program
    {
        static void Main(string[] args)
        {
            AnswerWriter answerWriter = new AnswerWriterToConsole();
            Rings allRings = new Rings();
            allRings.ReadFromFile();
            List<double> averageTimeByOperators = allRings.GetAverageTimeByOperators();
            List<double> averageTimeByTopic = allRings.GetAverageTimeByTopic();
            List <List<double>> averageTimeByTopicAndOperator = allRings.GetAverageTimeByTopicAndOperator();
            List<int> workTimes = allRings.GetWorkTimes();
            List<List<int>> averageGradeByTopicAndOperator = allRings.GetAverageGradeByTopicAndOperator();
            List<List<int>> modeGradeByTopicAndOperator = allRings.GetModeGradeByTopicAndOperator();
            List<List<int>> medianGradeByTopicAndOperator = allRings.GetMedianGradeByTopicAndOperator();
            
        }
    }
}
