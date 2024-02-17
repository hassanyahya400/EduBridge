using System;
using AutoMapper;
using EduBridge.API.Data;
using EduBridge.API.Models;
using EduBridge.API.Models.Department;

namespace EduBridge.API.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, GetDepartmentsDto>().ReverseMap();
			CreateMap<Department, DepartmentDto>().ReverseMap();
        }
	}
}
