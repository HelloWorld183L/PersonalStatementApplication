using System.Collections.Generic;

namespace PersonalStatementTool.Core
{
    public class CourseService : IPersonalStatementService
    {
        public IEnumerable<string> GetQuestions()
        {
            var questions = new List<string>
            {
                "Why are you applying for your chosen course(s)?",
                "Why does this subject interest you?",
                "Why do you think you're suitable for the course(s)?",
                "Do your current or previous studies relate to the course(s) that you have chosen?",
                "Have you taken part in any other activities that demonstrate your interest in the course(s)?"
            };
            return questions;
        }
    }
}