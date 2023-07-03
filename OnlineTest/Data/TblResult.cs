using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblResult
{
    public long Id { get; set; }

    public long CandidateId { get; set; }

    public int ExamId { get; set; }

    public int QuestionId { get; set; }

    public int OptionId { get; set; }

    public int SelectedOptionId { get; set; }

    public bool IsCorrent { get; set; }

    public string? SessionId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblCandidate Candidate { get; set; } = null!;

    public virtual TblExam Exam { get; set; } = null!;

    public virtual TblOption Option { get; set; } = null!;

    public virtual TblQuestion Question { get; set; } = null!;

    public virtual TblOption SelectedOption { get; set; } = null!;
}
