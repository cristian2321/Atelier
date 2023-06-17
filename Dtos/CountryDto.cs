using System.Runtime.Serialization;

namespace Atelier.Dtos;

[Serializable]
[DataContract(Name = "Country")]
public class CountryDto
{
    public string Picture { get; set; } = default!;

    public string Code { get; set; } = default!;
}