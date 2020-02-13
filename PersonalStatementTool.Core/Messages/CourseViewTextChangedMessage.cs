namespace PersonalStatementTool.Core
{
    public class CourseViewTextChangedMessage : ITextChangedMessage
    {
        public string NewText { get; set; }

        public void AddText(string personalStatementText)
        {
            personalStatementText += NewText;
        }
    }
}
