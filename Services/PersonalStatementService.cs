using PersonalStatementTool.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalStatementTool.Presentation2.Services
{

    // the implantation of the IPersonalStatementService interface.
    class PersonalStatementService : IPersonalStatementService
    {
        public Task<IEnumerable<string>> GetQuesitonsAsync()
        {
            // since this is async, we need to use a TaskCompletionSource to return a task.
            TaskCompletionSource<IEnumerable<string>> taskCompletionSource = new TaskCompletionSource<IEnumerable<string>>();

            // build the list of QuestionAnswers.
            List<string> questions = new List<string>
            {
                "Why are you applying for your chosen course(s)?",
                "Why does this subject interest you?",
                "Why do you think you're suitable for the course(s)?",
                "Do your current or previous studies relate to the course(s) that you have chosen?",
                "Have you taken part in any other activities that demonstrate your interest in the course(s)?"
            };


            // add it to the TaskCompletionSource
            taskCompletionSource.SetResult(questions);

            // return the task
            return taskCompletionSource.Task;
        }
    }
}
