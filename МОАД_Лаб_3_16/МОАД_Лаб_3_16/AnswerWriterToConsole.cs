namespace МОАД_Лаб_3_16
{
    internal class AnswerWriterToConsole : AnswerWriter
    {
        override public void WriteAnswer()
        {
            CalculateResponse();
            foreach (string row in Answer)
            {
                System.Console.WriteLine(row);
            }
        }
    }
}