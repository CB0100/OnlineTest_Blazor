using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblAttemptExam
{
    public long Id { get; set; }

    public long CandidateId { get; set; }

    public int ExamId { get; set; }

    public decimal Marks { get; set; }

    public decimal Duration { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblCandidate Candidate { get; set; } = null!;

    public virtual TblExam Exam { get; set; } = null!;

    public virtual ICollection<TblAttemptExamPaper> TblAttemptExamPapers { get; set; } = new List<TblAttemptExamPaper>();
}
