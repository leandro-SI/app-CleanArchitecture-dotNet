using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<ProdutoDTO, ProdutoCreateCommand>().ReverseMap();
            CreateMap<ProdutoDTO, ProdutoUpdateCommand>().ReverseMap();
        }
    }
}
