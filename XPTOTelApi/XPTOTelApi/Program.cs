using Microsoft.IdentityModel.Tokens;
using System.Text;
using Aplicacao.Aplicacoes.Consultas;
using Aplicacao.Aplicacoes.Handlers;
using Infraestrutura.Repositorios;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infraestrutura.Autenticacao;
using Microsoft.AspNetCore.Builder;
using Dominio.Entidades;
using Infraestrutura.Enum;
using XPTOTelApi.Servicos;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var chaveSecreta = builder.Configuration.GetSection("JwtSettings:ChaveSecreta").Value;

var usuariosMocados = new UsuarioRepositorio();

var admin = new Usuario(
    "Administrador",
    "admin@teste.com",
    Hash.GerarHash("123456"), 
    PapelUsuario.Administrador
);
var usuarioCliente = new Usuario(
    "FulanoCliente",
    "cliente@teste.com",
    Hash.GerarHash("123456"),
    PapelUsuario.Cliente
);
await usuariosMocados.Adicionar(admin);
await usuariosMocados.Adicionar(usuarioCliente);

builder.Services.AddSingleton<IUsuario>(usuariosMocados);
builder.Services.AddSingleton<IJwt>(new GerarJwt(chaveSecreta));
builder.Services.AdicionarInjecaoDependencia();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(chaveSecreta)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "XPTOTelApi", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
