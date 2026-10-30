using System;
using System.Collections.Generic;
using System.Text;

namespace rentcart.models;

public class Vehiculo{ 
    public required int Id{ get; set; }
    public required string Tipo {  get; set; }
    public required string MarcaNombre {  get; set; }
    public required string Placa {  get; set; }
    public required int Lanzamiento { get; set; }


}



