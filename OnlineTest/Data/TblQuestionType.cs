using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblQuestionType
{
    public int Id { get; set; }

    public string QuestionTypeName { get; set; } = null!;

    public decimal Marks { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual ICollection<TblExamPrepration> TblExamPreprations { get; set; } = new List<TblExamPrepration>();

    public virtual ICollection<TblQuestion> TblQuestions { get; set; } = new List<TblQuestion>();
}
