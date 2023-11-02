﻿namespace StudyThink.Domain.Entities;

public class Auditable : BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    public DateTime DeletedAt { get; set; }
}
