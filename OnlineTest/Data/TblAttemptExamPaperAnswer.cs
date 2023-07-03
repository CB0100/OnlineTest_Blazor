using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblAttemptExamPaperAnswer
{
    public int Id { get; set; }

    public long AttemptExamPaperId { get; set; }

    public int QuestionId { get; set; }

    public int OptionId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblAttemptExamPaper AttemptExamPaper { get; set; } = null!;

    public virtual TblOption Option { get; set; } = null!;

    public virtual TblQuestion Question { get; set; } = null!;
}
