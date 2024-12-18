using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Movie.Models;

public partial class Rendezo
{
    public int? Id { get; set; }

    public string? Nev { get; set; } = null!;

    public string? Nemzetiseg { get; set; } = null!;

    public DateTime? SzulDatum { get; set; }
    [JsonIgnore]
    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
