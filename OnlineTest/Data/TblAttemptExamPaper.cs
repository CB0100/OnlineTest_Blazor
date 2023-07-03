using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblAttemptExamPaper
{
    public long Id { get; set; }

    public long AttemptExamId { get; set; }

    public int QuestionId { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblAttemptExam AttemptExam { get; set; } = null!;

    public virtual TblQuestion Question { get; set; } = null!;

    public virtual ICollection<TblAttemptExamPaperAnswer> TblAttemptExamPaperAnswers { get; set; } = new List<TblAttemptExamPaperAnswer>();
}
