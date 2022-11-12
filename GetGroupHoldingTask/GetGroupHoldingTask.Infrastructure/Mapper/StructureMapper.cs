using AutoMapper;
using GetGroupHoldingTask.Application.DTOs.OutputDTOs;
using GetGroupHoldingTask.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGroupHoldingTask.Infrastructure.Mapper
{
    internal class StructureMapper : Profile
    {
        public StructureMapper()
        {
            Initialize();
        }

        public void Initialize()
        {
            CreateMap<Customer, CustomerSearchOutputDTO>().ReverseMap();
        }
    }
}
