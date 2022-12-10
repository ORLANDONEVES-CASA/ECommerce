﻿using AutoMapper;
using ECommerce.Common.Entities;
using ECommerce.Common.Models.Dtos;

namespace ECommerce.Common.SExplMappers
{
    public class SpExplorationMapper : Profile
    {
        public SpExplorationMapper()
        {
            CreateMap<Concepto, ConceptoDto>().ReverseMap();
            CreateMap<Bodega, BodegaDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Iva, IvaDto>().ReverseMap();
        }
    }
}
