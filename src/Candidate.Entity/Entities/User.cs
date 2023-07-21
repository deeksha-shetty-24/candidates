using System;
using System.Collections.Generic;

namespace Candidate.Entity;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
