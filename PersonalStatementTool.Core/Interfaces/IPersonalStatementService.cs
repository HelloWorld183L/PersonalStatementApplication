using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalStatementTool.Core
{
    public interface IPersonalStatementService
    {
        IEnumerable<string> GetQuestions();
    }
}