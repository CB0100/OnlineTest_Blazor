using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblExamPrepration
{
    public int Id { get; set; }

    public int ExamId { get; set; }

    public int QuestionTypeId { get; set; }

    public int NoofQuestion { get; set; }

    public int PassingMarks { get; set; }

    public decimal Duration { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual TblExam Exam { get; set; } = null!;

    public virtual TblQuestionType QuestionType { get; set; } = null!;
}
