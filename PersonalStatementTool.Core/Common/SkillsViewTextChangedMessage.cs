namespace PersonalStatementTool.Core
{
    public class SkillsViewTextChangedMessage : ITextChangedMessage
    {
        public string NewText { get; set; }

        public void AddText(string personalStatementText)
        {
            personalStatementText += NewText;
        }
    }
}
