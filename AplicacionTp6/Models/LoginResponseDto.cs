using System;
using AplicacionTp6.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class LoginResponseDto
{
    public int IdUsuario { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Apellido { get; set; }
    public string? Mail { get; set; }

    public string? Username { get; set; }
}

