using PowerOfficeCase.Models;

namespace PowerOfficeCase.Data;
public interface IBrregDataService
{
    Task<BrregEnhet> GetEnhet(InputCsvOrg org);
}