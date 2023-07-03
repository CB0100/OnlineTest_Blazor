using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Data;

public partial class TblPassage
{
    public int Id { get; set; }

    [Column("GeneralIntructuion")]
    public string? GeneralInstruction { get; set; }

    public int ReadingTime { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? Modified { get; set; }

    public virtual ICollection<TblPassageBlock> TblPassageBlocks { get; set; } = new List<TblPassageBlock>();

    public virtual ICollection<TblPassageVideo> TblPassageVideos { get; set; } = new List<TblPassageVideo>();

    public virtual ICollection<TblQuestion> TblQuestions { get; set; } = new List<TblQuestion>();

    public virtual ICollection<TblReadPassage> TblReadPassages { get; set; } = new List<TblReadPassage>();
}