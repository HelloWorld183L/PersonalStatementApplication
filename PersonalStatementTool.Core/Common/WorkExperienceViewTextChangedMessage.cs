namespace PersonalStatementTool.Core
{
    public class WorkExperienceViewTextChangedMessage : ITextChangedMessage
    {
        public string NewText { get; set; }

        public void AddText(string personalStatementText)
        {
            personalStatementText += NewText;
        }
    }
}
