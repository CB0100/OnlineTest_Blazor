using System;
using System.Collections.Generic;

namespace OnlineTest.Data;

public partial class TblPassageVideo
{
    public int Id { get; set; }

    public int PassageId { get; set; }

    public string? Video1 { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }
    public int Order { get; set; }
    public virtual TblPassage Passage { get; set; } = null!;
}