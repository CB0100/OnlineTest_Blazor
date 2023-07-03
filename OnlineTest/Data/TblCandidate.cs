using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblCandidate
{
    public long Id { get; set; }

    public string CandidateId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ProfilePic { get; set; }

    public string? Address { get; set; }

    public string? Address2 { get; set; }

    public string Country { get; set; } = null!;

    public string? State { get; set; }

    public string? City { get; set; }

    public string? Zip { get; set; }

    public bool? IsAnswer { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual ICollection<TblAttemptExam> TblAttemptExams { get; set; } = new List<TblAttemptExam>();

    public virtual ICollection<TblCandidateReadPassage> TblCandidateReadPassages { get; set; } = new List<TblCandidateReadPassage>();

    public virtual ICollection<TblResult> TblResults { get; set; } = new List<TblResult>();
}
