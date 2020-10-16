using System;
using System.Collections.Generic;

namespace МОАД_Лаб_3_16
{
    internal abstract class AnswerWriter
    {
        protected List<string> Answer = new List<string>() ;// надо убрать это поле и добавить в метод calculateЧёТоТам в виде возвращаемого знаения 
        abstract public void WriteAnswer();

        protected string AddList(List<double> list)
        {
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str += list[i] + "  ";
            }
            Answer.Add(str);
            return str;
        }
        protected List<string> AddMatrix(List<List<double>> matrix)
        {
            List<string> text = new List<string>();
            string row = "";
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    row += $"{matrix[i][j],2} ";
                }
                text.Add(row);
            }
            text.Add("");
            return text;
        }

        protected string AddList(List<int> list)
        {
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str += list[i] + "  ";
            }
            Answer.Add(str);
            return str;
        }
        protected List<string> AddMatrix(List<List<int>> matrix)
        {
            List<string> text = new List<string>();
            string row = "";
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    row += $"{matrix[i][j],2} ";
                }
                text.Add(row);
            }
            text.Add("");
            return text;
        }
        protected void AddAverageTimeByOperators(List<double> averageTimeByOperators)
        {
            Answer.Add("Среднее время по операторам:");
            AddList(averageTimeByOperators);
            Answer.Add("");
        }
        protected void AddAverageTimeByTopic(List<double> averageTimeByTopic)
        {
            Answer.Add("Среднее время по темам:");
            AddList(averageTimeByTopic);
            Answer.Add("");
        }
        private void AddWorkTimes(List<int> workTimes)
        {
            Answer.Add("Рабочее время операторов:");
            AddList(workTimes);
            Answer.Add("");
        }
        private void AddAverageTimeByTopicAndOperator(List<List<double>> averageTimeByTopicAndOperator)
        {
            Answer.Add("Среднее время по операторам(по горизонтали) темам(по вертикали):");
            AddMatrix(averageTimeByTopicAndOperator);
            Answer.Add("");
        }
        protected void CalculateResponse()
        {
            AnswerWriter answerWriter = new AnswerWriterToConsole();
            Rings allRings = new Rings();
            allRings.ReadFromFile();
            /*AddAverageTimeByOperators(allRings.GetAverageTimeByOperators());
            AddAverageTimeByTopic(allRings.GetAverageTimeByTopic());
            AddAverageTimeByTopicAndOperator(allRings.GetAverageTimeByTopicAndOperator());
            AddWorkTimes(allRings.GetWorkTimes());*/
            Answer.Add("Среднее время по операторам:");
            Answer.Add(AddList(allRings.GetAverageTimeByOperators()));
            Answer.Add("");

            Answer.Add("Среднее время по темам:");
            Answer.Add(AddList(allRings.GetAverageTimeByTopic()));
            Answer.Add("");

            Answer.Add("Среднее время по операторам(по горизонтали) темам(по вертикали):");
            Answer.AddRange(AddMatrix(allRings.GetAverageTimeByTopicAndOperator()));
            Answer.Add("");

            Answer.Add("Рабочее время операторов:");
            Answer.Add(AddList(allRings.GetWorkTimes()));
            Answer.Add("");



            Answer.Add("Средняя оценка по теме и оператору:");
            Answer.AddRange(AddMatrix(allRings.GetAverageGradeByTopicAndOperator()));
            Answer.Add("");
            Answer.Add("Мода оценки по теме и оператору:");
            Answer.AddRange(AddMatrix(allRings.GetModeGradeByTopicAndOperator()));
            Answer.Add("");
            Answer.Add("Медиана оценки по теме и оператору:");
            Answer.AddRange(AddMatrix(allRings.GetMedianGradeByTopicAndOperator()));
            Answer.Add("");
            
            /*List<List<int>> averageTimeByTopicAndOperator = allRings.GetAverageTimeByTopicAndOperator();
            List<int> workTimes = allRings.GetWorkTimes();
            List<List<int>> averageGradeByTopicAndOperator = allRings.GetAverageGradeByTopicAndOperator();
            List<List<int>> modeGradeByTopicAndOperator = allRings.GetModeGradeByTopicAndOperator();
            List<List<int>> medianGradeByTopicAndOperator = allRings.GetMedianGradeByTopicAndOperator();*/
        }

        public List<string> GetAnswer()
        {
            CalculateResponse();
            return Answer;
        }
    }
}