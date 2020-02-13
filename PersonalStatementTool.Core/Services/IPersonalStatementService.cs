using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalStatementTool.Services
{
    public interface IPersonalStatementService
    {
        Task<IEnumerable<string>> GetQuesitonsAsync();
    }
}
