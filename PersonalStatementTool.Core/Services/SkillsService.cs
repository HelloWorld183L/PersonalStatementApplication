using System.Collections.Generic;

namespace PersonalStatementTool.Core
{
    public class SkillsService : IPersonalStatementService
    {
        public IEnumerable<string> GetQuestions()
        {
            var questions = new List<string>
            {
                "Universities like to know the skills you have that will help you on the course, or generally with life at university. List these skills here and any supporting evidence to back up why you are so excited about the courses you have chosen.",
                "Include any other achievements you're proud of, positions of responsibility that you hold or have held both in and out of school, and attributes that make you interesting, special or unique.",
            };
            return questions;
        }
    }
}