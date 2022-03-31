using api_back_facturacion.Models;
using api_back_facturacion.Models.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_back_facturacion
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<ClienteDto, Cliente>();
                conf.CreateMap<Cliente, ClienteDto>();

                conf.CreateMap<ProductoDto, Producto>();
                conf.CreateMap<Producto, ProductoDto>();

                conf.CreateMap<InventarioDto, Inventario>();
                conf.CreateMap<Inventario, InventarioDto>();

                conf.CreateMap<FacturacionDto, Facturacion>();
                conf.CreateMap<Facturacion, FacturacionDto>();

            });

            return mappingConfig;
        }
    }
}
