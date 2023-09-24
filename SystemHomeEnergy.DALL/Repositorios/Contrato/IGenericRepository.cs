﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SystemHomeEnergy.DALL.Repositorios.Contrato
{
    public interface IGenericRepository<TModel> where TModel
      : class
    {
        //son modelos del tipo TMODEL
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
        Task<TModel> Crear(TModel modelo);
        Task<bool> Editar(TModel modelo);
        Task<bool> Eliminar(TModel modelo);
        //este realiza una consulta, trabaja con el modelo
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null);
    }
}
