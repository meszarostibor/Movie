using System;
using System.Collections.Generic;

namespace Movie.Models;

public partial class Film
{
    public int Id { get; set; }

    public int RendezoId { get; set; }

    public string Cim { get; set; } = null!;

    public TimeSpan Hossz { get; set; }

    public int MufajId { get; set; }

    public bool OscarE { get; set; }

    public int Korhatar { get; set; }

    public byte[] IndexKep { get; set; } = null!;

    public byte[] Kep { get; set; } = null!;

    public virtual Mufaj Mufaj { get; set; } = null!;

    public virtual Rendezo Rendezo { get; set; } = null!;
}
