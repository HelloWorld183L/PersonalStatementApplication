namespace PersonalStatementTool.Core
{
    public class PersonalStatementService : IPersonalStatementService
    {
        public PersonalStatement PersonalStatement { get; set; }

        public PersonalStatementService()
        {
            PersonalStatement = new PersonalStatement();
        }

        public void SetNewText(string newText)
        {
            var personalStatementContent = PersonalStatement.Content;

            if (personalStatementContent.Contains(newText))
            {
                personalStatementContent.Remove(newText);
            }
            personalStatementContent.Add(newText);

            if (personalStatementContent.Contains(string.Empty))
            {
                RemoveEmptyElements();
            }

            PersonalStatement.Text = string.Join("/n", personalStatementContent);
        }

        private void RemoveEmptyElements()
        {
            foreach (var element in PersonalStatement.Content)
            {
                if (element == string.Empty)
                {
                    PersonalStatement.Content.Remove(element);
                }
            }
        }
    }
}