namespace PowerOfficeCase.Models;


public class GetBrregEnhet
{
    public string organisasjonsnummer { get; set; }
    public string navn { get; set; }
    public Organisasjonsform organisasjonsform { get; set; }
    public Postadresse postadresse { get; set; }
    public string registreringsdatoEnhetsregisteret { get; set; }
    public bool registrertIMvaregisteret { get; set; }
    public Naeringskode1 naeringskode1 { get; set; }
    public int antallAnsatte { get; set; }
    public Forretningsadresse forretningsadresse { get; set; }
    public string stiftelsesdato { get; set; }
    public bool registrertIForetaksregisteret { get; set; }
    public bool registrertIStiftelsesregisteret { get; set; }
    public bool registrertIFrivillighetsregisteret { get; set; }
    public bool konkurs { get; set; }
    public bool underAvvikling { get; set; }
    public bool underTvangsavviklingEllerTvangsopplosning { get; set; }
    public string maalform { get; set; }
    public _Links1 _links { get; set; }
}

public class Organisasjonsform
{
    public string kode { get; set; }
    public string beskrivelse { get; set; }
    public _Links _links { get; set; }
}

public class _Links
{
    public Self self { get; set; }
}

public class Self
{
    public string href { get; set; }
}

public class Postadresse
{
    public string land { get; set; }
    public string landkode { get; set; }
    public string postnummer { get; set; }
    public string poststed { get; set; }
    public string[] adresse { get; set; }
    public string kommune { get; set; }
    public string kommunenummer { get; set; }
}

public class Naeringskode1
{
    public string beskrivelse { get; set; }
    public string kode { get; set; }
}

public class Forretningsadresse
{
    public string land { get; set; }
    public string landkode { get; set; }
    public string postnummer { get; set; }
    public string poststed { get; set; }
    public string[] adresse { get; set; }
    public string kommune { get; set; }
    public string kommunenummer { get; set; }
}

public class _Links1
{
    public Self1 self { get; set; }
}

public class Self1
{
    public string href { get; set; }
}
