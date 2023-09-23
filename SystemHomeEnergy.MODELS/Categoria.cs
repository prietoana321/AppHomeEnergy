﻿using System;
using System.Collections.Generic;

namespace SystemHomeEnergy.MODELS;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Servicio> Servicios { get; } = new List<Servicio>();
}
