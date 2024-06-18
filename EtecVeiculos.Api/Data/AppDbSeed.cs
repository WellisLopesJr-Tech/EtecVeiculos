using EtecVeiculos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EtecVeiculos.Api.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder modelBuilder)
    {
        #region TipoVeiculo
        List<TipoVeiculo> tipoVeiculos = [
            new(){
                Id = 1,
                Name = "Moto"
            },
            new(){
                Id = 2,
                Name = "Carro"
            },
            new(){
                Id = 3,
                Name = "Caminhão"
            }
        ];
        modelBuilder.Entity<TipoVeiculo>().HasData(tipoVeiculos);
        #endregion

        #region Marca
        List<Marca> marca = [
            new(){
                Id = 1,
                Nome = "Honda"
            },
            new(){
                Id = 2,
                Nome = "Nissan"
            },
            new(){
                Id = 3,
                Nome = "Dodge"
            }
        ];
        modelBuilder.Entity<Marca>().HasData(marca);
        #endregion

        #region Modelo
        List<Modelo> modelo = [
            new(){
                Id = 1,
                Nome = "Civic G8"
            },
            new(){
                Id = 2,
                Nome = "Civic G10 Type R"
            },
            new(){
                Id = 3,
                Nome = "Skyline GT-R"
            },
            new(){
                Id = 4,
                Nome = "GTR"
            },
            new(){
                Id = 5,
                Nome = "Dodge challenger"
            },
            new(){
                Id = 6,
                Nome = "dodge challenger 1970"
            }
        ];
        modelBuilder.Entity<Modelo>().HasData(modelo);
        #endregion
    }
}
