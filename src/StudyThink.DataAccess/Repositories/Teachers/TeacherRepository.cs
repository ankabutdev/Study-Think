﻿using Dapper;
using StudyThink.DataAccess.Interfaces.Teachers;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Categories;
using StudyThink.Domain.Entities.Teachers;
using System.Net.Http.Headers;

namespace StudyThink.DataAccess.Repositories.Teachers
{
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        public async ValueTask<bool> CreateAsync(Teacher model)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("FirstName");
                @params.Add("LastName");
                @params.Add("DataOfBirth");
                @params.Add("ImagePath");
                @params.Add("Level");
                @params.Add("Description");
                @params.Add("Gender");
                @params.Add("Email");
                @params.Add("PhoneNumber");
                @params.Add("Password");

                string query = @"insert into Teachers (FirstName,LastName,DataOfBirth,ImagePath,Level,Description,Gender,Email,PhoneNumber,Password)" +
                    "values (@FirstName,@LastName,@DateOfBirth,@ImagePath,@Level,@Description,@Email,@PhoneNumber,@Password)";

                int result = await _connection.ExecuteAsync(query, @params);

                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"select count(*) from teachers";

                long result = await _connection.ExecuteScalarAsync<long>(query);

                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<bool> DeleteAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("Id", Id);

                string query = @"delete from teachers where Id = @Id";

                int result = await _connection.ExecuteAsync(query, @params);

                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<IEnumerable<Teacher>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"SELECT * FROM teachers order by Id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

                IEnumerable<Teacher>? teachers = await _connection.ExecuteScalarAsync<IEnumerable<Teacher>>(query);

                return teachers;
            }
            catch
            {
                return Enumerable.Empty<Teacher>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Teacher> GetByIdAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("Id", Id);

                string query = @"select * from teachers where Id = @Id";

                Teacher? teacher = await _connection.ExecuteScalarAsync<Teacher>(query, @params);

                return teacher;
            }
            catch
            {
                return new Teacher();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<Teacher> GetByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("PhoneNumber", phoneNumber);

                string query = "select * from teachers where phoneNumber = @PhoneNumber";

                Teacher? teacher = await _connection.ExecuteScalarAsync<Teacher>(query);

                return teacher;
            }
            catch
            {
                return new Teacher();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async ValueTask<bool> UpdateAsync(long Id,Teacher model)
        {
            try
            {
                await _connection.OpenAsync();

                DynamicParameters @params = new DynamicParameters();
                @params.Add("FirstName");
                @params.Add("LastName");
                @params.Add("DataOfBirth");
                @params.Add("ImagePath");
                @params.Add("Level");
                @params.Add("Description");
                @params.Add("Gender");
                @params.Add("Email");
                @params.Add("PhoneNumber");
                @params.Add("Password");
                @params.Add("UpdatedAt");

                string query = "update teachers set FirstName = @FirstName,@LastName = LastName,DataOfBirth = @DataOfBirth,ImagePath = @ImagePath,Level = @Level" +
                    "Description = @Description,Gender = @Gender,Email = @Email,PhoneNumber = @PhoneNumber,Password = @Password,UpdatedAt = @UpdatedAt";

                int result = await _connection.ExecuteAsync(query, @params);

                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
