using AutoMapper;
using Contabilidade.API.Models;
using Contabilidade.Domain.Entities;
using Contabilidade.Domain.Interfaces;
using Contabilidade.Infra.Data.Contexto;
using Contabilidade.Infra.Data.Repository;
using Contabilidade.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = @"Server=sqldata; Database=Contabilidade_Data; User Id=sa; Password=admin@123;";
builder.Services.AddDbContext<ContabilidadeContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IBaseRepository<Lancamento>, BaseRepository<Lancamento>>();
builder.Services.AddScoped<IBaseService<Lancamento>, BaseService<Lancamento>>();

builder.Services.AddSingleton(new MapperConfiguration(config =>
{
    config.CreateMap<CreateLancamentoModel, Lancamento>().ForMember(l => l.MomentoLancamento, opt => opt.MapFrom(m => Convert.ToDateTime(m.momentolancamento)));
    config.CreateMap<Lancamento, LancamentoModel>();
}).CreateMapper());

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
