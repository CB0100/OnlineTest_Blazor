using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblReadPassage
{
    public long Id { get; set; }

    public long CandidateReadPassageId { get; set; }

    public int PassageId { get; set; }

    public int ReadingTime { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblCandidateReadPassage CandidateReadPassage { get; set; } = null!;

    public virtual TblPassage Passage { get; set; } = null!;
}
