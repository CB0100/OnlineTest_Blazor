using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblQuestion
{
    public int Id { get; set; }

    public int? PassageId { get; set; }

    public int QuestionTypeId { get; set; }

    public string? DisplayText { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblPassage? Passage { get; set; }

    public virtual TblQuestionType QuestionType { get; set; } = null!;

    public virtual ICollection<TblAnswer> TblAnswers { get; set; } = new List<TblAnswer>();

    public virtual ICollection<TblAttemptExamPaperAnswer> TblAttemptExamPaperAnswers { get; set; } = new List<TblAttemptExamPaperAnswer>();

    public virtual ICollection<TblAttemptExamPaper> TblAttemptExamPapers { get; set; } = new List<TblAttemptExamPaper>();

    public virtual ICollection<TblOption> TblOptions { get; set; } = new List<TblOption>();

    public virtual ICollection<TblResult> TblResults { get; set; } = new List<TblResult>();
}
