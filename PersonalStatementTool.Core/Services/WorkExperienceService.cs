using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalStatementTool.Core
{
    public class WorkExperienceService : IPersonalStatementService
    {
        public IEnumerable<string> GetQuestions()
        {
            var questions = new List<string>
            {
                "Include details of jobs, placements, work experience or voluntary work, particularly if it's relevant to your chosen course(s). Try to link any experience to skills or qualities related to the course.",
                "If you know what you'd like to do after completing the course, explain how you want to use the knowledge and experience that you gain.",
            };
            return questions;
        }
    }
}
