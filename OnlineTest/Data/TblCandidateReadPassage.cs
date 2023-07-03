using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblCandidateReadPassage
{
    public long Id { get; set; }

    public long CandidateId { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblCandidate Candidate { get; set; } = null!;

    public virtual ICollection<TblReadPassage> TblReadPassages { get; set; } = new List<TblReadPassage>();
}
