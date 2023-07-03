using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblExam
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal FullMarks { get; set; }

    public int NoofQuestion { get; set; }

    public int PassingMarks { get; set; }

    public decimal Duration { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual ICollection<TblAttemptExam> TblAttemptExams { get; set; } = new List<TblAttemptExam>();

    public virtual ICollection<TblExamPrepration> TblExamPreprations { get; set; } = new List<TblExamPrepration>();

    public virtual ICollection<TblResult> TblResults { get; set; } = new List<TblResult>();
}
