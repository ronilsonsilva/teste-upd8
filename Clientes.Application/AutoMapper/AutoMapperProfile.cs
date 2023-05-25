using AutoMapper;
using Clientes.Domain.ClienteAgregate.Commands;
using Clientes.Domain.ClienteAgregate.Entities;
using Clientes.Shared.Dtos;
using Clientes.Shared.InputModels;
using Clientes.Shared.ValueObject;

namespace Clientes.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateClienteInput, CreateClienteCommand>();
            CreateMap<UpdateClienteInput, UpdateClienteCommand>();
            CreateMap<Cliente, ListClienteDto>()
                .ForMember(to => to.Estado, from => from.MapFrom(c => new EstadoValueObject(c.Estado)))
                .ForMember(to => to.Cidade, from => from.MapFrom(c => c.Cidade.Nome));
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<CreateClienteCommand, Cliente>().ReverseMap();
            CreateMap<UpdateClienteCommand, Cliente>().ReverseMap();

            CreateMap<Cidade, CidadeDto>().ReverseMap();
        }
    }
}
