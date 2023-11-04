﻿using StudyThink.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudyThink.Service.DTOs.Teachers;

public class TeacherCreateDto
{
    public TeacherLevel Level { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;
}
