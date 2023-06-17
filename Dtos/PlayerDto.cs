using System.Runtime.Serialization;

namespace Atelier.Dtos;

[Serializable]
[DataContract(Name = "Player")]
public class PlayerDto
{
    public int Id { get; set; }

    public string Firstname { get; set; } = default!;
    
    public string Lastname { get; set; } = default!;

    public string Shortname { get; set; } = default!;

    public string Sex { get; set; } = default!;
   
    public CountryDto Country { get; set; } = default!;

    public string Picture { get; set; } = default!;

    public DataDto Data { get; set; } = default!;
}
