using System;
using AutoMapper;
using EduBridge.API.Data;
using EduBridge.API.Models;
using EduBridge.API.Models.Authentication;
using EduBridge.API.Models.Department;
using EduBridge.API.Models.User;

namespace EduBridge.API.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, GetDepartmentsDto>().ReverseMap();
			CreateMap<Department, DepartmentDto>().ReverseMap();

            CreateMap<Teacher, EduBridgeUserDto>().ReverseMap();

            CreateMap<Student, EduBridgeUserDto>().ReverseMap();
            CreateMap<Student, GetStudentsDto>().ReverseMap();
            CreateMap<Student, GetStudentDetails>().ReverseMap();

            CreateMap<EduBridgeUser, EduBridgeUserDto>().ReverseMap();
        }
	}
}
