using PowerOfficeCase.Models;
using System.Text.Json;

namespace PowerOfficeCase.Data;

public class BrregDataService : IBrregDataService
{
	private readonly HttpClient _httpClient;
	private readonly ILogger<BrregDataService> _logger;

	public BrregDataService(HttpClient httpClient, ILogger<BrregDataService> logger)
	{
		_httpClient = httpClient;
		_logger = logger;
	}

	public async Task<BrregEnhet> GetEnhet(InputCsvOrg org)
	{
		try
		{
			var request = new HttpRequestMessage(HttpMethod.Get, $"/enhetsregisteret/api/enheter/{org.OrgNo}");
			var response = await _httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				using var responseStream = await response.Content.ReadAsStreamAsync();
				var responsObject = await JsonSerializer.DeserializeAsync<GetBrregEnhet>(responseStream);
                
                return new BrregEnhet
				{
					OrgNr = responsObject.organisasjonsnummer,
					BrregNavn = org.Name.Equals(responsObject.navn, StringComparison.OrdinalIgnoreCase) ? org.Name : responsObject.navn,
					NaeringsKode = responsObject?.naeringskode1?.kode ?? "",
					OrgForm = responsObject.organisasjonsform.kode,
					AntallAnsatte = responsObject.antallAnsatte.ToString(),
					Konkurs = responsObject.konkurs,
					Slettet = responsObject?.naeringskode1 is null ? true : false
				};
			}
			else
			{
                _logger.LogWarning("OrgNr: {OrgNr} status kode: {StatusCode}", org.OrgNo, response.StatusCode);
            }
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message);
		}
		
        return new BrregEnhet();
	}
}
