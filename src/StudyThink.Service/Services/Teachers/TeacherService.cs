﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Interfaces.Teachers;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Domain.Exceptions.Files;
using StudyThink.Domain.Exceptions.Teachers;
using StudyThink.Service.Common.Hasher;
using StudyThink.Service.DTOs.Teachers;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Teachers;

namespace StudyThink.Service.Services.Teachers
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;
        private IFileService _fileService;
        private IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository, IFileService fileService, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async ValueTask<long> CountAsync()
        {
            long count = await _teacherRepository.CountAsync();

            if (count == 0)
                throw new TeacherNotFoundException();
            return count;
        }

        public async ValueTask<bool> CreateAsync(TeacherCreationDto model)
        {
            Teacher teacher = _mapper.Map<Teacher>(model);

            if (model.ImagePath == null)
            {
                throw new ImageNotFoundException();
            }
            else
            {
                teacher.ImagePath = await _fileService.UploadImageAsync(model.ImagePath);
                teacher.Password = Hash512.GenerateHash512(model.Password);

                bool dbResult = await _teacherRepository.CreateAsync(teacher);

                if (dbResult)
                    return true;
                throw new TeacherAlreadyExistsException();
            }

        }

        public async ValueTask<bool> DeleteAsync(long Id)
        {
            Teacher teacher = await _teacherRepository.GetByIdAsync(Id);

            if (teacher == null)
            {
                throw new TeacherNotFoundException();
            }
            else
            {
                bool image = await _fileService.DeleteImageAsync(teacher.ImagePath);

                if (image == false) throw new ImageNotFoundException();

                bool res = await _teacherRepository.DeleteAsync(Id);

                return res;
            }
        }

        public async ValueTask<bool> DeleteRange(List<long> teacherIds)
        {
            foreach (var i in teacherIds)
            {
                Teacher teacher = await _teacherRepository.GetByIdAsync(i);

                if (teacher != null)
                {
                    await _teacherRepository.DeleteAsync(i);
                    await _fileService.DeleteImageAsync(teacher.ImagePath);
                }
            }

            return true;
        }

        public async ValueTask<IEnumerable<Teacher>> GetAll(PaginationParams @params)
        {
            IEnumerable<Teacher> teachers = await _teacherRepository.GetAllAsync(@params);

            if (teachers == null)
            {
                throw new TeacherNotFoundException();
            }
            else
            {
                return teachers;
            }
        }

        public async ValueTask<Teacher> GetByEmailAsync(string email)
        {
            //Teacher teacher = await _teacherRepository.GetByEmailAsync(email);

            //if (teacher == null) throw new TeacherNotFoundException();

            throw new NotImplementedException();

        }

        public async ValueTask<Teacher> GetByIdAsync(long Id)
        {
            Teacher teacher = await _teacherRepository.GetByIdAsync(Id);

            if (teacher == null)
            {
                throw new TeacherNotFoundException();
            }
            return teacher;
        }

        public async ValueTask<bool> UpdateAsync(TeacherUpdateDto model)
        {
            //Teacher resultTeacher = await _teacherRepository.GetByIdAsync(model.Id);

            //Teacher teacher2 = new Teacher();
            //teacher2.Email = model.Email;
            //teacher2.PhoneNumber = model.PhoneNumber;


            //if (resultTeacher == null)
            //{
            //    throw new TeacherNotFoundException();
            //}

            //if (model.ImagePath is not null)
            //{
            //    var image = await _fileService.DeleteImageAsync();
            //    string
            //    if (image == false) throw new ImageNotFoundException();

            throw new NotImplementedException();

                //string newImagePath = await _fileService.UploadAvatarAsync(userUpdateDto.UserAvatar);

                //user.UserAvatar = newImagePath;

            }

        public ValueTask<bool> UpdateImageAsync(long teacherId, IFormFile teacherImage)
        {
            throw new NotImplementedException();
        }
    }
}