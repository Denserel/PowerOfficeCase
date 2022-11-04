namespace PowerOfficeCase.Models;

public class BrregEnhet
{
    public string OrgNr { get; set; }
    public string BrregNavn { get; set; }
    public string NaeringsKode { get; set; }
    public string OrgForm { get; set; }
    public string AntallAnsatte { get; set; }
    public bool? Konkurs { get; set; }
    public bool? Slettet { get; set; }
}
