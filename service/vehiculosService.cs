using rentcart.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rentcart.service;

public class VehiculosService
{
    //aqui creamos una lista de vehiculos con los parametros ya establecidos en vehiculos.cs
    private readonly List<Vehiculo> _vehiculos =
    [
        new Vehiculo
        {
            Id = 1,
            Tipo = "Deportivo",
            MarcaNombre = "BMW M4",
            Placa = "XTZ2314HA4",
            Lanzamiento = 2025
        },
        new Vehiculo
        {
            Id = 2,
            Tipo = "Familiar",
            MarcaNombre = "Toyota ra4",
            Placa = "AAA002345",
            Lanzamiento = 2026
        },
        new Vehiculo
        {
            Id = 3,
            Tipo = "TodoTerreno",
            MarcaNombre = "Jeep Wrangler",
            Placa = "ABC123335",
            Lanzamiento = 2023
        },
        new Vehiculo
        {
            Id = 4,
            Tipo = "De calle",
            MarcaNombre = "Lancer",
            Placa = "CER034634",
            Lanzamiento = 2005
        }
    ];
    //con esta funcion tomamos los valores de la lista vehiculo
    public List<Vehiculo> FindAll()
    {
        return _vehiculos;
    }

    //esta funcion sirve para eliminar de la lista vehiculo
    public bool Delete(int id)
    {
        var vehiculo = _vehiculos.FirstOrDefault(v => v.Id == id);

        if (vehiculo is null)
        {
            return false;
        }

        _vehiculos.Remove(vehiculo);

        return true;
    }
    //aqui agregamos un vehiculo a la lista vehiculo
    public bool Create(Vehiculo vehiculo)
    {
        _vehiculos.Add(vehiculo);
        return true;
    }
}