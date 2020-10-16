using System.IO;

namespace МОАД_Лаб_3_16
{
    internal class AnswerWriterToFile : AnswerWriter
    {
        const string AnswerFileName = "Answer.txt";

        override public void WriteAnswer()
        {
            CalculateResponse();
            StreamWriter streamWriter= new StreamWriter(AnswerFileName);
            foreach (string row in Answer)
            {
                streamWriter.WriteLine(row);
            }
            streamWriter.Close();
        }
    }
}