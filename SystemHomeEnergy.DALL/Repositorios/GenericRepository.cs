﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemHomeEnergy.DALL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SystemHomeEnergy.DALL.Repositorios.Contrato;
using SystemHomeEnergy.MODELS;
using static Azure.Core.HttpHeader;


namespace SystemHomeEnergy.DALL.Repositorios
{
    public class GenericRepository<TModelo>:IGenericRepository<TModelo> where TModelo : class
    {
        private readonly BdhomeEnergyContext _dbcontext;

        public GenericRepository(BdhomeEnergyContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            //NECESITAMOS DEVOLVER EL MODELO CON EL CUAL ESTA SIENDO CONSULTADO, AWAIT PORQUE SON METODOS ASINCRONOS
            try
            {
                TModelo modelo = await _dbcontext.Set<TModelo>().Where(filtro).FirstOrDefaultAsync();
                return modelo;
            }
            catch { throw; }
            // throw new NotImplementedException();
        }
        public async Task<TModelo> Crear(TModelo modelo)
        {
            /// USAMOS LA BASE DE DATOS Y ESTABLECEMOS CON QUE MODELO VAMOS A ESTAR UTILIZANDO, PASAMOS EL MODELO QUE ESTEMOS RECIBIENDO
            try
            {
                _dbcontext.Set<TModelo>().Add(modelo);
                //guardar cambios de manera asincrona asi:
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch { throw; }
            //throw new NotImplementedException();
        }

        public async Task<bool> Editar(TModelo modelo)
        {
           //// llamamos la base de datos, establecemos que modelo vamos a utilizar
            try
            {
                _dbcontext.Set<TModelo>().Update(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch { throw; }
            //  throw new NotImplementedException();
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {

            try
            {
                _dbcontext.Set<TModelo>().Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch { throw; }
            //  throw new NotImplementedException();
        }


        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            //UNA CONSULTA QUE SERA EJECUTADA, DEVUELVE LA CONSULTA Y QUIEN LO LLAME, LO EJECUTA, VALIDAMOS SI INGRESO ALGO EN EL FILTRO PARA BUSCAR O DEVOLVER EL MODELO
            try
            {
                IQueryable<TModelo> queryModelo = filtro == null ? _dbcontext.Set<TModelo>() : _dbcontext.Set<TModelo>().Where(filtro);
                return queryModelo;
            }
            catch { throw; }
            //throw new NotImplementedException();
        }
    }
}
