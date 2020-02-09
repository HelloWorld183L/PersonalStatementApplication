namespace PersonalStatementTool.Core
{
    public interface ITextChangedMessage
    {
        void AddText(string personalStatementText);
        string NewText { get; set; }
    }
}
