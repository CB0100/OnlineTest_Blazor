using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblOption
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string? DisplayText { get; set; }

    public bool? IsAnswer { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblQuestion Question { get; set; } = null!;

    public virtual ICollection<TblAnswer> TblAnswers { get; set; } = new List<TblAnswer>();

    public virtual ICollection<TblAttemptExamPaperAnswer> TblAttemptExamPaperAnswers { get; set; } = new List<TblAttemptExamPaperAnswer>();

    public virtual ICollection<TblResult> TblResultOptions { get; set; } = new List<TblResult>();

    public virtual ICollection<TblResult> TblResultSelectedOptions { get; set; } = new List<TblResult>();
}
