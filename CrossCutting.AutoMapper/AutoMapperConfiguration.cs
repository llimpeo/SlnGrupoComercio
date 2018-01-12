using AutoMapper;
using Business.Entities;
using System;
using System.Data;

namespace CrossCutting.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()

        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IDataReader, OrdenPago>();
                cfg.CreateMap<IDataReader, Usuario>();
                cfg.CreateMap<IDataReader, Banco>();
                cfg.CreateMap<IDataReader, Sucursal>();
                cfg.CreateMap<IDataReader, Rol>();

            });

        }
    }
}