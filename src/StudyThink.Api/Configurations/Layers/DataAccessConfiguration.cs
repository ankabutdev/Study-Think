﻿using StudyThink.DataAccess.Repositories.Courses;
using StudyThink.Service.Interfaces.Courses;

namespace StudyThink.Api.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        // AutoMapping
        builder.Services.AddAutoMapper(typeof(MapperConfiguration));

        // Database Configurations field

        builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
        //builder.Services.AddScoped<>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();

    }
}
