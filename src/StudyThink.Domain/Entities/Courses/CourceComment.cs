﻿namespace StudyThink.Domain.Entities.Course;

public class CourceComment:Auditable
{
    public string Comment { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get;set; }
    public int AdminId { get; set;}
    public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    public DateTime UpdatedAt { get; set;}
}